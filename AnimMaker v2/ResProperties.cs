using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WGP;
using SFML.System;
using SFML.Graphics;
using WGP.SFDynamicObject;
using System.Diagnostics;

namespace AnimMaker_v2
{
    public partial class ResProperties : UserControl
    {
        #region Public Constructors

        public ResProperties()
        {
            InitializeComponent();

            if (Program.selection != null)
            {
                var selectRes = (Resource)Program.selection;

                name.Text = "Nom : " + selectRes.Name;
                img.Image = (Bitmap)selectRes.BaseImage;
            }
        }

        #endregion Public Constructors
    }
}