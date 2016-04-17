using DevExpress.Images;

namespace PHRMS.Services
{
    public interface IModuleResourceProvider
    {
        string GetCaption(ModuleType moduleType);
        object GetModuleImage(ModuleType moduleType);
    }

    public class ModuleResourceProvider : IModuleResourceProvider
    {
        public string GetCaption(ModuleType moduleType)
        {
            if (moduleType == ModuleType.Unknown)
            {
                return null;
            }
            return moduleType.ToString();
        }

        public virtual object GetModuleImage(ModuleType moduleType)
        {
            return null;
        }
    }
}

namespace PHRMS.Services.Win
{
    public class ModuleResourceProvider : Services.ModuleResourceProvider
    {
        public override object GetModuleImage(ModuleType moduleType)
        {
            if (moduleType == ModuleType.Unknown)
            {
                return null;
            }
            switch (moduleType)
            {
                case ModuleType.Employés:

                    return ImageResourceCache.Default.GetImage(@"images/people/usergroup_32x32.png");
                default:
                    return null;
            }
        }
    }
}