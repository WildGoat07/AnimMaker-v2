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
        #region Private Fields

        private bool init;

        #endregion Private Fields

        #region Public Constructors

        public ResProperties()
        {
            init = false;
            InitializeComponent();

            if (Program.selection != null)
            {
                var selectRes = (Resource)Program.selection;
                dispId.Text = "ID : " + selectRes.ID.ToString("D");
                name.Text = selectRes.Name;
                if (selectRes.FramesPosition.Length > 1)
                    resourceMode.Text = "Texture animée";
                else
                    resourceMode.Text = "Texture fixe";
                smooth.Checked = selectRes.Smooth;
                repeated.Checked = selectRes.Repeated;
                panel.Controls.Add(Program.form.resDispl);
                Program.form.resSprite.Resource = selectRes;
                Program.form.resSprite.InternalRect.Size = (Vector2f)selectRes.FrameSize;
                Program.form.resSprite.InternalRect.TextureRect = new IntRect(default, selectRes.FrameSize);
                Program.form.resDispl.Size = new Size(selectRes.FrameSize.X, selectRes.FrameSize.Y);
                Program.form.resDispl.Target.Size = (Vector2u)selectRes.FrameSize;
                Program.form.resDispl.Target.SetView(new SFML.Graphics.View(new FloatRect(default, (Vector2f)selectRes.FrameSize)));
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (exportPng.ShowDialog() == DialogResult.OK)
            {
                var res = (Resource)Program.selection;
                res.BaseImage.SaveToFile(exportPng.FileName);
            }
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Shift && !e.Control && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void name_Validated(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            if (res.Name != name.Text)
                res.Name = name.Text;
            Program.form.UpdateInterface();
        }

        private void repeated_CheckedChanged(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            res.Repeated = repeated.Checked;
        }

        private void smooth_CheckedChanged(object sender, EventArgs e)
        {
            var res = (Resource)Program.selection;
            res.Smooth = smooth.Checked;
        }

        #endregion Private Methods
    }
}