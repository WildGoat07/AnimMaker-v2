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
using WGP.SFDynamicObject;
using SFML.System;
using WGP;

namespace AnimMaker_v2
{
    public partial class ResourceStep12 : UserControl
    {
        #region Public Fields

        public Vector2i size;
        public Vector2i[] pos;
        public int fpsCount;

        #endregion Public Fields

        #region Private Fields

        private DrawingSurface Disp;

        private Texture img;

        #endregion Private Fields

        #region Public Constructors

        public ResourceStep12(Resource res, Vector2i s, int frames)
        {
            fpsCount = frames;
            size = s;
            Finished = false;
            InitializeComponent();
            Dock = DockStyle.Fill;
            img = new Texture(res.BaseImage);
            SizeX.Value = (decimal)size.X;
            SizeY.Value = (decimal)size.Y;
            fps.Value = (decimal)fpsCount;
            var thread = new System.Threading.Thread(UpdateDisp);
            Disp = new DrawingSurface();
            Disp.Dock = DockStyle.Fill;
            dispPanel.Controls.Add(Disp);
            Disp.Target.SetActive(false);
            thread.Start();
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Finished { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void SizeX_ValueChanged(object sender, EventArgs e)
        {
            size.X = (int)SizeX.Value;
        }

        private void SizeY_ValueChanged(object sender, EventArgs e)
        {
            size.Y = (int)SizeY.Value;
        }

        private void UpdateDisp()
        {
            var sprite = new Sprite(img);
            List<Vector2i> positions = new List<Vector2i>();
            List<Vertex> vertices = new List<Vertex>();
            while (!Finished)
            {
                Disp.Target.SetActive();
                {
                    Disp.Target.Size = new Vector2u((uint)Disp.Size.Width, (uint)Disp.Size.Height);
                    FloatRect max;
                    {
                        List<Vector2f> outlines = new List<Vector2f>();
                        outlines.Add(sprite.GetGlobalBounds().TopLeft());
                        outlines.Add(sprite.GetGlobalBounds().TopRight());
                        outlines.Add(sprite.GetGlobalBounds().BotLeft());
                        outlines.Add(sprite.GetGlobalBounds().BotRight());
                        max = Utilities.CreateRect(outlines);
                    }
                    Vector2f HalfSize = new Vector2f(Disp.Size.Width, Disp.Size.Height) / 2;
                    Vector2f HalfImgSize = (Vector2f)img.Size / 2;
                    float facX = Utilities.Max(Utilities.Max(-max.Left + HalfImgSize.X, max.Right() - HalfImgSize.X) / HalfSize.X, 1) * 1.03f;
                    float facY = Utilities.Max(Utilities.Max(-max.Top + HalfImgSize.Y, max.Bot() - HalfImgSize.Y) / HalfSize.Y, 1) * 1.03f;
                    FloatRect rectView = new FloatRect(default, new Vector2f(Disp.Size.Width * Utilities.Max(facX, facY), Disp.Size.Height * Utilities.Max(facX, facY)));
                    Disp.Target.SetView(new SFML.Graphics.View(rectView)
                    {
                        Center = (Vector2f)img.Size / 2
                    });
                }
                int x = 0, y = 0;
                positions.Clear();
                if (size.X > 0 && size.Y > 0)
                {
                    do
                    {
                        x = 0;
                        do
                        {
                            positions.Add(new Vector2i(x, y));
                            x += size.X;
                        } while (x + size.X <= img.Size.X);
                        y += size.Y;
                    } while (y + size.Y <= img.Size.Y);
                }
                pos = positions.ToArray();
                vertices.Clear();
                foreach (var p in positions)
                {
                    vertices.Add(new Vertex(new Vector2f(p.X + size.X, p.Y + size.Y), SFML.Graphics.Color.White));
                    vertices.Add(new Vertex(new Vector2f(p.X, p.Y + size.Y), SFML.Graphics.Color.White));
                    vertices.Add(new Vertex(new Vector2f(p.X, p.Y + size.Y), SFML.Graphics.Color.White));
                    vertices.Add(new Vertex(new Vector2f(p.X, p.Y), SFML.Graphics.Color.White));
                }

                Disp.Target.Clear(SFML.Graphics.Color.White);

                Disp.Target.Draw(sprite);
                Disp.Target.Draw(vertices.ToArray(), PrimitiveType.Lines, new RenderStates(new BlendMode(BlendMode.Factor.OneMinusDstColor, BlendMode.Factor.OneMinusSrcColor)));

                Disp.Target.Display();
            }
        }

        #endregion Private Methods

        private void fps_ValueChanged(object sender, EventArgs e)
        {
            fpsCount = (int)fps.Value;
        }
    }
}