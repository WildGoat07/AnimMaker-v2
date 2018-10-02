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
        public BoneProperties()
        {
            InitializeComponent();
            if (Program.selection != null)
            {
                var bone = (Bone)Program.selection;

                boneName.Text = bone.Name;

                PosX.Value = (decimal)bone.Position.X;
                PosY.Value = (decimal)bone.Position.Y;
                OriginX.Value = (decimal)bone.Origin.X;
                OriginY.Value = (decimal)bone.Origin.Y;
                ScaleX.Value = (decimal)bone.Scale.X;
                ScaleY.Value = (decimal)bone.Scale.Y;
                Rotation.Value = (decimal)bone.Rotation;
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
                removeSprite.Enabled = false;
                moveSpriteUp.Enabled = false;
                moveSpriteDown.Enabled = false;
                addChild.Enabled = false;
                modSprite.Enabled = false;
                addSprite.Enabled = false;

                children.Items.Clear();
                foreach (var child in bone.ChildBones)
                {
                    children.Items.Add(child.Name);
                }
                addChildList.Items.Clear();
                addChildList.Items.Add("Selectionner un enfant");
                addChildList.SelectedIndex = 0;
                foreach (var globalBone in Program.DynamicObject.MasterBones)
                {
                    if (globalBone != bone)
                    {
                        if (!boneContainChild(globalBone, bone))
                            addChildList.Items.Add(globalBone.Name);
                    }
                }
                sprites.Items.Clear();
                int sprCount = 1;
                foreach (var spr in bone.AttachedSprites.AsEnumerable().Reverse())
                {
                    sprites.Items.Add(sprCount.ToString("00") + spr.Key);
                    sprCount++;
                }
                addSpriteList.Items.Clear();
                addSpriteList.Items.Add("Selectionner un sprite");
                addSpriteList.SelectedIndex = 0;
                foreach (var tex in Program.Resources)
                {
                    if (tex.Value.Data is Texture)
                        addSpriteList.Items.Add(tex.Key);
                }
            }
        }
        public static bool boneContainChild(Bone master, Bone child)
        {
            if (master.ChildBones != null)
            {
                if (master.ChildBones.Contains(child))
                    return true;
                foreach (var childBone in master.ChildBones)
                {
                    if (boneContainChild(childBone, child))
                        return true;
                }
            }
            return false;
        }

        private void children_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeChild.Enabled = children.SelectedIndex != -1;
        }

        private void sprites_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeSprite.Enabled = sprites.SelectedIndex != -1;
            moveSpriteUp.Enabled = sprites.SelectedIndex > 0;
            moveSpriteDown.Enabled = sprites.SelectedIndex != -1 && sprites.SelectedIndex < sprites.Items.Count - 1;
            if (sprites.SelectedIndex != -1)
                modSprite.Enabled = true;
            else
                modSprite.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var child = Program.DynamicObject.BonesHierarchy.Find((bone) => bone.Name == addChildList.Items[addChildList.SelectedIndex].ToString());
            Program.DynamicObject.MasterBones.Remove(child);
            var selectedBone = (Bone)Program.selection;
            selectedBone.ChildBones.Add(child);

            Program.form.UpdateInterface();
        }

        private void addChildList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addChild.Enabled = addChildList.SelectedIndex > 0;
        }

        private void addSprite_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            if (addSpriteList.SelectedIndex > 0)
            {
                var tex = Program.Resources.First((pair) => pair.Key == addSpriteList.Items[addSpriteList.SelectedIndex].ToString());
                bone.AttachedSprites.Add(new Couple<string, RectangleShape>(tex.Key, new RectangleShape(new Vector2f(((Texture)tex.Value.Data).Size.X, ((Texture)tex.Value.Data).Size.Y))
                {
                    Texture = (Texture)tex.Value.Data
                }));
            }


            Program.form.UpdateProp();
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

        private void Rotation_ValueChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.Rotation = (float)Rotation.Value;
        }

        private void removeChild_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            var target = bone.ChildBones.Find((child) => child.Name == children.Items[children.SelectedIndex].ToString());
            bone.ChildBones.Remove(target);
            Program.DynamicObject.MasterBones.Add(target);

            Program.form.UpdateInterface();
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

        private void boneName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Shift && !e.Control && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void moveSpriteUp_Click(object sender, EventArgs e)
        {
            var oldSelect = sprites.SelectedIndex;
            var bone = (Bone)Program.selection;
            var index = ((Bone)Program.selection).AttachedSprites.Count - int.Parse(sprites.Items[sprites.SelectedIndex].ToString().Substring(0, 2));
            var selectedSprite = bone.AttachedSprites[index];
            bone.AttachedSprites.Remove(selectedSprite);
            bone.AttachedSprites.Insert(index + 1, selectedSprite);

            sprites.Items.Clear();
            int sprCount = 1;
            foreach (var spr in bone.AttachedSprites.AsEnumerable().Reverse())
            {
                sprites.Items.Add(sprCount.ToString("00") + spr.Key);
                sprCount++;
            }
            sprites.SelectedIndex = oldSelect - 1;
        }

        private void removeSprite_Click(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;

            var index = ((Bone)Program.selection).AttachedSprites.Count - int.Parse(sprites.Items[sprites.SelectedIndex].ToString().Substring(0, 2));
            bone.AttachedSprites.RemoveAt(index);


            Program.form.UpdateProp();
        }

        private void moveSpriteDown_Click(object sender, EventArgs e)
        {
            var oldSelect = sprites.SelectedIndex;
            var bone = (Bone)Program.selection;
            var index = ((Bone)Program.selection).AttachedSprites.Count - int.Parse(sprites.Items[sprites.SelectedIndex].ToString().Substring(0, 2));
            var selectedSprite = bone.AttachedSprites[index];
            bone.AttachedSprites.Remove(selectedSprite);
            bone.AttachedSprites.Insert(index - 1, selectedSprite);

            sprites.Items.Clear();
            int sprCount = 1;
            foreach (var spr in bone.AttachedSprites.AsEnumerable().Reverse())
            {
                sprites.Items.Add(sprCount.ToString("00") + spr.Key);
                sprCount++;
            }
            sprites.SelectedIndex = oldSelect + 1;
        }

        private void addSpriteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addSpriteList.SelectedIndex != 0)
                addSprite.Enabled = true;
            else
                addSprite.Enabled = false;

        }

        private void modSprite_Click(object sender, EventArgs e)
        {
            var index = ((Bone)Program.selection).AttachedSprites.Count - int.Parse(sprites.Items[sprites.SelectedIndex].ToString().Substring(0, 2));
            Program.selection = ((Bone)Program.selection).AttachedSprites[index];

            Program.form.UpdateInterface();
        }

        private void alphaMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_ALPHA;
        }

        private void multMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_MULT;
        }

        private void subsMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_SUB;
        }

        private void addMode_CheckedChanged(object sender, EventArgs e)
        {
            var bone = (Bone)Program.selection;
            bone.BlendMode = BlendModeType.BLEND_ADD;
        }
    }
}
