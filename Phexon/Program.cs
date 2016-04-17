using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.LookAndFeel.Design;
using DevExpress.Mvvm;
using DevExpress.Skins;
using DevExpress.Skins.Info;
using DevExpress.UserSkins;
using DevExpress.Utils;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraEditors;
using PHRMS.Data;
using PHRMS.Utils;

namespace PHRMS
{
    internal static class Program
    {
        private static bool? isTablet;

        public static Icon AppIcon
        {
            get
            {
                return ResourceImageHelper.CreateIconFromResourcesEx("PHRMS.Resources.phexon.ico",
                    typeof(MainForm).Assembly);
            }
        }

        public static MainForm MainForm { get; set; }

        public static bool IsTablet
        {
            get
            {
                if (isTablet == null)
                {
                    isTablet = DeviceDetector.IsTablet;
                }
                return isTablet.Value;
            }
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.AssemblyResolve += OnCurrentDomainAssemblyResolve;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DataDirectoryHelper.LocalPrefix = "WinHybridApp";
            bool exit;
            using (
                var singleInstanceApplicationGuard =
                    DataDirectoryHelper.SingleInstanceApplicationGuard("DevExpressWinHybridApp", out exit))
            {
                if (exit && IsTablet) return;
                CommandBase.DefaultUseCommandManager = false;
                WindowsFormsSettings.SetDPIAware();
                SkinManager.EnableFormSkins();
                BonusSkins.Register();
                ((UserLookAndFeelDefault) UserLookAndFeel.Default).LoadSettings(() =>
                {
                    var skinCreator = new SkinBlobXmlCreator("HybridApp",
                        "PHRMS.SkinData.", typeof(Program).Assembly, null);
                    SkinManager.Default.RegisterSkin(skinCreator);
                });
                AsyncAdornerBootStrapper.RegisterLookAndFeel(
                    "MetroBlack", "DevExpress.RealtorWorld.Win.SkinData.", typeof(Program).Assembly);
                UserLookAndFeel.Default.SetSkinStyle("HybridApp");
                Application.CurrentCulture = CultureInfo.GetCultureInfo("en-us");

                WindowsFormsSettings.AllowPixelScrolling = DefaultBoolean.True;
                WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
                float touchScaleFactor, fontSize;
                DeviceDetector.SuggestHybridDemoParameters(out touchScaleFactor, out fontSize);
                WindowsFormsSettings.DefaultFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.DefaultMenuFont = new Font("Segoe UI", fontSize);
                WindowsFormsSettings.TouchScaleFactor = touchScaleFactor;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MainForm = new MainForm();
                Application.Run(MainForm);
            }
        }

        private static Assembly OnCurrentDomainAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var partialName = AssemblyHelper.GetPartialName(args.Name).ToLower();
            if (partialName == "entityframework" || partialName == "system.data.sqlite" ||
                partialName == "system.data.sqlite.ef6")
            {
                var path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), partialName + ".dll");
                return Assembly.LoadFrom(path);
            }
            return null;
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception) args.ExceptionObject;
        }
    }
}