using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
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
    public partial class BoneProperties : UserControl
    {
        #region Public Constructors

        public BoneProperties()
        {
            InitializeComponent();
            if (Program.selection != null)
            {
                var bone = (Bone)Program.selection;

                boneName.Text = bone.Name;
                dispId.Text = "ID : " + bone.ID.ToString("D");
                PosX.Value = (decimal)bone.Position.X;
                PosY.Value = (decimal)bone.Position.Y;
                OriginX.Value = (decimal)bone.Origin.X;
                OriginY.Value = (decimal)bone.Origin.Y;
                ScaleX.Value = (decimal)bone.Scale.X;
                ScaleY.Value = (decimal)bone.Scale.Y;
                Rotation.Value = (decimal)bone.Rotation;
                if (bone.AttachedSprite != null)
                {
                    removeSprite.Enabled = true;
                    addSprite.Enabled = false;
                    spriteButton.Text = "Modifier le sprite";
                }
                else
                {
                    removeSprite.Enabled = false;
                    addSprite.Enabled = true;
                    spriteButton.Text = "Aucun sprite";
                    spriteButton.Enabled = false;
                }
                switch (bone.BlendMode)
                {
                    case BlendModeType.BLEND_ALPHA:
                        alphaMode.Checked = true;
                        break;

                    case BlendModeType.BLEND_ADD:
                        addMode.Checked = true;
                        break;

                    case BlendModeType.BLEND_MULT:
                        multMode.Checked = true;
                        break;

                    case BlendModeType.BLEND_SUB:
                        subsMode.Checked = true;
                        break;
                }

                boneStatut.Text = "Statut : ";
                if (Program.DynamicObject.MasterBones.Contains(Program.selection))
                    boneStatut.Text += "Racine";
                else
                    boneStatut.Text += "Enfant";

                removeChild.Enabled = false;

                children.Items.Clear();
                foreach (var child in bone.Children)
                {
                    children.Items.Add(new OrderedDisplayer(child));
                }
                addChildList.Items.Clear();
                addChildList.Items.Add("Selectionner un enfant");
                addChildList.SelectedIndex = 0;
                foreach (var globalBone in Program.DynamicObject.MasterBones)
                {
                    if (globalBone != bone)
                    {
                        if (!boneContainChild(globalBone, bone))
                            addChildList.Items.Add(new OrderedDisplayer(globalBone));
                    }
                }
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public static bool boneContainChild(Bone master, Bone child)
        {
            if (master.Children != null)
            {
                if (master.Children.Contains(child))
                    return true;
                foreach (var childBone in master.Children)
                {
                    if (boneContainChild(childBone, child))
                        return true;
                }
            }
            return false;
        }

        #endregion Public Methods

        #region Private Methods

        private void addChildList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addChild.Enabled = addChildList.SelectedIndex > 0;
        }

        private void addMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_ADD;
        }

        private void addSprite_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;

            bone.AttachedSprite = new DynamicSprite();

            Program.form.UpdateProp();
        }

        private void alphaMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_ALPHA;
        }

        private void boneName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Shift && !e.Control && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void boneName_Validated(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            if (bone.Name != boneName.Text)
            {
                bone.Name = boneName.Text;

                Program.form.UpdateInterface();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = Program.DynamicObject.BonesHierarchy.Find((bone) => bone.ID == ((dynamic)addChildList.Items[addChildList.SelectedIndex]).ID);
            Program.DynamicObject.MasterBones.Remove(child);
            var selectedBone = (Bone)Program.selection;
            selectedBone.Children.Add(child);

            Program.form.UpdateInterface();
        }

        private void children_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeChild.Enabled = children.SelectedIndex != -1;
        }

        private void multMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_MULT;
        }

        private void OriginX_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var orig = bone.Origin;
            orig.X = (float)OriginX.Value;
            bone.Origin = orig;
        }

        private void OriginY_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var orig = bone.Origin;
            orig.Y = (float)OriginY.Value;
            bone.Origin = orig;
        }

        private void PosX_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var pos = bone.Position;
            pos.X = (float)PosX.Value;
            bone.Position = pos;
        }

        private void PosY_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var pos = bone.Position;
            pos.Y = (float)PosY.Value;
            bone.Position = pos;
        }

        private void removeChild_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var target = bone.Children.Find((child) => child.ID == ((dynamic)children.Items[children.SelectedIndex]).ID);
            bone.Children.Remove(target);
            Program.DynamicObject.MasterBones.Add(target);

            Program.form.UpdateInterface();
        }

        private void removeSprite_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;

            bone.AttachedSprite = null;

            Program.form.UpdateProp();
        }

        private void Rotation_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.Rotation = (float)Rotation.Value;
        }

        private void ScaleX_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var scale = bone.Scale;
            scale.X = (float)ScaleX.Value;
            bone.Scale = scale;
        }

        private void ScaleY_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var scale = bone.Scale;
            scale.Y = (float)ScaleY.Value;
            bone.Scale = scale;
        }

        private void spriteButton_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            Program.selection = bone.AttachedSprite;

            Program.form.UpdateProp();
        }

        private void subsMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_SUB;
        }

        #endregion Private Methods
    }
}