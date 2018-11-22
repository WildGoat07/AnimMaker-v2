using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WGP.SFDynamicObject;
using SFML.System;

namespace AnimMaker_v2
{
    public partial class EditResource : Form
    {
        #region Private Fields

        private bool animated;
        private dynamic currentControl;
        private Resource res;
        private int step;

        #endregion Private Fields

        #region Public Constructors

        public EditResource()
        {
            res = (Resource)Program.selection;
            InitializeComponent();
            animated = res.FramesPosition.Length > 1;
            step = 1;
            UpdateInterface();
        }

        #endregion Public Constructors

        #region Public Methods

        public void UpdateInterface()
        {
            switch (step)
            {
                case 1:
                    mainPanel.Controls.Clear();
                    currentControl = new ResourceStep1();
                    mainPanel.Controls.Add(currentControl);
                    previousStep.Enabled = false;
                    nextStep.Enabled = true;
                    nextStep.Text = "Suivant";
                    if (animated)
                        currentControl.animatedTexture.Checked = true;
                    else
                        currentControl.staticTexture.Checked = true;
                    break;

                case 2:
                    mainPanel.Controls.Clear();
                    previousStep.Enabled = true;
                    nextStep.Enabled = true;
                    currentControl = new ResourceStep2(res, res.FramesPosition[0], res.FrameSize);
                    mainPanel.Controls.Add(currentControl);
                    nextStep.Text = "Terminer";
                    break;

                case 12:
                    mainPanel.Controls.Clear();
                    previousStep.Enabled = true;
                    nextStep.Enabled = true;
                    currentControl = new ResourceStep12(res, res.FrameSize, res.FramesPerSecond);
                    mainPanel.Controls.Add(currentControl);
                    nextStep.Text = "Terminer";
                    break;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private void EditResource_FormClosed(object sender, FormClosedEventArgs e)
        {
            currentControl.Finished = true;
        }

        private void nextStep_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 1:
                    animated = !currentControl.staticTexture.Checked;
                    if (!animated)
                        step = 2;
                    else
                        step = 12;
                    UpdateInterface();
                    break;

                case 2:
                    res.ChangeFrames(currentControl.size, currentControl.pos);
                    currentControl.Finished = true;
                    Close();
                    break;

                case 12:
                    res.ChangeFrames(currentControl.size, currentControl.pos);
                    res.FramesPerSecond = currentControl.fpsCount;
                    currentControl.Finished = true;
                    Close();
                    break;
            }
        }

        private void previousStep_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 2:
                    step = 1;
                    currentControl.Finished = true;
                    UpdateInterface();
                    break;

                case 12:
                    step = 1;
                    currentControl.Finished = true;
                    UpdateInterface();
                    break;
            }
        }

        #endregion Private Methods
    }
}