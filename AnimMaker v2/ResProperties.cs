using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WGP;
using SFML.System;
using SFML.Graphics;
using WGP.SFDynamicObject;
using System.Diagnostics;

namespace AnimMaker_v2
{
    public partial class ResProperties : UserControl
    {
        #region Public Constructors

        private bool init;

        public ResProperties()
        {
            init = false;
            InitializeComponent();

            if (Program.selection != null)
            {
                var selectRes = (Resource)Program.selection;

                name.Text = selectRes.Name;
                if (selectRes.FramesPosition.Length > 1)
                    resourceMode.Text = "Texture animée";
                else
                    resourceMode.Text = "Texture fixe";
                smooth.Checked = selectRes.Smooth;
                repeated.Checked = selectRes.Repeated;
                img.Image = (Bitmap)selectRes.BaseImage;
            }
            init = true;
        }

        #endregion Public Constructors

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new EditResource();
            dialog.ShowDialog();

            Program.form.UpdateProp();
        }

        #endregion Private Methods

        private void name_Validated(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            if (res.Name != name.Text)
                res.Name = name.Text;
            Program.form.UpdateInterface();
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Shift && !e.Control && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void smooth_CheckedChanged(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            res.Smooth = smooth.Checked;
        }

        private void repeated_CheckedChanged(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            res.Repeated = repeated.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (exportPng.ShowDialog() == DialogResult.OK)
            {
                var res = (Resource)Program.selection;
                res.BaseImage.SaveToFile(exportPng.FileName);
            }
        }
    }
}