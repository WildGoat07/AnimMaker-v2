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

#pragma warning disable IDE1006 // Styles d'affectation de noms

namespace AnimMaker_v2
{
    public partial class MainForm : Form
    {
        #region Public Fields

        public DrawingSurface Displayer;
        public DrawingSurface resDispl;
        public DynamicSprite resSprite;

        #endregion Public Fields

        #region Public Constructors

        public MainForm()
        {
            InitializeComponent();
            resDispl = new DrawingSurface();
            resDispl.Target.SetActive(false);
            resSprite = new DynamicSprite();
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
            Displayer = tmp;
            tmp.Dock = DockStyle.Fill;
            Program.Timeline = tmp.Target;
            TimelinePanel.Controls.Add(tmp);
            Program.Timeline.Resized += (sender, e) =>
            {
                SFML.Graphics.View view = new SFML.Graphics.View(new FloatRect(0, 0, e.Width, e.Height));
                Program.Timeline.SetView(view);
                Program.ResizeTimeline();
            };
        }

        #endregion Public Constructors

        #region Public Methods

        public void newObj()
        {
            Program.CurrentID = Guid.NewGuid();
            Program.Manager = new DynamicObjectBuilder();
            Program.DynamicObject = new SFDynamicObject();
            Program.DynamicObject.DefaultCategory.Name = "Défaut";
            Program.DynamicObject.Chronometer = Program.Chronometer;
            Program.createdAnimations = 0;
            Program.createdBones = 0;
            Program.createdEvents = 0;
            Program.createdCategories = 0;
            Program.selection = null;
            Program.selectedAnim = null;
            Program.selectedBone = null;
            Program.selectedEvent = null;
            Program.selectedKeys = null;

            UpdateInterface();
        }

