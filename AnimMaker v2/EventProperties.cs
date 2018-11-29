using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using SFML.Graphics;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;

namespace AnimMaker_v2
{
    public partial class EventProperties : UserControl
    {
        public EventProperties()
        {
            InitializeComponent();

            if (Program.selection is EventTrigger trigger)
            {
                evName.Text = trigger.Name;
                dispId.Text = "ID : " + trigger.ID.ToString("D");
                posX.Value = (decimal)trigger.Area.Left;
                posY.Value = (decimal)trigger.Area.Top;
                sizeX.Value = (decimal)trigger.Area.Width;
                sizeY.Value = (decimal)trigger.Area.Height;
                seconds.Value = (decimal)trigger.Time.Seconds;
            }
        }

        private void posX_ValueChanged(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            var tmp = trigger.Area;
            tmp.Left = (float)posX.Value;
            trigger.Area = tmp;
        }

        private void posY_ValueChanged(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            var tmp = trigger.Area;
            tmp.Top = (float)posY.Value;
            trigger.Area = tmp;
        }

        private void sizeX_ValueChanged(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            var tmp = trigger.Area;
            tmp.Width = (float)sizeX.Value;
            trigger.Area = tmp;
        }

        private void sizeY_ValueChanged(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            var tmp = trigger.Area;
            tmp.Height = (float)sizeY.Value;
            trigger.Area = tmp;
        }

        private void seconds_ValueChanged(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            trigger.Time = Time.FromSeconds((float)seconds.Value);
        }

        private void evName_Validated(object sender, EventArgs e)
        {
            var trigger = (EventTrigger)Program.selection;
            trigger.Name = evName.Text;
            Program.form.UpdateProp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.ChangingEventArea = true;
        }
    }
}