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
using WGP.SFDynamicObject;
using SFML.System;
using SFML.Graphics;

namespace AnimMaker_v2
{
    public partial class AnimProperties : UserControl
    {
        public AnimProperties()
        {
            InitializeComponent();

            if (Program.selection != null)
            {
                var anim = (Animation)Program.selection;
                addBone.Enabled = false;
                removeBone.Enabled = false;
                selectKeys.Enabled = false;

                animName.Text = anim.Name;
                Duration.Value = (decimal)anim.Duration.AsSeconds();
                List<string> contained = new List<string>();
                foreach (var couple in anim.Bones)
                {
                    bones.Items.Add(couple.Key);
                    contained.Add(couple.Key);
                }
                bonesList.Items.Add("Selectionner un os");
                bonesList.SelectedIndex = 0;
                bonesList.Items.AddRange(Program.DynamicObject.BonesHierarchy.ConvertAll((b) => b.Name).Except(contained).ToArray());
            }
        }

        private void animName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void animName_Validated(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Name = animName.Text;

            Program.form.UpdateInterface();
        }

        private void Duration_ValueChanged(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Duration = Time.FromSeconds((float)Duration.Value);
        }

        private void bones_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectKeys.Enabled = bones.SelectedIndex != -1;
            removeBone.Enabled = bones.SelectedIndex != -1;

            Program.selectedBone = Program.DynamicObject.BonesHierarchy.Find((bone) => bone.Name == bones.Items[bones.SelectedIndex].ToString());
        }

        private void removeBone_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Bones.RemoveAll((couple) => couple.Key == bones.Items[bones.SelectedIndex].ToString());

            Program.form.UpdateProp();
        }

        private void bonesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addBone.Enabled = bonesList.SelectedIndex > 0;
        }

        private void addBone_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Bones.Add(new Couple<string, List<Animation.Key>>(bonesList.Items[bonesList.SelectedIndex].ToString(), new List<Animation.Key>()));

            Program.form.UpdateProp();
        }

        private void selectKeys_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            Program.selection = anim.Bones.Find((couple) => couple.Key == bones.Items[bones.SelectedIndex].ToString()).Value;

            Program.form.UpdateProp();
        }
    }
}
