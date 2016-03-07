using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.XtraBars.Docking2010.Customization;
using System;
using System.Linq;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Internal;
using System.Reflection;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace DevExpress.DevAV {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            DataDirectoryHelper.LocalPrefix = "WinHybridApp";
            bool exit;
            using(IDisposable singleInstanceApplicationGuard = DataDirectoryHelper.SingleInstanceApplicationGuard("DevExpressWinHybridApp", out exit)) {
                if(exit && IsTablet) return;
                DevExpress.Mvvm.CommandBase.DefaultUseCommandManager = false;
                WindowsFormsSettings.SetDPIAware();
                SkinManager.EnableFormSkins();
                UserSkins.BonusSkins.Register();
                ((DevExpress.LookAndFeel.Design.UserLookAndFeelDefault)DevExpress.LookAndFeel.Design.UserLookAndFeelDefault.Default).LoadSettings(() => {
                    var skinCreator = new SkinBlobXmlCreator("HybridApp",
                        "DevExpress.DevAV.SkinData.", typeof(Program).Assembly, null);
                    SkinManager.Default.RegisterSkin(skinCreator);
                });
                AsyncAdornerBootStrapper.RegisterLookAndFeel(
                    "MetroBlack", "DevExpress.RealtorWorld.Win.SkinData.", typeof(Program).Assembly);
                LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("HybridApp");
                Application.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

                DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = Utils.DefaultBoolean.True;
                DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = XtraEditors.ScrollUIMode.Touch;
                float touchScaleFactor, fontSize;
                DevExpress.DevAV.Common.Utils.DeviceDetector.SuggestHybridDemoParameters(out touchScaleFactor, out fontSize);
                WindowsFormsSettings.DefaultFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.TouchScaleFactor = touchScaleFactor;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
        public static Icon AppIcon {
            get { return DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("DevExpress.DevAV.Resources.AppIcon.ico", typeof(MainForm).Assembly); }
        }
        public static MainForm MainForm { get; set; }
        private static bool? isTablet = null;
        public static bool IsTablet {
            get {
                if (isTablet == null) {
                    isTablet = DevExpress.DevAV.Common.Utils.DeviceDetector.IsTablet;
                }
                return isTablet.Value;
            }
        }
        static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args) {
            string partialName = DevExpress.Utils.AssemblyHelper.GetPartialName(args.Name).ToLower();
            if(partialName == "entityframework" || partialName == "system.data.sqlite" || partialName == "system.data.sqlite.ef6") {
                string path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), partialName + ".dll");
                return Assembly.LoadFrom(path);
            }
            return null;
        }
    }
}
