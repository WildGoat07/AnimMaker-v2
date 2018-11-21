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
        #region Public Constructors

        public SpriteProperties()
        {
            InitializeComponent();
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            if (sprite != null)
            {
                SizeX.Value = (decimal)sprite.Value.Size.X;
                SizeY.Value = (decimal)sprite.Value.Size.Y;
                TexPosX.Value = (decimal)sprite.Value.TextureRect.Left;
                TexPosY.Value = (decimal)sprite.Value.TextureRect.Top;
                TexSizeX.Value = (decimal)sprite.Value.TextureRect.Width;
                TexSizeY.Value = (decimal)sprite.Value.TextureRect.Height;
            }
        }

        #endregion Public Constructors

        #region Private Methods

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.TextureRect;
            vec.Left = (int)TexPosX.Value;
            sprite.Value.TextureRect = vec;
        }

        private void SizeX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Size;
            vec.X = (float)SizeX.Value;
            sprite.Value.Size = vec;
        }

        private void SizeY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Size;
            vec.Y = (float)SizeY.Value;
            sprite.Value.Size = vec;
        }

        private void TexPosY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.TextureRect;
            vec.Top = (int)TexPosY.Value;
            sprite.Value.TextureRect = vec;
        }

        private void TexSizeX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.TextureRect;
            vec.Width = (int)TexSizeX.Value;
            sprite.Value.TextureRect = vec;
        }

        private void TexSizeY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.TextureRect;
            vec.Height = (int)TexSizeY.Value;
            sprite.Value.TextureRect = vec;
        }

        #endregion Private Methods
    }
}