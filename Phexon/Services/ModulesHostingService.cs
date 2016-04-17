﻿namespace PHRMS.Services
{
    public interface IPeekModulesHostingService
    {
        bool IsDocked(ModuleType moduleType);
        void DockModule(ModuleType moduleType);
        void ShowModule(ModuleType moduleType);
    }

    internal class PeekModulesHostingService : IPeekModulesHostingService
    {
        private readonly IPeekModulesHost peekModulesHost;

        public PeekModulesHostingService(IPeekModulesHost peekModulesHost)
        {
            this.peekModulesHost = peekModulesHost;
        }

        bool IPeekModulesHostingService.IsDocked(ModuleType moduleType)
        {
            return peekModulesHost.IsDocked(moduleType);
        }

        void IPeekModulesHostingService.DockModule(ModuleType moduleType)
        {
            peekModulesHost.DockModule(moduleType);
        }

        void IPeekModulesHostingService.ShowModule(ModuleType moduleType)
        {
            peekModulesHost.ShowPeek(moduleType);
        }
    }
}