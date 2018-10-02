using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimMaker_v2
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            titleText.Font = new Font("Calibri", 24);
            versionName.Text = Assembly.GetEntryAssembly().GetName().Version.ToString();
            Select();
        }

        private void AboutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                Close();
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
