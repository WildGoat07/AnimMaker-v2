using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;

namespace AnimMaker_v2
{
    internal class Gizmo : Transformable, Drawable
    {
        private Sprite pos;
        private Sprite ori;
        private Sprite sca;
        private Sprite rot;
        private VertexArray Lines;

        public Gizmo()
        {
            pos = new Sprite(new Texture((Image)Properties.Resources.position));
            ori = new Sprite(new Texture((Image)Properties.Resources.origin));
            sca = new Sprite(new Texture((Image)Properties.Resources.scale));
            rot = new Sprite(new Texture((Image)Properties.Resources.rotation));

            float size = pos.Texture.Size.X;
            pos.Position = new Vector2f(-2 * size - 10, -size * 2);
            ori.Position = new Vector2f(-size - 5, -size * 2);
            sca.Position = new Vector2f(5, -size * 2);
            rot.Position = new Vector2f(size + 10, -size * 2);

            Lines.PrimitiveType = PrimitiveType.Lines;
            Lines.Append(new Vertex(default, Color.Black));
            Lines.Append(new Vertex(pos.Position + new Vector2f(size / 2, size), Color.Black));
            Lines.Append(new Vertex(default, Color.Black));
            Lines.Append(new Vertex(ori.Position + new Vector2f(size / 2, size), Color.Black));
            Lines.Append(new Vertex(default, Color.Black));
            Lines.Append(new Vertex(sca.Position + new Vector2f(size / 2, size), Color.Black));
            Lines.Append(new Vertex(default, Color.Black));
            Lines.Append(new Vertex(rot.Position + new Vector2f(size / 2, size), Color.Black));
            Lines.Append(new Vertex(default, Color.Black));
        }

        public enum TransformType
        {
            NONE,
            POSITION,
            SCALE,
            ORIGIN,
            ROTATION
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
        }

        public TransformType GetSelection(Vector2f msPos)
        {
            msPos = InverseTransform.TransformPoint(msPos);
            return TransformType.NONE;
        }
    }
}