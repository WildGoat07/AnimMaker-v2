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
using WGP.SFDynamicObject;
using SFML.System;
using SFML.Graphics;

namespace AnimMaker_v2
{
    public partial class AnimProperties : UserControl
    {
        #region Public Constructors

        public AnimProperties()
        {
            InitializeComponent();

            if (Program.selection != null)
            {
                var anim = (Animation)Program.selection;
                addBone.Enabled = false;
                removeBone.Enabled = false;
                selectKeys.Enabled = false;
                dispId.Text = "ID : " + anim.ID.ToString("D");

                animName.Text = anim.Name;
                Duration.Value = (decimal)anim.Duration.AsSeconds();
                List<OrderedDisplayer> contained = new List<OrderedDisplayer>();
                foreach (var couple in anim.Bones)
                {
                    bones.Items.Add(new OrderedDisplayer(couple.Key));
                    contained.Add(new OrderedDisplayer(couple.Key));
                }
                foreach (var ev in anim.Triggers)
                    events.Items.Add(new OrderedDisplayer(ev));
                bonesList.Items.Add("Selectionner un os");
                bonesList.SelectedIndex = 0;
                foreach (var item in Program.DynamicObject.BonesHierarchy)
                {
                    if (!contained.Exists((od) => od.ID == item.ID))
                        bonesList.Items.Add(new OrderedDisplayer(item));
                }
                modEv.Enabled = false;
                delEv.Enabled = false;
            }
        }

        #endregion Public Constructors

        #region Private Methods

        private void addBone_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Bones.Add(new Couple<Bone, List<Animation.Key>>(Program.DynamicObject.BonesHierarchy.First((b) => b.ID == ((dynamic)bonesList.Items[bonesList.SelectedIndex]).ID), new List<Animation.Key>()));

            Program.form.UpdateProp();
        }

        private void animName_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Alt && !e.Control && !e.Shift && e.KeyCode == Keys.Return)
                Program.form.DisplayPanel.Focus();
        }

        private void animName_Validated(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Name = animName.Text;

            Program.form.UpdateInterface();
        }

        private void bones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bones.SelectedIndex > -1)
            {
                selectKeys.Enabled = bones.SelectedIndex != -1;
                removeBone.Enabled = bones.SelectedIndex != -1;

                Program.selectedBone = Program.DynamicObject.BonesHierarchy.First((bone) => bone.ID == ((dynamic)bones.Items[bones.SelectedIndex]).ID);
            }
        }

        private void bonesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            addBone.Enabled = bonesList.SelectedIndex > 0;
        }

        private void Duration_ValueChanged(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Duration = Time.FromSeconds((float)Duration.Value);
        }

        private void removeBone_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            anim.Bones.RemoveAll((couple) => couple.Key.ID == ((dynamic)bones.Items[bones.SelectedIndex]).ID);

            Program.form.UpdateProp();
        }

        private void selectKeys_Click(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;

            Program.selection = anim.Bones.Find((couple) => couple.Key.ID == ((dynamic)bones.Items[bones.SelectedIndex]).ID).Value;

            Program.form.UpdateProp();
        }

        #endregion Private Methods

        private void events_SelectedIndexChanged(object sender, EventArgs e)
        {
            var anim = (Animation)Program.selection;
            if (events.SelectedIndex > -1)
            {
                modEv.Enabled = true;
                delEv.Enabled = true;
                Program.selectedEvent = anim.Triggers.Find((t) => t.ID == ((OrderedDisplayer)events.Items[events.SelectedIndex]).ID);
            }
            else
            {
                modEv.Enabled = false;
                delEv.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ev = new EventTrigger();
            ev.Name = "ev" + Program.createdEvents;
            ev.Time = Program.DynamicObject.CurrentTime;
            ev.Trigger = () => Program.Notifications.Insert(0, new Notification() { Description = ev.Name });
            Program.createdEvents++;
            Program.selectedAnim.Triggers.Add(ev);
            Program.form.UpdateProp();
        }

        private void modEv_Click(object sender, EventArgs e)
        {
            Program.selection = Program.selectedAnim.Triggers.Find((tr) => tr.ID == ((OrderedDisplayer)events.Items[events.SelectedIndex]).ID);
            Program.form.UpdateProp();
            Program.Chronometer.Paused = true;
            Program.DynamicObject.CurrentTime = ((EventTrigger)Program.selection).Time;
        }

        private void delEv_Click(object sender, EventArgs e)
        {
            Program.selectedAnim.Triggers.Remove(Program.selectedAnim.Triggers.Find((tr) => tr.ID == ((OrderedDisplayer)events.Items[events.SelectedIndex]).ID));
            Program.form.UpdateProp();
        }
    }
}