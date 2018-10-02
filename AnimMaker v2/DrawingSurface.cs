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

namespace AnimMaker_v2
{
    public partial class DrawingSurface : UserControl
    {
        public RenderWindow Target { get; }
        public DrawingSurface()
        {
            InitializeComponent();
            Target = new RenderWindow(Handle);
            Target.SetVerticalSyncEnabled(true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
    }
}
