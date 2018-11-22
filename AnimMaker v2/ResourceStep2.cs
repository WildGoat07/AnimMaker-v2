using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;

namespace AnimMaker_v2
{
    public partial class ResourceStep2 : UserControl, Finishable
    {
        #region Public Fields

        public Vector2i pos;
        public Vector2i size;

        #endregion Public Fields

        #region Private Fields

        private DrawingSurface Disp;

        private Texture img;

        #endregion Private Fields

        #region Public Constructors

        public ResourceStep2(Resource res, Vector2i p, Vector2i s)
        {
            pos = p;
            size = s;
            Finished = false;
            InitializeComponent();
            Dock = DockStyle.Fill;
            img = new Texture(res.BaseImage);
            PosX.Value = (decimal)pos.X;
            PosY.Value = (decimal)pos.Y;
            SizeX.Value = (decimal)size.X;
            SizeY.Value = (decimal)size.Y;
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

        private void PosX_ValueChanged(object sender, EventArgs e)
        {
            pos.X = (int)PosX.Value;
        }

        private void PosY_ValueChanged(object sender, EventArgs e)
        {
            pos.Y = (int)PosY.Value;
        }

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
            var rect = new RectangleShape()
            {
                OutlineColor = SFML.Graphics.Color.White,
                FillColor = SFML.Graphics.Color.Black
            };
            while (!Finished)
            {
                Disp.Target.SetActive();
                {
                    Disp.Target.Size = new Vector2u((uint)Disp.Size.Width, (uint)Disp.Size.Height);
                    FloatRect max;
                    {
                        List<Vector2f> outlines = new List<Vector2f>();
                        outlines.Add(rect.GetGlobalBounds().TopLeft());
                        outlines.Add(rect.GetGlobalBounds().TopRight());
                        outlines.Add(rect.GetGlobalBounds().BotLeft());
                        outlines.Add(rect.GetGlobalBounds().BotRight());
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
                rect.OutlineThickness = Utilities.Max(Utilities.Max(img.Size.X, img.Size.Y) / 50f, 5);
                rect.Position = (Vector2f)pos;
                rect.Size = (Vector2f)size;

                Disp.Target.Clear(SFML.Graphics.Color.White);

                Disp.Target.Draw(sprite);
                Disp.Target.Draw(rect, new RenderStates(new BlendMode(BlendMode.Factor.OneMinusDstColor, BlendMode.Factor.OneMinusSrcColor)));

                Disp.Target.Display();
            }
        }

        #endregion Private Methods
    }
}