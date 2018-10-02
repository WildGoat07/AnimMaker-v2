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
        public ResProperties()
        {
            InitializeComponent();


            if (Program.selection != null)
            {
                var selectRes = (KeyValuePair<string, ResourceManager.Resource>)Program.selection;

                name.Text = "Nom : " + selectRes.Key;
                path.Text = selectRes.Value.Path.Replace('/', '\\');
                img.Image = Utilities.SFMLImageAsSystemBitmap(((Texture)selectRes.Value.Data).CopyToImage());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectRes = (KeyValuePair<string, ResourceManager.Resource>)Program.selection;
            Process.Start("explorer.exe", "/select,\"" + System.IO.Path.Combine(Program.Resources.Path, selectRes.Value.Path) + "\"");
        }

        private void path_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var selectRes = (KeyValuePair<string, ResourceManager.Resource>)Program.selection;
            Process.Start("\"" + System.IO.Path.GetFullPath(System.IO.Path.Combine(Program.Resources.Path, selectRes.Value.Path)) + "\"");
        }
    }
}
