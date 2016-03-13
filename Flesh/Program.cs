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

namespace FHRMS {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            AppDomain.CurrentDomain.UnhandledException+= CurrentDomain_UnhandledException;
            DataDirectoryHelper.LocalPrefix = "WinHybridApp";
            bool exit;
            using(IDisposable singleInstanceApplicationGuard = DataDirectoryHelper.SingleInstanceApplicationGuard("DevExpressWinHybridApp", out exit)) {
                if(exit && IsTablet) return;
                DevExpress.Mvvm.CommandBase.DefaultUseCommandManager = false;
                WindowsFormsSettings.SetDPIAware();
                SkinManager.EnableFormSkins();
                DevExpress.UserSkins.BonusSkins.Register();
                ((DevExpress.LookAndFeel.Design.UserLookAndFeelDefault)DevExpress.LookAndFeel.Design.UserLookAndFeelDefault.Default).LoadSettings(() => {
                    var skinCreator = new SkinBlobXmlCreator("HybridApp",
                        "FHRMS.SkinData.", typeof(Program).Assembly, null);
                    SkinManager.Default.RegisterSkin(skinCreator);
                });
                AsyncAdornerBootStrapper.RegisterLookAndFeel(
                    "MetroBlack", "DevExpress.RealtorWorld.Win.SkinData.", typeof(Program).Assembly);
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("HybridApp");
                Application.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

                DevExpress.XtraEditors.WindowsFormsSettings.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
                DevExpress.XtraEditors.WindowsFormsSettings.ScrollUIMode = DevExpress.XtraEditors.ScrollUIMode.Touch;
                float touchScaleFactor, fontSize;
                FHRMS.Common.Utils.DeviceDetector.SuggestHybridDemoParameters(out touchScaleFactor, out fontSize);
                WindowsFormsSettings.DefaultFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.TouchScaleFactor = touchScaleFactor;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
        public static Icon AppIcon {
            get { return DevExpress.Utils.ResourceImageHelper.CreateIconFromResourcesEx("FHRMS.Resources.AppIcon.ico", typeof(MainForm).Assembly); }
        }
        public static MainForm MainForm { get; set; }
        private static bool? isTablet = null;
        public static bool IsTablet {
            get {
                if (isTablet == null) {
                    isTablet = FHRMS.Common.Utils.DeviceDetector.IsTablet;
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

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
        
        }
    }
}
