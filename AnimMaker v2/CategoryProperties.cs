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
    public partial class CategoryProperties : UserControl
    {
        public CategoryProperties()
        {
            InitializeComponent();
            if (Program.selection is Category category)
            {
                if (category == Program.DynamicObject.DefaultCategory)
                    categName.Enabled = false;
                categName.Text = category.Name;
                categID.Text = "ID : " + category.ID.ToString("D");
                categEnabled.Checked = category.Enabled;
                if (categEnabled.Checked)
                    categEnabled.Text = "Affichée";
                else
                    categEnabled.Text = "Cachée";
            }
        }

        private void categEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (categEnabled.Checked)
                categEnabled.Text = "Affichée";
            else
                categEnabled.Text = "Cachée";
            var categ = (Category)Program.selection;
            categ.Enabled = categEnabled.Checked;
        }

        private void categName_Validated(object sender, EventArgs e)
        {
            var categ = (Category)Program.selection;

            categ.Name = categName.Text;

            Program.form.UpdateInterface();
        }

        private void categName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!e.Alt && !e.Shift && !e.Control && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }
    }
}