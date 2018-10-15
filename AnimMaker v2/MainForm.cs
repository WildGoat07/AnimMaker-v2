using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SFML.Graphics;
using SFML.System;
using WGP;
using WGP.SFDynamicObject;
#pragma warning disable IDE1006 // Styles d'affectation de noms

namespace AnimMaker_v2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var tmp = new DrawingSurface();
            tmp.Dock = DockStyle.Fill;
            Program.Display = tmp.Target;
            DisplayPanel.Controls.Add(tmp);
            Program.Display.Resized += (sender, e) =>
            {
                SFML.Graphics.View view = new SFML.Graphics.View(new Vector2f(), new Vector2f(e.Width, e.Height));
                Program.Display.SetView(view);
            };
            tmp = new DrawingSurface();
            tmp.Dock = DockStyle.Fill;
            Program.Timeline = tmp.Target;
            TimelinePanel.Controls.Add(tmp);
            Program.Timeline.Resized += (sender, e) =>
            {
                SFML.Graphics.View view = new SFML.Graphics.View(new FloatRect(0, 0, e.Width, e.Height));
                Program.Timeline.SetView(view);
                Program.ResizeTimeline();
            };
            {
                var tmp2 = new BoneProperties();
                tmp2.Dock = DockStyle.Fill;
                properties.Controls.Add(tmp2);
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void UpdateProp()
        {
            removeAnim.Enabled = false;
            removeResource.Enabled = false;
            removeBone.Enabled = false;
            stripRemoveAnim.Enabled = false;
            stripRemoveBone.Enabled = false;
            stripRemoveRes.Enabled = false;
            moveUpHierarchy.Enabled = false;
            moveDownHierarchy.Enabled = false;
            stripTopBone.Enabled = false;
            stripBotBone.Enabled = false;
            stripScaleAnim.Enabled = false;
            toolRemoveAnim.Enabled = false;
            toolRemoveBone.Enabled = false;
            toolRemoveRes.Enabled = false;
            properties.Controls.Clear();

            if (Program.selection != null)
            {
                if (Program.selection is Bone bone)
                {
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedAnim = null;
                    removeBone.Enabled = true;
                    stripRemoveBone.Enabled = true;
                    toolRemoveBone.Enabled = true;
                    stripTopBone.Enabled = true;
                    stripBotBone.Enabled = true;
                    var tmp = hierarchy.Items.IndexOf(bone.Name);
                    if (tmp > 0)
                        moveUpHierarchy.Enabled = true;
                    if (tmp < hierarchy.Items.Count - 1)
                        moveDownHierarchy.Enabled = true;
                    {
                        var tmp2 = new BoneProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is Animation anim)
                {/***/
                    Program.selectedKeys = null;
                    Program.selectedBone = null;
                    removeAnim.Enabled = true;
                    stripRemoveAnim.Enabled = true;
                    toolRemoveAnim.Enabled = true;
                    stripScaleAnim.Enabled = true;
                    Program.selectedAnim = anim;
                    {
                        var tmp2 = new AnimProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                    Program.DynamicObject.LoadAnimation(anim.Name);
                }
                if (Program.selection is KeyValuePair<string, ResourceManager.Resource>)
                {
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedBone = null;
                    Program.selectedAnim = null;
                    removeResource.Enabled = true;
                    stripRemoveRes.Enabled = true;
                    toolRemoveRes.Enabled = true;
                    {
                        var tmp2 = new ResProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is Couple<string, RectangleShape>)
                {/***/
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedAnim = null;
                    {
                        var tmp2 = new SpriteProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is List<Animation.Key>)
                {
                    Program.selectedKeys = (List<Animation.Key>)Program.selection;
                    foreach (var ani in Program.DynamicObject.Animations)
                    {
                        foreach (var animBone in ani.Bones)
                        {
                            if (animBone.Value == Program.selectedKeys)
                                Program.selectedBone = Program.DynamicObject.BonesHierarchy.Find((b) => b.Name == animBone.Key);
                        }
                    }
                    {
                        var tmp2 = new KeysListProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is Animation.Key)
                {
                    {
                        var tmp2 = new KeyProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
            }
            else
            {
                Program.selectedKeys = null;
                properties.Controls.Clear();
            }
        }

        public void UpdateInterface()
        {
            {
                hierarchy.Items.Clear();
                foreach (var bone in Program.DynamicObject.BonesHierarchy.AsEnumerable().Reverse())
                    hierarchy.Items.Add(bone.Name);
                if (Program.selection is Bone)
                    hierarchy.SelectedIndex = hierarchy.Items.IndexOf(((Bone)Program.selection).Name);
                else
                    hierarchy.SelectedIndex = -1;
            }
            {
                res.Items.Clear();
                foreach (var resource in Program.Resources)
                    res.Items.Add(resource.Key);
                if (Program.selection is KeyValuePair<string, ResourceManager.Resource>)
                    res.SelectedIndex = res.Items.IndexOf(((KeyValuePair<string, ResourceManager.Resource>)Program.selection).Key);
                else
                    res.SelectedIndex = -1;
            }
            {
                animations.Items.Clear();
                foreach (var animation in Program.DynamicObject.Animations)
                    animations.Items.Add(animation.Name);
                if (Program.selection is Animation)
                    animations.SelectedIndex = animations.Items.IndexOf(((Animation)Program.selection).Name);
                else
                    animations.SelectedIndex = -1;
            }
            stripCopyListAnim.Items.Clear();
            stripBeforeListAnim.Items.Clear();
            stripAfterListAnim.Items.Clear();
            stripBetweenAListAnim.Items.Clear();
            stripBetweenBListAnim.Items.Clear();
            foreach (var anim in Program.DynamicObject.Animations)
            {
                stripCopyListAnim.Items.Add(anim.Name);
                stripBeforeListAnim.Items.Add(anim.Name);
                stripAfterListAnim.Items.Add(anim.Name);
                stripBetweenAListAnim.Items.Add(anim.Name);
                stripBetweenBListAnim.Items.Add(anim.Name);
            }

            UpdateProp();
        }
        public void OpenRes()
        {
            if (openRes.ShowDialog() == DialogResult.OK)
            {
                Program.Resources.LoadFromFile(openRes.FileName);
                Program.DynamicObject.Manager = Program.Resources;
                Program.selection = null;
                UpdateInterface();
            }
        }
        public void OpenObject()
        {
            if (openObject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Program.DynamicObject.LoadFromFile(openObject.FileName);
                    Program.DynamicObject.ReloadManager();
                    Program.selection = null;
                    Program.CurrentID = Guid.NewGuid();
                    UpdateInterface();
                }
                catch(Exception e)
                {
                    if (e.InnerException.InnerException is SFDynamicObject.NewerVersionException ex)
                    {
                        if (MessageBox.Show("Le fichier chargé proviens d'une versions plus récente : " + ex.RequestedVersion + " alors que la révision actuelle est " + SFDynamicObject.CurrentVersion + "\nCharger ce fichier pourrait corrompre certaines données, le charger quand même ?", "Conflit de version", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            Program.DynamicObject.LoadFromFile(openObject.FileName, true);
                            Program.DynamicObject.ReloadManager();
                            Program.selection = null;
                            Program.CurrentID = Guid.NewGuid();
                            UpdateInterface();
                        }
                    }
                    else
                        throw e;
                }
                if (Program.DynamicObject.Version < SFDynamicObject.CurrentVersion)
                    MessageBox.Show("Ce fichier est en version " + Program.DynamicObject.Version + " alors que l'API est en " + SFDynamicObject.CurrentVersion + " le fichier peut avoir quelques changements.", "Conflit de version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void OpenRes(string path)
        {
            Program.Resources.LoadFromFile(path);
            Program.DynamicObject.Manager = Program.Resources;
            Program.selection = null;
            UpdateInterface();
        }
        public void OpenObject(string path)
        {
            Program.DynamicObject.LoadFromFile(path);
            Program.DynamicObject.ReloadManager();
            Program.selection = null;
            Program.CurrentID = Guid.NewGuid();
            UpdateInterface();
        }
        public void SaveRes()
        {
            if (saveRes.ShowDialog() == DialogResult.OK)
                Program.Resources.SaveToFile(saveRes.FileName);


            UpdateInterface();
        }
        public void SaveObject()
        {
            if (saveObject.ShowDialog() == DialogResult.OK)
                Program.DynamicObject.SaveToStream(new System.IO.FileStream(saveObject.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write));


            UpdateInterface();
        }

        private void objetDynamiqueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenObject();
        }

        private void managerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenRes();
        }

        private void managerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveRes();
        }

        private void objetDynamiqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveObject();
        }
        #region some button
        private void createBone_Click(object sender, EventArgs e)
        {
            Program.AddBone();
        }

        private void deleteBone_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void addResource_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void removeResource_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void createAnim_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        private void removeAnim_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddBone();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void supprimerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void videToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        private void créerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (stripCopyListAnim.SelectedIndex == -1)
                Program.AddAnimation();
            else
            {
                var baseAnim = Program.DynamicObject.Animations.Find((a) => a.Name == stripCopyListAnim.SelectedItem.ToString());
                var anim = new Animation();
                foreach (var bone in baseAnim.Bones)
                {
                    var couple = new Couple<string, List<Animation.Key>>();
                    couple.Key = bone.Key;
                    couple.Value = new List<Animation.Key>();
                    foreach (var key in bone.Value)
                    {
                        var copyKey = new Animation.Key();
                        copyKey.Transform = new Transformable(key.Transform);
                        copyKey.Position = key.Position;
                        couple.Value.Add(copyKey);
                    }
                    anim.Bones.Add(couple);
                }
                anim.Name = "Copie de " + baseAnim.Name;
                anim.Duration = baseAnim.Duration;
                Program.AddAnimation(anim);
            }
        }

        private void créerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (stripAfterListAnim.SelectedIndex == -1)
                Program.AddAnimation();
            else
            {
                var baseAnim = Program.DynamicObject.Animations.Find((a) => a.Name == stripAfterListAnim.SelectedItem.ToString());
                var anim = new Animation();
                foreach (var bone in baseAnim.Bones)
                {
                    var couple = new Couple<string, List<Animation.Key>>();
                    couple.Key = bone.Key;
                    couple.Value = new List<Animation.Key>();
                    Animation.Key lastKey = null;
                    foreach (var keys in bone.Value)
                    {
                        lastKey = keys;
                    }
                    if (lastKey != null)
                    {
                        couple.Value.Add(new Animation.Key() { Position = Time.Zero, Transform = new Transformable(lastKey.Transform) });
                        anim.Bones.Add(couple);
                    }
                }
                anim.Name = "Après " + baseAnim.Name;
                anim.Duration = Time.FromSeconds(1);
                Program.AddAnimation(anim);
            }
        }

        private void créerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (stripBeforeListAnim.SelectedIndex == -1)
                Program.AddAnimation();
            else
            {
                var baseAnim = Program.DynamicObject.Animations.Find((a) => a.Name == stripBeforeListAnim.SelectedItem.ToString());
                var anim = new Animation();
                foreach (var bone in baseAnim.Bones)
                {
                    var couple = new Couple<string, List<Animation.Key>>();
                    couple.Key = bone.Key;
                    couple.Value = new List<Animation.Key>();
                    Animation.Key firstKey = bone.Value.FirstOrDefault();
                    if (firstKey != null)
                    {
                        couple.Value.Add(new Animation.Key() { Position = Time.FromSeconds(1), Transform = new Transformable(firstKey.Transform) });
                        anim.Bones.Add(couple);
                    }
                }
                anim.Name = "Avant " + baseAnim.Name;
                anim.Duration = Time.FromSeconds(1);
                Program.AddAnimation(anim);
            }
        }

        private void créerToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (stripBetweenAListAnim.SelectedIndex == -1 || stripBetweenBListAnim.SelectedIndex == -1)
                Program.AddAnimation();
            else
            {
                var baseAnimB = Program.DynamicObject.Animations.Find((a) => a.Name == stripBetweenBListAnim.SelectedItem.ToString());
                var baseAnimA = Program.DynamicObject.Animations.Find((a) => a.Name == stripBetweenAListAnim.SelectedItem.ToString());
                var anim = new Animation();

                List<Bone> toCompute = new List<Bone>();

                foreach (var bone in Program.DynamicObject.BonesHierarchy)
                {
                    if (baseAnimA.Bones.Find((couple) => couple.Key == bone.Name) != null || baseAnimB.Bones.Find((couple) => couple.Key == bone.Name) != null)
                        toCompute.Add(bone);
                }
                foreach (var bone in toCompute)
                {
                    Animation.Key first = new Animation.Key() { Position = Time.FromSeconds(1), Transform = new Transformable() };
                    Animation.Key last = new Animation.Key() { Position = Time.Zero, Transform = new Transformable() };
                    Couple<string, List<Animation.Key>> coupleAfter = baseAnimA.Bones.Find((c) => c.Key == bone.Name);
                    Couple<string, List<Animation.Key>> coupleBefore = baseAnimB.Bones.Find((c) => c.Key == bone.Name);
                    if (coupleAfter != null)
                    {
                        var tmp = new List<Animation.Key>(coupleAfter.Value.ToArray());
                        tmp.Sort();
                        first.Transform = new Transformable(tmp.First().Transform);
                    }
                    if (coupleBefore != null)
                    {
                        var tmp = new List<Animation.Key>(coupleBefore.Value.ToArray());
                        tmp.Sort();
                        last.Transform = new Transformable(tmp.Last().Transform);
                    }
                    anim.Bones.Add(new Couple<string, List<Animation.Key>>() { Key = bone.Name, Value = new List<Animation.Key>() { last, first } });
                }

                anim.Name = "Entre " + baseAnimB.Name + " et " + baseAnimA.Name;
                anim.Duration = Time.FromSeconds(1);
                Program.AddAnimation(anim);
            }
        }
        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.O)
                OpenObject();
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.O)
                OpenRes();
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.N)
                newObj();
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.N)
                newRes();
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.S)
                SaveObject();
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.S)
                SaveRes();
        }

        public void newObj()
        {
            Program.CurrentID = Guid.NewGuid();
            Program.DynamicObject = new SFDynamicObject();
            Program.DynamicObject.Manager = Program.Resources;
            Program.DynamicObject.Chronometer = Program.Chronometer;
            Program.createdAnimations = 0;
            Program.createdBones = 0;
            Program.selection = null;

            UpdateInterface();
        }

        public void newRes()
        {
            Program.Resources = new ResourceManager();
            Program.DynamicObject.Manager = Program.Resources;
            Program.createdResources = 0;
            Program.createdBones = 0;
            Program.selection = null;

            UpdateInterface();
        }

        private void objetDynamiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newObj();
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newRes();
        }

        private void toolAddBone_Click(object sender, EventArgs e)
        {
            Program.AddBone();
        }

        private void toolRemoveBone_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void toolAddRes_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void toolRemoveRes_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void toolAddAnim_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        private void toolRemoveAnim_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void hierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hierarchy.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.DynamicObject.BonesHierarchy.Find((bone) => bone.Name == hierarchy.Items[hierarchy.SelectedIndex].ToString());
            Program.selectedBone = (Bone)Program.selection;
            UpdateProp();
        }

        private void moveUpHierarchy_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            var target = Program.DynamicObject.BonesHierarchy.FindIndex((bone) => bone.Name == selection.Name) + 1;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(target, selection);

            UpdateInterface();
        }

        private void moveDownHierarchy_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            var target = Program.DynamicObject.BonesHierarchy.FindIndex((bone) => bone.Name == selection.Name) - 1;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(target, selection);

            UpdateInterface();
        }

        private void animations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animations.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.DynamicObject.Animations.Find((anim) => anim.Name == animations.Items[animations.SelectedIndex].ToString());
            UpdateProp();
        }

        private void res_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (res.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.Resources.First((pair) => pair.Key == res.Items[res.SelectedIndex].ToString());
            UpdateProp();
        }

        private void stripTopBone_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(Program.DynamicObject.BonesHierarchy.Count, selection);

            UpdateInterface();
        }

        private void stripBotBone_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(0, selection);

            UpdateInterface();
        }

        private void stripScaleAnim_Click(object sender, EventArgs e)
        {
            new AskForScaling().ShowDialog();
            UpdateProp();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Program.Chronometer.Paused = !Program.Chronometer.Paused;
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new AboutForm();
            dialog.ShowDialog();
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Parameters().ShowDialog();
        }
    }
}
#pragma warning restore IDE1006 // Styles d'affectation de noms
