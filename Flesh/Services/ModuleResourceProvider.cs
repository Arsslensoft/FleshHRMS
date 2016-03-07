namespace DevExpress.DevAV.Services {
    public interface IModuleResourceProvider {
        string GetCaption(ModuleType moduleType);
        object GetModuleImage(ModuleType moduleType);
    }
    public class ModuleResourceProvider : IModuleResourceProvider {
        public string GetCaption(ModuleType moduleType) {
            if (moduleType == ModuleType.Unknown) {
                return null;
            }
            return moduleType.ToString();
        }
        public virtual object GetModuleImage(ModuleType moduleType) {
            return null;
        }
    }
}
namespace DevExpress.DevAV.Services.Win {
    public class ModuleResourceProvider : DevExpress.DevAV.Services.ModuleResourceProvider {
        public override object GetModuleImage(ModuleType moduleType) {
            if (moduleType == ModuleType.Unknown) {
                return null;
            }
            switch (moduleType) {
                case ModuleType.Employees:
                case ModuleType.CustomersModule:
                case ModuleType.CustomersFilterPane:
                    return Images.ImageResourceCache.Default.GetImage(@"images/people/usergroup_32x32.png");
                default:
                    return null;
            }
        }
    }
}
