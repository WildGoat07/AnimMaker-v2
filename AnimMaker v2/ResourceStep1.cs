using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimMaker_v2
{
    public partial class ResourceStep1 : UserControl, Finishable
    {
        #region Public Constructors

        public ResourceStep1()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion Public Constructors

        #region Public Properties

        public bool Finished { get; set; }

        #endregion Public Properties
    }
}