        public void OpenObject()
        {
            if (openObject.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Program.Manager = new DynamicObjectBuilder();
                    using (var stream = new FileStream(openObject.FileName, FileMode.Open, FileAccess.Read))
                    {
                        Program.Manager.LoadObjectTemplate("obj", stream);
                    }
                    Program.DynamicObject = Program.Manager.CreateObject("obj");
                    Program.selection = null;
                    Program.CurrentID = Guid.NewGuid();
                    Program.createdAnimations = 0;
                    Program.createdBones = 0;
                    Program.createdEvents = 0;
                    Program.createdCategories = 0;
                    Program.DynamicObject.DefaultCategory.Name = "Défaut";
                    Program.DynamicObject.Chronometer = Program.Chronometer;
                    Program.currentPath = (string)openObject.FileName.Clone();
                    UpdateInterface();
                }
                catch (Exception e)
                {
                    var dialog = new ThreadExceptionDialog(e);
                    dialog.ShowDialog();
                }
                if (Program.DynamicObject.Version < SFDynamicObject.CurrentVersion)
                    MessageBox.Show("Ce fichier est en version " + Program.DynamicObject.Version + " alors que l'API est en " + SFDynamicObject.CurrentVersion + " le fichier peut avoir quelques changements.", "Conflit de version", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void OpenObject(string path)
        {
            Program.currentPath = (string)path.Clone();
            Program.Manager = new DynamicObjectBuilder();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                Program.Manager.LoadObjectTemplate("obj", stream);
            }
            Program.DynamicObject = Program.Manager.CreateObject("obj");
            Program.selection = null;
            Program.CurrentID = Guid.NewGuid();
            Program.createdAnimations = 0;
            Program.createdBones = 0;
            Program.createdEvents = 0;
            Program.createdCategories = 0;
            Program.DynamicObject.DefaultCategory.Name = "Défaut";
            Program.DynamicObject.Chronometer = Program.Chronometer;
            UpdateInterface();
        }

        public void SaveObject(bool sub = false)
        {
            if (Program.currentPath != null && Program.currentPath != "" && !sub)
            {
                using (var stream = new System.IO.FileStream(Program.currentPath, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    Program.DynamicObject.SaveAsTemplate(stream);
            }
            else if (saveObject.ShowDialog() == DialogResult.OK)
            {
                using (var stream = new System.IO.FileStream(saveObject.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
                    Program.DynamicObject.SaveAsTemplate(stream);
                Program.currentPath = (string)saveObject.FileName.Clone();
            }
            UpdateInterface();
        }

        public void UpdateInterface()
        {
            {
                hierarchy.Items.Clear();
                foreach (var bone in Program.DynamicObject.BonesHierarchy.AsEnumerable().Reverse())
                    hierarchy.Items.Add(new OrderedDisplayer(bone));
                if (Program.selection is Bone b)
                    hierarchy.SelectedIndex = hierarchy.Items.IndexOf(new OrderedDisplayer(b));
                else
                    hierarchy.SelectedIndex = -1;
            }
            {
                res.Items.Clear();
                foreach (var resource in Program.DynamicObject.UsedResources)
                    res.Items.Add(new OrderedDisplayer(resource));
                if (Program.selection is Resource r)
                    res.SelectedIndex = res.Items.IndexOf(new OrderedDisplayer(r));
                else
                    res.SelectedIndex = -1;
            }
            {
                animations.Items.Clear();
                foreach (var animation in Program.DynamicObject.Animations)
                    animations.Items.Add(new OrderedDisplayer(animation));
                if (Program.selection is Animation a)
                    animations.SelectedIndex = animations.Items.IndexOf(new OrderedDisplayer(a));
                else
                    animations.SelectedIndex = -1;
            }
            {
                categories.Items.Clear();
                categories.Items.Add(new OrderedDisplayer(Program.DynamicObject.DefaultCategory));
                foreach (var categ in Program.DynamicObject.CustomCategories)
                    categories.Items.Add(new OrderedDisplayer(categ));
                if (Program.selection is Category c)
                    categories.SelectedIndex = categories.Items.IndexOf(new OrderedDisplayer(c));
                else
                    categories.SelectedIndex = -1;
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

        public void UpdateProp()
        {
            removeCateg.Enabled = false;
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
                    Program.selectedEvent = null;
                    removeBone.Enabled = true;
                    stripRemoveBone.Enabled = true;
                    toolRemoveBone.Enabled = true;
                    stripTopBone.Enabled = true;
                    stripBotBone.Enabled = true;
                    var tmp = hierarchy.Items.IndexOf(new OrderedDisplayer(bone));
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
                if (Program.selection is Category categ)
                {
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedAnim = null;
                    Program.selectedEvent = null;
                    Program.selectedBone = null;
                    if (categ != Program.DynamicObject.DefaultCategory)
                        removeCateg.Enabled = true;
                    {
                        var tmp2 = new CategoryProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is Animation anim)
                {
                    Program.selectedEvent = null;
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
                if (Program.selection is EventTrigger trigger)
                {
                    Program.selectedKeys = null;
                    Program.selectedBone = null;
                    {
                        var tmp2 = new EventProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is Resource)
                {
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedBone = null;
                    Program.selectedAnim = null;
                    Program.selectedEvent = null;
                    removeResource.Enabled = true;
                    stripRemoveRes.Enabled = true;
                    toolRemoveRes.Enabled = true;
                    {
                        var tmp2 = new ResProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is DynamicSprite)
                {
                    Program.DynamicObject.ResetAnimation();
                    Program.selectedKeys = null;
                    Program.selectedAnim = null;
                    Program.selectedEvent = null;
                    {
                        var tmp2 = new SpriteProperties();
                        tmp2.Dock = DockStyle.Fill;
                        properties.Controls.Add(tmp2);
                    }
                }
                if (Program.selection is List<Animation.Key>)
                {
                    Program.selectedEvent = null;
                    Program.selectedKeys = (List<Animation.Key>)Program.selection;
                    foreach (var ani in Program.DynamicObject.Animations)
                    {
                        foreach (var animBone in ani.Bones)
                        {
                            if (animBone.Value == Program.selectedKeys)
                                Program.selectedBone = animBone.Key;
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
                    Program.selectedEvent = null;
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

        #endregion Public Methods

        #region Private Methods

        private void addResource_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void animations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animations.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.DynamicObject.Animations.Find((anim) => anim.ID == ((dynamic)animations.Items[animations.SelectedIndex]).ID);
            UpdateProp();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new AboutForm();
            dialog.ShowDialog();
        }

        private void createAnim_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        private void createBone_Click(object sender, EventArgs e)
        {
            Program.AddBone();
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
                    var couple = new Couple<Bone, List<Animation.Key>>();
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
                    var couple = new Couple<Bone, List<Animation.Key>>();
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
                    var couple = new Couple<Bone, List<Animation.Key>>();
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
                    if (baseAnimA.Bones.Find((couple) => couple.Key.ID == bone.ID) != null || baseAnimB.Bones.Find((couple) => couple.Key.ID == bone.ID) != null)
                        toCompute.Add(bone);
                }
                foreach (var bone in toCompute)
                {
                    Animation.Key first = new Animation.Key() { Position = Time.FromSeconds(1), Transform = new Transformable() };
                    Animation.Key last = new Animation.Key() { Position = Time.Zero, Transform = new Transformable() };
                    Couple<Bone, List<Animation.Key>> coupleAfter = baseAnimA.Bones.Find((c) => c.Key.ID == bone.ID);
                    Couple<Bone, List<Animation.Key>> coupleBefore = baseAnimB.Bones.Find((c) => c.Key.ID == bone.ID);
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
                    anim.Bones.Add(new Couple<Bone, List<Animation.Key>>() { Key = bone, Value = new List<Animation.Key>() { last, first } });
                }

                anim.Name = "Entre " + baseAnimB.Name + " et " + baseAnimA.Name;
                anim.Duration = Time.FromSeconds(1);
                Program.AddAnimation(anim);
            }
        }

        private void deleteBone_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void fermerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void hierarchy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hierarchy.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.DynamicObject.BonesHierarchy.First((bone) => bone.ID == ((dynamic)hierarchy.Items[hierarchy.SelectedIndex]).ID);
            Program.selectedBone = (Bone)Program.selection;
            UpdateProp();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.O)
                OpenObject();
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.N)
                newObj();
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.S)
                SaveObject();
            if (e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.P)
                paramètresToolStripMenuItem_Click(null, null);
            if (e.Control && e.Shift && !e.Alt && e.KeyCode == Keys.S)
                SaveObject(true);
        }

        private void moveDownHierarchy_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            var target = Program.DynamicObject.BonesHierarchy.IndexOf(selection) - 1;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(target, selection);

            UpdateInterface();
        }

        private void moveUpHierarchy_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            var target = Program.DynamicObject.BonesHierarchy.IndexOf(selection) + 1;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(target, selection);

            UpdateInterface();
        }

        private void nouveauManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newObj();
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddBone();
        }

        private void objetDynamiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newObj();
        }

        private void objetDynamiqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveObject();
        }

        private void objetDynamiqueToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenObject();
        }

        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenObject();
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Parameters().ShowDialog();
        }

        private void removeAnim_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void removeResource_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void res_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (res.SelectedIndex == -1)
                Program.selection = null;
            else
                Program.selection = Program.DynamicObject.UsedResources.Find((r) => r.ID == ((dynamic)res.Items[res.SelectedIndex]).ID);
            UpdateProp();
        }

