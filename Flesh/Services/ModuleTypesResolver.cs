namespace DevExpress.DevAV.Services {
    public interface IModuleTypesResolver {
        string GetName(ModuleType moduleType);
        string GetTypeName(ModuleType moduleType);
        System.Guid GetId(ModuleType moduleType);
        ModuleType GetPeekModuleType(ModuleType type);
        ModuleType GetExportModuleType(ModuleType type);
        ModuleType GetPrintModuleType(ModuleType type);
        string GetReportTypeName(object reportType);
    }
    internal class ModuleTypesResolver : IModuleTypesResolver {
        public ModuleType GetExportModuleType(ModuleType moduleType) {
            switch (moduleType) {
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetPrintModuleType(ModuleType moduleType) {
            switch (moduleType) {
                default:
                    return ModuleType.Unknown;
            }
        }
        public string GetName(ModuleType moduleType) {
            if (moduleType == ModuleType.Unknown) {
                return null;
            }
            return moduleType.ToString();
        }
        public string GetTypeName(ModuleType moduleType) {
            if (moduleType == ModuleType.Unknown) {
                return null;
            }
            return moduleType.ToString();
        }
        public string GetReportTypeName(object reportType) {
            return reportType.GetType().Name.Replace("ReportType", string.Empty) + reportType.ToString();
        }
        public System.Guid GetId(ModuleType moduleType) {
            switch (moduleType) {
                case ModuleType.Employees:
                case ModuleType.EmployeeEdit:
                case ModuleType.EmployeeView:
                    return new System.Guid("f4e3551d-6679-4db6-a103-1e25d7bc83a2");
                case ModuleType.CustomersModule:
                case ModuleType.CustomersPeek:
                case ModuleType.CustomersFilterPane:
                    return new System.Guid("f4e3551d-6679-4db6-a103-1e25d7bc83a3");
                default:
                    return System.Guid.Empty;
            }
        }
        public ModuleType GetMapModuleType(ModuleType moduleType) {
            switch (moduleType) {
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetPeekModuleType(ModuleType moduleType) {
            switch (moduleType) {
                case ModuleType.Employees:
                case ModuleType.CustomersModule:
                case ModuleType.CustomersPeek:
                case ModuleType.CustomersFilterPane:
                    return ModuleType.CustomersPeek;
                default:
                    return ModuleType.Unknown;
            }
        }
        public ModuleType GetNavPaneModuleType(ModuleType moduleType) {
            switch (moduleType) {
                case ModuleType.Employees:
                case ModuleType.CustomersModule:
                case ModuleType.CustomersPeek:
                case ModuleType.CustomersFilterPane:
                    return ModuleType.CustomersFilterPane;
                default:
                    return ModuleType.Unknown;
            }
        }
    }
}
