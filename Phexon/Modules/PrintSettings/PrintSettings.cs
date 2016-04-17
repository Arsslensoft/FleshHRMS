using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;

namespace PHRMS.Modules
{
    public partial class PrintSettings : XtraUserControl, ISupportNavigation
    {
        public PrintSettings()
        {
            InitializeComponent();
        }

        public virtual void OnNavigatedFrom(INavigationArgs args)
        {
        }

        public virtual void OnNavigatedTo(INavigationArgs args)
        {
        }
    }
}