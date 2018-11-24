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
        #region Private Fields

        private VertexArray Lines;

        private Sprite maj;

        private Texture majDOWN;

        private Texture majUP;

        private Sprite ori;

        private Sprite pos;

        private Sprite rot;

        private Sprite sca;

        private Sprite x;

        private Texture xDOWN;

        private Texture xUP;

        private Sprite y;

        private Texture yDOWN;

        private Texture yUP;

        #endregion Private Fields

        #region Public Constructors

        public Gizmo()
        {
            Display = DisplayMode.NONE;
            pos = new Sprite(new Texture((Image)Properties.Resources.position) { Smooth = true });
            ori = new Sprite(new Texture((Image)Properties.Resources.origin) { Smooth = true });
            sca = new Sprite(new Texture((Image)Properties.Resources.scale) { Smooth = true });
            rot = new Sprite(new Texture((Image)Properties.Resources.rotation) { Smooth = true });
            x = new Sprite();
            y = new Sprite();
            maj = new Sprite();
            xUP = new Texture((Image)Properties.Resources.xUp) { Smooth = true };
            yUP = new Texture((Image)Properties.Resources.yUp) { Smooth = true };
            majUP = new Texture((Image)Properties.Resources.majUp) { Smooth = true };
            xDOWN = new Texture((Image)Properties.Resources.xDown) { Smooth = true };
            yDOWN = new Texture((Image)Properties.Resources.yDown) { Smooth = true };
            majDOWN = new Texture((Image)Properties.Resources.majDown) { Smooth = true };

            float size = pos.Texture.Size.X;
            pos.Position = new Vector2f(-2 * size - 6, -size * 2);
            ori.Position = new Vector2f(-size - 2, -size * 2);
            rot.Position = new Vector2f(2, -size * 2);
            sca.Position = new Vector2f(size + 6, -size * 2);

            Lines = new VertexArray();

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
            x.Position = new Vector2f(-15 - xUP.Size.X / 2, -size * 2 - 35);
            y.Position = new Vector2f(15 - xUP.Size.X / 2, -size * 2 - 35);
            maj.Position = new Vector2f(-xUP.Size.X / 2, -size * 2 - 35);
        }

        #endregion Public Constructors

        #region Public Enums

        public enum DisplayMode
        {
            XY,
            MAJ,
            NONE
        }

        public enum TransformType
        {
            NONE,
            POSITION,
            SCALE,
            ORIGIN,
            ROTATION
        }

        #endregion Public Enums

        #region Public Properties

        public DisplayMode Display { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                x.Texture = xDOWN;
            else
                x.Texture = xUP;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                y.Texture = yDOWN;
            else
                y.Texture = yUP;
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                maj.Texture = majDOWN;
            else
                maj.Texture = majUP;

            states.Transform *= Transform;

            target.Draw(Lines, states);
            target.Draw(pos, states);
            target.Draw(rot, states);
            target.Draw(sca, states);
            target.Draw(ori, states);
            if (Display == DisplayMode.MAJ)
                target.Draw(maj, states);
            else if (Display == DisplayMode.XY)
            {
                target.Draw(x, states);
                target.Draw(y, states);
            }
        }

        public TransformType GetSelection(Vector2f msPos)
        {
            msPos = InverseTransform.TransformPoint(msPos);
            if (pos.GetGlobalBounds().Contains(msPos)) return TransformType.POSITION;
            else if (rot.GetGlobalBounds().Contains(msPos)) return TransformType.ROTATION;
            else if (sca.GetGlobalBounds().Contains(msPos)) return TransformType.SCALE;
            else if (ori.GetGlobalBounds().Contains(msPos)) return TransformType.ORIGIN;
            else return TransformType.NONE;
        }

        #endregion Public Methods
    }
}