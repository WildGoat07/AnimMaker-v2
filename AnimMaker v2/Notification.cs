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
    internal class Notification
    {
        public Chronometer Chronometer;
        public Time LivingTime;
        public string Description;

        public Notification()
        {
            Chronometer = new Chronometer();
            LivingTime = Time.FromSeconds(2);
            Description = "";
        }
    }
}