using DevExpress.XtraBars.Ribbon;

namespace PHRMS.Modules
{
    public interface IRibbonModule
    {
        RibbonControl Ribbon { get; }
    }

    public interface ISupportViewModel
    {
        object ViewModel { get; }
        void ParentViewModelAttached();
    }
}