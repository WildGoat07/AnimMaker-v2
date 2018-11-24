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
    public partial class SpriteProperties : UserControl
    {
        #region Private Fields

        private bool init;

        #endregion Private Fields

        #region Public Constructors

        public SpriteProperties()
        {
            init = false;
            InitializeComponent();
            var sprite = (DynamicSprite)Program.selection;

            if (sprite != null)
            {
                SizeX.Value = (decimal)sprite.InternalRect.Size.X;
                SizeY.Value = (decimal)sprite.InternalRect.Size.Y;
                TexPosX.Value = (decimal)sprite.InternalRect.TextureRect.Left;
                TexPosY.Value = (decimal)sprite.InternalRect.TextureRect.Top;
                TexSizeX.Value = (decimal)sprite.InternalRect.TextureRect.Width;
                TexSizeY.Value = (decimal)sprite.InternalRect.TextureRect.Height;
                selectedRes.Items.Add("Aucune ressource");
                int i = 1;
                foreach (var item in Program.DynamicObject.UsedResources)
                {
                    selectedRes.Items.Add(item.Name);
                    if (sprite.Resource != null && sprite.Resource.ID == item.ID)
                        selectedRes.SelectedIndex = i;
                    i++;
                }
                if (sprite.Resource == null)
                {
                    selectedRes.SelectedIndex = 0;
                    adapt.Enabled = false;
                }
            }
            init = true;
        }

        #endregion Public Constructors

        #region Private Methods

        private void adapt_Click(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;
            sprite.InternalRect.TextureRect = new IntRect(default, sprite.Resource.FrameSize);
            sprite.InternalRect.Size = (Vector2f)sprite.Resource.FrameSize;

            Program.form.UpdateProp();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.TextureRect;
            vec.Left = (int)TexPosX.Value;
            sprite.InternalRect.TextureRect = vec;
        }

        private void selectedRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init)
            {
                var sprite = (DynamicSprite)Program.selection;
                if (selectedRes.SelectedIndex == 0)
                {
                    sprite.Resource = null;
                }
                else
                {
                    var selection = (string)selectedRes.Items[selectedRes.SelectedIndex];
                    var res = Program.DynamicObject.UsedResources.Find((r) => r.Name == selection);
                    sprite.Resource = res;
                    sprite.InternalRect.Size = (Vector2f)sprite.Resource.FrameSize;
                    sprite.InternalRect.TextureRect = new IntRect(default, sprite.Resource.FrameSize);
                }

                Program.form.UpdateProp();
            }
        }

        private void SizeX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.Size;
            vec.X = (float)SizeX.Value;
            sprite.InternalRect.Size = vec;
        }

        private void SizeY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.Size;
            vec.Y = (float)SizeY.Value;
            sprite.InternalRect.Size = vec;
        }

        private void TexPosY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.TextureRect;
            vec.Top = (int)TexPosY.Value;
            sprite.InternalRect.TextureRect = vec;
        }

        private void TexSizeX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.TextureRect;
            vec.Width = (int)TexSizeX.Value;
            sprite.InternalRect.TextureRect = vec;
        }

        private void TexSizeY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (DynamicSprite)Program.selection;

            var vec = sprite.InternalRect.TextureRect;
            vec.Height = (int)TexSizeY.Value;
            sprite.InternalRect.TextureRect = vec;
        }

        #endregion Private Methods
    }
}