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
        #region Public Constructors

        public DrawingSurface()
        {
            InitializeComponent();
            Target = new RenderWindow(Handle);
            Target.SetVerticalSyncEnabled(true);
        }

        #endregion Public Constructors

        #region Public Properties

        public RenderWindow Target { get; }

        #endregion Public Properties

        #region Protected Methods

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }

        #endregion Protected Methods
    }
}