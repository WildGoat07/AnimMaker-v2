using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace setup
{
    internal static class Program
    {
        public static List<ToExtract> files;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            files = new List<ToExtract>();

            files.Add(new ToExtract() { Name = "AnimMaker v2.exe", stream = new System.IO.MemoryStream(Properties.Resources.AnimMaker_v2) });
            files.Add(new ToExtract() { Name = "csfml-graphics-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.csfml_graphics_2) });
            files.Add(new ToExtract() { Name = "csfml-system-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.csfml_system_2) });
            files.Add(new ToExtract() { Name = "csfml-window-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.csfml_window_2) });
            files.Add(new ToExtract() { Name = "sfmlnet-graphics-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.sfmlnet_graphics_2) });
            files.Add(new ToExtract() { Name = "sfmlnet-system-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.sfmlnet_system_2) });
            files.Add(new ToExtract() { Name = "sfmlnet-window-2.dll", stream = new System.IO.MemoryStream(Properties.Resources.sfmlnet_window_2) });
            files.Add(new ToExtract() { Name = "WGP.NET-SFDynamicObject.dll", stream = new System.IO.MemoryStream(Properties.Resources.WGP_NET_SFDynamicObject) });
            files.Add(new ToExtract() { Name = "WGP.NET-TEXT.dll", stream = new System.IO.MemoryStream(Properties.Resources.WGP_NET_TEXT) });
            files.Add(new ToExtract() { Name = "WildGoatPackage.NET.dll", stream = new System.IO.MemoryStream(Properties.Resources.WildGoatPackage_NET) });
            files.Add(new ToExtract() { Name = "wgdo.ico", stream = new System.IO.MemoryStream(Properties.Resources.wgdo) });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool uninstall = false;
            if (Registry.CurrentUser.OpenSubKey(@"Software\Classes\AnimMakerV2") != null)
                uninstall = true;
            if (Registry.LocalMachine.OpenSubKey(@"Software\Classes\AnimMakerV2") != null)
                uninstall = true;
            if (uninstall)
                Application.Run(new Form2());
            Application.Run(new Form1());
        }
    }

    public struct ToExtract
    {
        public string Name { get; set; }
        public System.IO.Stream stream { get; set; }
    }
}