using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WGP;
using WGP.SFDynamicObject;
using SFML.System;
using SFML.Graphics;

namespace AnimMaker_v2
{
    public partial class FunctionDialog : Form
    {
        public Animation.Key.Fct Function { get; set; }
        public float Coefficient { get; set; }
        private RenderWindow App { get; }
        public FunctionDialog()
        {
            InitializeComponent();
            Function = Animation.Key.Fct.LINEAR;
            var tmp = new DrawingSurface();
            tmp.Dock = DockStyle.Fill;
            App = tmp.Target;
            preview.Controls.Add(tmp);
            App.Resized += (sender, e) =>
            {
                App.SetView(new SFML.Graphics.View(new FloatRect(0, 0, e.Width, e.Height)));
            };
            App.SetFramerateLimit(10);
            
        }
        public void Start()
        {
            switch (Function)
            {
                case Animation.Key.Fct.LINEAR:
                    linear.Checked = true;
                    break;
                case Animation.Key.Fct.POWER:
                    pow.Checked = true;
                    break;
                case Animation.Key.Fct.ROOT:
                    root.Checked = true;
                    break;
                case Animation.Key.Fct.GAUSS:
                    gauss.Checked = true;
                    break;
                case Animation.Key.Fct.BINARY:
                    binary.Checked = true;
                    break;
            }
            coeff.Value = (decimal)Coefficient.Capped(1, 9999);

            Program.form.Enabled = false;
            Show(Program.form);
            var array = new VertexArray(PrimitiveType.LineStrip);

            while (Visible)
            {
                Application.DoEvents();
                App.DispatchEvents();

                array.Clear();
                for(int i = 0;i<App.Size.X;i++)
                {
                    float y = 0;
                    switch (Function)
                    {
                        case Animation.Key.Fct.LINEAR:
                            y = Utilities.Interpolation(Utilities.Percent(i, 0, (int)App.Size.X - 1), App.Size.Y - 1, 1f);
                            break;
                        case Animation.Key.Fct.POWER:
                            y = new PowFunction(Coefficient).Interpolation(Utilities.Percent(i, 0, (int)App.Size.X - 1), App.Size.Y - 1, 1f);
                            break;
                        case Animation.Key.Fct.ROOT:
                            y = new PowFunction(1f / Coefficient).Interpolation(Utilities.Percent(i, 0, (int)App.Size.X - 1), App.Size.Y - 1, 1f);
                            break;
                        case Animation.Key.Fct.GAUSS:
                            y = new ProgressiveFunction(Coefficient).Interpolation(Utilities.Percent(i, 0, (int)App.Size.X - 1), App.Size.Y - 1, 1f);
                            break;
                        case Animation.Key.Fct.BINARY:
                            if (i > App.Size.X / 2)
                                y = 1;
                            else
                                y = App.Size.Y - 1;
                            break;
                    }
                    array.Append(new Vertex(new Vector2f(i, y), SFML.Graphics.Color.Black));
                }

                App.Clear(SFML.Graphics.Color.White);

                App.Draw(array);

                App.Display();
            }
            Program.form.Enabled = true;
        }

        private void linear_CheckedChanged(object sender, EventArgs e)
        {
            Function = Animation.Key.Fct.LINEAR;
            coeff.Enabled = false;
        }

        private void pow_CheckedChanged(object sender, EventArgs e)
        {
            Function = Animation.Key.Fct.POWER;
            coeff.Enabled = true;
        }

        private void root_CheckedChanged(object sender, EventArgs e)
        {
            Function = Animation.Key.Fct.ROOT;
            coeff.Enabled = true;
        }

        private void binary_CheckedChanged(object sender, EventArgs e)
        {
            Function = Animation.Key.Fct.BINARY;
            coeff.Enabled = false;
        }

        private void gauss_CheckedChanged(object sender, EventArgs e)
        {
            Function = Animation.Key.Fct.GAUSS;
            coeff.Enabled = true;
        }

        private void coeff_ValueChanged(object sender, EventArgs e)
        {
            Coefficient = (float)coeff.Value;
        }
    }
}
