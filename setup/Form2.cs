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
    public partial class Form2 : Form
    {
        private bool mouseDown;
        private Point lastLoc;
        public Form2()
        {
            InitializeComponent();
            mouseDown = false;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLoc = e.Location;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLoc.X) + e.X, (Location.Y - lastLoc.Y) + e.Y);

                Update();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string Path;
            RegistryKey reg;
            if (Registry.CurrentUser.OpenSubKey(@"Software\Classes\AnimMakerV2") == null)
                reg = Registry.LocalMachine.OpenSubKey(@"Software\Classes", true);
            else
                reg = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);

            reg.DeleteSubKeyTree(@".wgdo");
            Console.WriteLine("deleted .wgdo");
            reg.DeleteSubKeyTree(@".resm");
            Console.WriteLine("deleted .resm");
            reg.DeleteSubKeyTree(@"AnimMakerV2.wgdo");
            Console.WriteLine("deleted AnimMakerV2.wgdo");
            reg.DeleteSubKeyTree(@"AnimMakerV2.resm");
            Console.WriteLine("deleted AnimMakerV2.resm");
            Path = reg.OpenSubKey(@"AnimMakerV2").GetValue("Path").ToString();
            reg.DeleteSubKeyTree(@"AnimMakerV2");
            Console.WriteLine("deleted AnimMakerV2");
            System.IO.Directory.Delete(Path, true);
            MessageBox.Show(this, "AnimMaker v2 a été désinstallé avec succès", "Désinstallation terminée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
