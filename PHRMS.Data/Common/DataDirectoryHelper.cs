using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32;

namespace PHRMS.Data
{
    public class DataDirectoryHelper
    {
        public const string DataFolderName = "Data";
        private static bool? _isClickOnce;

        public static bool IsClickOnce
        {
            get
            {
                if (_isClickOnce == null)
                {
#if DEBUG && !CLICKONCE
                    _isClickOnce = false;
#else
                    _isClickOnce = !BrowserInteropHelper.IsBrowserHosted && ApplicationDeployment.IsNetworkDeployed;
#endif
                }
                return (bool) _isClickOnce;
            }
        }

        public static string LocalPrefix { get; set; }
        public static string DataPath { get; set; }

        public static string GetDataDirectory()
        {
            return IsClickOnce
                ? ApplicationDeployment.CurrentDeployment.DataDirectory
                : GetEntryAssemblyDirectory();
        }

        public static string GetFile(string fileName, string directoryName)
        {
            if (DataPath != null)
                return Path.Combine(DataPath, fileName);
            var dataDirectory = GetDataDirectory();
            if (dataDirectory == null) return null;
            var dirName = Path.GetFullPath(dataDirectory);
            for (var n = 0; n < 9; n++)
            {
                var path = dirName + "\\" + directoryName + "\\" + fileName;
                try
                {
                    if (File.Exists(path) || Directory.Exists(path))
                        return path;
                }
                catch
                {
                }
                dirName += @"\..";
            }
            throw new FileNotFoundException(string.Format("{0} not found. ({1})", fileName, dirName));
        }

        public static string GetDirectory(string directoryName)
        {
            var dataDirectory = GetDataDirectory();
            if (dataDirectory == null) return null;
            var dirName = Path.GetFullPath(dataDirectory);
            for (var n = 0; n < 9; n++)
            {
                var path = dirName + "\\" + directoryName;
                try
                {
                    if (Directory.Exists(path))
                        return path;
                }
                catch
                {
                }
                dirName += @"\..";
            }
            throw new DirectoryNotFoundException(directoryName + " not found");
        }

        public static void SetWebBrowserMode()
        {
            try
            {
                var key =
                    Registry.CurrentUser.OpenSubKey(
                        @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                if (key == null)
                    key =
                        Registry.CurrentUser.CreateSubKey(
                            @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION");
                if (key != null)
                    key.SetValue(Path.GetFileName(Process.GetCurrentProcess().ProcessName + ".exe"), 0,
                        RegistryValueKind.DWord);
            }
            catch
            {
            }
        }

        public static string GetFileLocalCopy(string fileName, string directoryName)
        {
            if (string.IsNullOrEmpty(LocalPrefix))
                throw new InvalidOperationException();
            var localName = LocalPrefix + fileName;
            var filePath = GetFile(fileName, directoryName);
            var fileDirectoryPath = Path.GetDirectoryName(filePath);
            var localFilePath = Path.Combine(fileDirectoryPath, localName);
            if (File.Exists(localFilePath)) return localFilePath;
            File.Copy(filePath, localFilePath);
            var attributes = File.GetAttributes(localFilePath);
            if ((attributes & FileAttributes.ReadOnly) != 0)
                File.SetAttributes(localFilePath, attributes & ~FileAttributes.ReadOnly);
            return localFilePath;
        }

        public static IDisposable SingleInstanceApplicationGuard(string applicationName, out bool exit)
        {
            var mutex = new Mutex(true, applicationName + AssemblyInfo.VersionShort);
            if (mutex.WaitOne(0, false))
            {
                exit = false;
            }
            else
            {
                var current = Process.GetCurrentProcess();
                foreach (var process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id && process.MainWindowHandle != IntPtr.Zero)
                    {
                        WinApiHelper.SetForegroundWindow(process.MainWindowHandle);
                        WinApiHelper.RestoreWindowAsync(process.MainWindowHandle);
                        break;
                    }
                }
                exit = true;
            }
            return mutex;
        }

        private static string GetEntryAssemblyDirectory()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null) return null;
            var appPath = entryAssembly.Location;
            return Path.GetDirectoryName(appPath);
        }

        private static class WinApiHelper
        {
            [SecuritySafeCritical]
            public static bool SetForegroundWindow(IntPtr hwnd)
            {
                return Import.SetForegroundWindow(hwnd);
            }

            [SecuritySafeCritical]
            public static bool RestoreWindowAsync(IntPtr hwnd)
            {
                return Import.ShowWindowAsync(hwnd,
                    IsMaxmimized(hwnd)
                        ? (int) Import.ShowWindowCommands.ShowMaximized
                        : (int) Import.ShowWindowCommands.Restore);
            }

            [SecuritySafeCritical]
            public static bool IsMaxmimized(IntPtr hwnd)
            {
                var placement = new Import.WINDOWPLACEMENT();
                placement.length = Marshal.SizeOf(placement);
                if (!Import.GetWindowPlacement(hwnd, ref placement)) return false;
                return placement.showCmd == Import.ShowWindowCommands.ShowMaximized;
            }

            private static class Import
            {
                public enum ShowWindowCommands
                {
                    Hide = 0,
                    Normal = 1,
                    ShowMinimized = 2,
                    ShowMaximized = 3,
                    ShowNoActivate = 4,
                    Show = 5,
                    Minimize = 6,
                    ShowMinNoActive = 7,
                    ShowNA = 8,
                    Restore = 9,
                    ShowDefault = 10,
                    ForceMinimize = 11
                }

                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool SetForegroundWindow(IntPtr hWnd);

                [DllImport("user32.dll")]
                public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

                [StructLayout(LayoutKind.Sequential)]
                public struct WINDOWPLACEMENT
                {
                    public int length;
                    public readonly int flags;
                    public readonly ShowWindowCommands showCmd;
                    public readonly Point ptMinPosition;
                    public readonly Point ptMaxPosition;
                    public readonly Rectangle rcNormalPosition;
                }
            }
        }
    }
}