using System;
using System.Collections.Generic;
using System.IO;

namespace PHRMS.Services
{
    public interface IWorkspaceService
    {
        void SetupDefaultWorkspace();
        void SaveWorkspace(string workspaceName);
        void RestoreWorkspace(string workspaceName);
        void ResetWorkspace(string workspaceName);
    }

    internal class WorkspaceService : IWorkspaceService
    {
        private static string DefaultWorkspaceLayout;
        private static IDictionary<string, string> layouts;
        private readonly ISupportModuleLayout supportModuleLayout;

        public WorkspaceService(ISupportModuleLayout supportModuleLayout)
        {
            this.supportModuleLayout = supportModuleLayout;
        }

        public void SetupDefaultWorkspace()
        {
            if (layouts == null)
            {
                layouts = new Dictionary<string, string>();
            }
            DefaultWorkspaceLayout = StoreCore();
        }

        public void SaveWorkspace(string workspaceName)
        {
            layouts[workspaceName] = StoreCore();
        }

        public void RestoreWorkspace(string workspaceName)
        {
            string layoutStr;
            if (!layouts.TryGetValue(workspaceName, out layoutStr))
            {
                layoutStr = DefaultWorkspaceLayout;
            }
            RestoreCore(layoutStr);
        }

        public void ResetWorkspace(string workspaceName)
        {
            layouts.Remove(workspaceName);
            RestoreCore(DefaultWorkspaceLayout);
        }

        private string StoreCore()
        {
            using (var ms = new MemoryStream())
            {
                supportModuleLayout.SaveLayoutToStream(ms);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private void RestoreCore(string layoutStr)
        {
            if (string.IsNullOrEmpty(layoutStr))
            {
                return;
            }
            using (var ms = new MemoryStream(Convert.FromBase64String(layoutStr)))
            {
                supportModuleLayout.RestoreLayoutFromStream(ms);
            }
        }
    }
}