        private void sauvegarderLeManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveObject();
        }

        private void sauvegarderSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveObject(true);
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

        private void stripTopBone_Click(object sender, EventArgs e)
        {
            var selection = (Bone)Program.selection;
            Program.DynamicObject.BonesHierarchy.Remove(selection);
            Program.DynamicObject.BonesHierarchy.Insert(Program.DynamicObject.BonesHierarchy.Count, selection);

            UpdateInterface();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void supprimerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void supprimerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void toolAddAnim_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        private void toolAddBone_Click(object sender, EventArgs e)
        {
            Program.AddBone();
        }

        private void toolAddRes_Click(object sender, EventArgs e)
        {
            Program.AddResource();
        }

        private void toolRemoveAnim_Click(object sender, EventArgs e)
        {
            Program.RemoveAnimation();
        }

        private void toolRemoveBone_Click(object sender, EventArgs e)
        {
            Program.RemoveBone();
        }

        private void toolRemoveRes_Click(object sender, EventArgs e)
        {
            Program.RemoveResource();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Program.Chronometer.Paused = !Program.Chronometer.Paused;
        }

        private void videToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.AddAnimation();
        }

        #endregion Private Methods

        private void importerUneSéquenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openTexture.ShowDialog() == DialogResult.OK)
            {
                var name = Path.GetFileNameWithoutExtension(openTexture.FileName);
                while (char.IsDigit(name[name.Length - 1]))
                    name = name.Substring(0, name.Length - 1);
                var list = openTexture.FileNames.ToList();
                list.Sort();
                var imgs = list.ConvertAll((s) => new SFML.Graphics.Image(s));
                Vector2u size = imgs[0].Size;
                if (!imgs.All((img) => img.Size == size))
                {
                    MessageBox.Show(this, "Les images ne font pas toutes la même taille.", "Erreur lors de la compilation d'images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Vector2i matrixSize = default;
                {
                    var root = Math.Sqrt(imgs.Count);
                    matrixSize.X = (int)Math.Ceiling(root);
                    if (root - Math.Truncate(root) < .5)
                        matrixSize.Y = (int)Math.Floor(root);
                    else
                        matrixSize.Y = (int)Math.Ceiling(root);
                }
                var globalImg = new SFML.Graphics.Image((uint)(size.X * matrixSize.X), (uint)(size.Y * matrixSize.Y), SFML.Graphics.Color.Transparent);
                Vector2i offset = default;
                foreach (var img in imgs)
                {
                    for (uint x = 0; x < size.X; x++)
                    {
                        for (uint y = 0; y < size.Y; y++)
                        {
                            globalImg.SetPixel(x + (uint)offset.X, y + (uint)offset.Y, img.GetPixel(x, y));
                        }
                    }
                    offset.X += (int)size.X;
                    if (offset.X >= globalImg.Size.X)
                    {
                        offset.X = 0;
                        offset.Y += (int)size.Y;
                    }
                }
                var res = new Resource();
                res.Name = name;
                res.Smooth = true;
                res.ChangeBaseImage(globalImg);
                res.ChangeFrames((Vector2i)globalImg.Size, new Vector2i());
                Program.DynamicObject.UsedResources.Add(res);
                UpdateInterface();
            }
        }

        private void categories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categories.SelectedIndex == -1)
                Program.selection = null;
            else if (((OrderedDisplayer)categories.SelectedItem).ID == Program.DynamicObject.DefaultCategory.ID)
                Program.selection = Program.DynamicObject.DefaultCategory;
            else
                Program.selection = Program.DynamicObject.CustomCategories.First((c) => c.ID == ((OrderedDisplayer)categories.SelectedItem).ID);
            UpdateProp();
        }

        private void createCateg_Click(object sender, EventArgs e)
        {
            var tmp = new Category();
            tmp.Name = "catégorie" + Program.createdCategories;
            Program.createdCategories++;
            Program.selection = tmp;
            Program.DynamicObject.CustomCategories.Add(tmp);
            UpdateInterface();
        }

        private void removeCateg_Click(object sender, EventArgs e)
        {
            var categ = (Category)Program.selection;
            Program.DynamicObject.CustomCategories.Remove(categ);
            foreach (var b in Program.DynamicObject.BonesHierarchy)
            {
                if (b.Category == categ)
                    b.Category = Program.DynamicObject.DefaultCategory;
            }
            Program.selection = null;
            UpdateInterface();
        }
    }
}

#pragma warning restore IDE1006 // Styles d'affectation de noms