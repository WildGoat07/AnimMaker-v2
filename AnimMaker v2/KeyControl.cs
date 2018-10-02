using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;

namespace AnimMaker_v2
{
    class KeyControl : Transformable, Drawable
    {
        private ConvexShape array;
        public Color Color { get => array.FillColor; set => array.FillColor = value; }
        public IHitbox HitBox { get; }
        public IHitbox GlobalHitBox => Transform.TransformHitbox(HitBox);
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(array, states);
        }
        public KeyControl(float size)
        {
            array = new ConvexShape(8);
            array.SetPoint(0, new Vector2f(0, -size));
            array.SetPoint(1, new Vector2f(.3f * size, -.3f * size));
            array.SetPoint(2, new Vector2f(size, 0));
            array.SetPoint(3, new Vector2f(.3f * size, .3f * size));
            array.SetPoint(4, new Vector2f(0, size));
            array.SetPoint(5, new Vector2f(-.3f * size, .3f * size));
            array.SetPoint(6, new Vector2f(-size, 0));
            array.SetPoint(7, new Vector2f(-.3f * size, -.3f * size));
            array.OutlineColor = Color.Black;
            array.OutlineThickness = -1f;

            var tmp = new CustomHitbox();
            for(uint i = 0;i<8;i++)
            {
                tmp.CustomShape.Add(array.GetPoint(i));
            }
            HitBox = tmp;
        }
    }
}
