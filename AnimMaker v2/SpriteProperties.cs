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
        public SpriteProperties()
        {
            InitializeComponent();
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            if (sprite != null)
            {
                PosX.Value = (decimal)sprite.Value.Position.X;
                PosY.Value = (decimal)sprite.Value.Position.Y;
                OriginX.Value = (decimal)sprite.Value.Origin.X;
                OriginY.Value = (decimal)sprite.Value.Origin.Y;
                ScaleX.Value = (decimal)sprite.Value.Scale.X;
                ScaleY.Value = (decimal)sprite.Value.Scale.Y;
                Rotation.Value = (decimal)sprite.Value.Rotation;
                SizeX.Value = (decimal)sprite.Value.Size.X;
                SizeY.Value = (decimal)sprite.Value.Size.Y;
                TexPosX.Value = (decimal)sprite.Value.TextureRect.Left;
                TexPosY.Value = (decimal)sprite.Value.TextureRect.Top;
                TexSizeX.Value = (decimal)sprite.Value.TextureRect.Width;
                TexSizeY.Value = (decimal)sprite.Value.TextureRect.Height;
            }
        }

        private void PosX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Position;
            vec.X = (float)PosX.Value;
            sprite.Value.Position = vec;
        }

        private void PosY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Position;
            vec.Y = (float)PosY.Value;
            sprite.Value.Position = vec;
        }

        private void OriginX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Origin;
            vec.X = (float)OriginX.Value;
            sprite.Value.Origin = vec;
        }

        private void OriginY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Origin;
            vec.Y = (float)OriginY.Value;
            sprite.Value.Origin = vec;
        }

        private void ScaleX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Scale;
            vec.X = (float)ScaleX.Value;
            sprite.Value.Scale = vec;
        }

        private void ScaleY_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Scale;
            vec.Y = (float)ScaleY.Value;
            sprite.Value.Scale = vec;
        }

        private void Rotation_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            sprite.Value.Rotation = (float)Rotation.Value;
        }
        
        private void SizeX_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.Size;
            vec.X = (float)SizeX.Value;
            sprite.Value.Size = vec;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;

            var vec = sprite.Value.TextureRect;
            vec.Left = (int)TexPosX.Value;
            sprite.Value.TextureRect = vec;
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

        private void button1_Click(object sender, EventArgs e)
        {
            var sprite = (Couple<string, RectangleShape>)Program.selection;
            Program.selection = Program.Resources.First((res) => res.Key == sprite.Key);


            Program.form.UpdateProp();
        }
    }
}
