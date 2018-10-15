using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimMaker_v2
{
    public partial class Parameters : Form
    {
        public Parameters()
        {
            InitializeComponent();
            autoFilePath.Text = Program.Settings.AutoFilePath;
            autoFileSave.Checked = Program.Settings.AutoFileSave;
            autoFileTime.Value = (decimal)Program.Settings.AutoFileTime.TotalMinutes;
            autoFileSave_CheckedChanged(null, null);
            long size = 0;
            if (!System.IO.Directory.Exists(Program.Settings.AutoFilePath))
                System.IO.Directory.CreateDirectory(Program.Settings.AutoFilePath);
            foreach (var item in new System.IO.DirectoryInfo(Program.Settings.AutoFilePath).GetFiles())
                size += item.Length;
            cleanFolder.Text = "Vider le dosser (" + ((double)size / 1024 / 1024).ToString("F") + " Mo)";
        }

        private void Parameters_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (System.IO.Directory.Exists(autoFilePath.Text))
                Program.Settings.AutoFilePath = autoFilePath.Text;
            Program.Settings.AutoFileSave = autoFileSave.Checked;
            Program.Settings.AutoFileTime = TimeSpan.FromMinutes((double)autoFileTime.Value);
            using (var stream = new System.IO.FileStream(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnimMakerV2\\params"), System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                formatter.Serialize(stream, Program.Settings);
            }
        }

        private void autoFileSave_CheckedChanged(object sender, EventArgs e)
        {
            autoFilePath.Enabled = autoFileSave.Checked;
            autoFileTime.Enabled = autoFileSave.Checked;
            searchFolder.Enabled = autoFileSave.Checked;
            label1.Enabled = autoFileSave.Checked;
            label2.Enabled = autoFileSave.Checked;
            label3.Enabled = autoFileSave.Checked;
        }

        private void cleanFolder_Click(object sender, EventArgs e)
        {
            foreach (var item in new System.IO.DirectoryInfo(Program.Settings.AutoFilePath).GetFiles())
            {
                item.Delete();
            }
            long size = 0;
            foreach (var item in new System.IO.DirectoryInfo(Program.Settings.AutoFilePath).GetFiles())
                size += item.Length;
            cleanFolder.Text = "Vider le dosser (" + ((double)size / 1024 / 1024).ToString("F") + " Mo)";
        }

        private void searchFolder_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = autoFilePath.Text;
            dialog.Description = "Choisissez le dossier de sauvegardes automatiques";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                autoFilePath.Text = dialog.SelectedPath;
            }
        }
    }
}
