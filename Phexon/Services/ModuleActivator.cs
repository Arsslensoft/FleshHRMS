using System;
using System.Reflection;

namespace PHRMS.Services
{
    public interface IModuleActivator
    {
        object CreateModule(string moduleTypeName);
        object CreateModule(string moduleTypeName, object viewModel);
    }

    internal class ModuleActivator : IModuleActivator
    {
        private readonly Assembly moduleAssembly;
        private readonly string rootNamespace;

        public ModuleActivator(Assembly moduleAssembly, string rootNamespace)
        {
            this.moduleAssembly = moduleAssembly;
            this.rootNamespace = rootNamespace;
        }

        public object CreateModule(string moduleTypeName)
        {
            var moduleType = moduleAssembly.GetType(rootNamespace + '.' + moduleTypeName);
            return Activator.CreateInstance(moduleType);
        }

        public object CreateModule(string moduleTypeName, object viewModel)
        {
            var moduleType = moduleAssembly.GetType(rootNamespace + '.' + moduleTypeName);
            return Activator.CreateInstance(moduleType, viewModel);
        }
    }

    public interface IReportActivator
    {
        object CreateReport(string reportTypeName);
    }

    internal class ReportActivator : IReportActivator
    {
        private readonly Assembly reportAssembly;
        private readonly string rootNamespace;

        public ReportActivator(Assembly moduleAssembly, string rootNamespace)
        {
            reportAssembly = moduleAssembly;
            this.rootNamespace = rootNamespace;
        }

        public object CreateReport(string reportTypeName)
        {
            var moduleType = reportAssembly.GetType(rootNamespace + '.' + reportTypeName);
            return Activator.CreateInstance(moduleType);
        }
    }
}