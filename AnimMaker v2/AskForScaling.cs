using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SFML.Graphics;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;

namespace AnimMaker_v2
{
    public partial class AskForScaling : Form
    {
        public AskForScaling()
        {
            InitializeComponent();

            if (Program.selection != null)
            {
                var anim = (Animation)Program.selection;

                oldTime.Text = anim.Duration.AsSeconds().ToString("F");
                newTime.Value = (decimal)anim.Duration.AsSeconds();
                NewFactor.Text = "100,00%";

                newTime.Focus();
                newTime.Select(0, newTime.Text.Length);
            }
        }

        private void newTime_ValueChanged(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;
            if (anim.Duration != Time.Zero)
                NewFactor.Text = ((float)newTime.Value / anim.Duration.AsSeconds() * 100).ToString("F") + "%";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;
            float factor = 0;
            if (anim.Duration != Time.Zero)
                factor = (float)newTime.Value / anim.Duration.AsSeconds();
            if (newTime.Value == 0)
            {
                if (MessageBox.Show(this, "Voulez-vous vraiment mettre une durée de 0 secondes ? Les clés perderont leur position temporelle.", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    anim.Duration *= factor;
                    foreach (var bone in anim.Bones)
                    {
                        foreach (var key in bone.Value)
                        {
                            key.Position *= factor;
                        }
                    }
                    Close();
                }
            }
            else
            {
                anim.Duration *= factor;
                foreach (var bone in anim.Bones)
                {
                    foreach (var key in bone.Value)
                    {
                        key.Position *= factor;
                    }
                }
                Close();
            }
        }
    }
}
