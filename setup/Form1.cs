using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace setup
{
    public partial class Form1 : Form
    {
        private bool mouseDown;
        private Point lastLoc;

        public Form1()
        {
            InitializeComponent();
            mouseDown = false;
            pathBox.Text = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "WildGoat Company\\AnimMaker v2");
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLoc = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLoc.X) + e.X, (Location.Y - lastLoc.Y) + e.Y);

                Update();
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "Chemin d'installation";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pathBox.Text = System.IO.Path.Combine(dialog.SelectedPath, "WildGoat Company\\AnimMaker v2");
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var Path = pathBox.Text;
                System.IO.Directory.CreateDirectory(Path);
                foreach (var file in Program.files)
                {
                    using (var stream = new System.IO.FileStream(System.IO.Path.Combine(Path, file.Name), System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    {
                        file.stream.CopyTo(stream);
                    }
                }
                var reg = Registry.LocalMachine;
                if (userOnly.Checked)
                    reg = Registry.CurrentUser;

                reg.CreateSubKey(@"Software\Classes\.wgdot").SetValue("", "AnimMakerV2.wgdot");

                reg.CreateSubKey(@"Software\Classes\AnimMakerV2.wgdot").SetValue("", "fichier de modèle dynamique");
                reg.CreateSubKey(@"Software\Classes\AnimMakerV2").SetValue("Path", Path);

                reg.CreateSubKey(@"Software\Classes\AnimMakerV2.wgdot\DefaultIcon").SetValue("", System.IO.Path.Combine(Path, "wgdo.ico"));

                reg.CreateSubKey(@"Software\Classes\AnimMakerV2.wgdot\shell\open\command").
                    SetValue("", "\"" + System.IO.Path.Combine(Path, "AnimMaker v2.exe") + "\" \"%1\"");

                if (addQuickStart.Checked)
                {
                    var qs = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
                    if (userOnly.Checked)
                        qs = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);
                    Console.WriteLine(qs);
                    {
                        string shortcutAddress = System.IO.Path.Combine(qs, "Programs", "AnimMaker v2.lnk");
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                        shortcut.Description = "Utilisé pour créer des objets animés";
                        shortcut.TargetPath = System.IO.Path.Combine(Path, "AnimMaker v2.exe");
                        shortcut.Save();
                    }
                }
                if (createLink.Checked)
                {
                    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                    {
                        string shortcutAddress = System.IO.Path.Combine(desktop, "AnimMaker v2.lnk");
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
                        shortcut.Description = "Utilisé pour créer des objets animés";
                        shortcut.TargetPath = System.IO.Path.Combine(Path, "AnimMaker v2.exe");
                        shortcut.Save();
                    }
                }
                MessageBox.Show(this, "AnimMaker v2 a été sinstallé avec succès", "Installation terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(0);
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show(this, "Chemin introuvable", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}