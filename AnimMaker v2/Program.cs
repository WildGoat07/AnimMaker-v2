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
    static partial class Program
    {
        #region Public Fields

        public static Chronometer Chronometer;
        public static int createdAnimations;
        public static int createdBones;
        public static Guid CurrentID;
        public static string currentPath;
        public static RenderWindow Display;
        public static SFDynamicObject DynamicObject;
        public static WGP.TEXT.Font font;
        public static MainForm form;
        public static List<KeyControl> keyControls;
        public static DynamicObjectBuilder Manager;
        public static bool seeking;
        public static Animation selectedAnim;
        public static Bone selectedBone;
        public static List<Animation.Key> selectedKeys;
        public static object selection;
        public static Options Settings;
        public static WGP.TEXT.Text textTimer;
        public static RenderWindow Timeline;
        public static FloatRect timeLineDrawRect;
        public static VertexArray timeLineSegs;
        public static bool askForUpdate;

        #endregion Public Fields

        #region Public Methods

        public static void AddAnimation()
        {
            var anim = new Animation();
            anim.Name = "anim" + createdAnimations;
            anim.Duration = Time.FromSeconds(1);
            createdAnimations++;
            DynamicObject.Animations.Add(anim);
            selection = anim;

            form.UpdateInterface();
        }

        public static void AddAnimation(Animation anim)
        {
            createdAnimations++;
            DynamicObject.Animations.Add(anim);
            selection = anim;

            form.UpdateInterface();
        }

        public static void AddBone()
        {
            var bone = new Bone();
            bone.Name = "os" + createdBones;
            createdBones++;
            DynamicObject.BonesHierarchy.Add(bone);
            DynamicObject.MasterBones.Add(bone);
            selection = bone;

            form.UpdateInterface();
        }

        public static void AddResource()
        {
            if (form.openTexture.ShowDialog() == DialogResult.OK)
            {
                var toOpen = form.openTexture.FileNames;
                foreach (var file in toOpen)
                {
                    var key = System.IO.Path.GetFileNameWithoutExtension(file);
                    var res = new Resource();
                    res.Smooth = true;
                    res.Name = key;
                    res.ChangeBaseImage(new Image(file));
                    res.AdaptFrameSize();
                    DynamicObject.UsedResources.Add(res);
                    selection = res;
                }
                form.UpdateInterface();
            }
        }

        public static void leftClick(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                var msPos = Timeline.MapPixelToCoords(new Vector2i(e.X, e.Y));
                int count = 0;
                foreach (var item in keyControls)
                {
                    if (item.GlobalHitBox.Collision(msPos))
                    {
                        selection = selectedKeys[count];
                        DynamicObject.CurrentTime = selectedKeys[count].Position;
                        form.UpdateProp();
                        return;
                    }

                    count++;
                }
                if (msPos.Y > 30)
                    seeking = true;
            }
        }

        public static void RemoveAnimation()
        {
            var anim = (Animation)selection;
            DynamicObject.Animations.Remove(anim);
            selection = null;
            DynamicObject.ResetAnimation();

            form.UpdateInterface();
        }

        public static void RemoveBone()
        {
            var bone = (Bone)selection;
            DynamicObject.BonesHierarchy.Remove(bone);
            DynamicObject.MasterBones.Remove(bone);
            DynamicObject.BonesHierarchy.Remove(bone);
            var par = DynamicObject.BonesHierarchy.Find((parent) => parent.Children.Contains(bone));
            if (par != null)
                par.Children.Remove(bone);
            foreach (var child in bone.Children)
            {
                DynamicObject.MasterBones.Add(child);
            }
            selection = null;

            form.UpdateInterface();
        }

        public static void RemoveResource()
        {
            var res = (Resource)selection;
            DynamicObject.UsedResources.Remove(res);
            res.ChangeBaseImage(null);
            res.ChangeFrames(default, new Vector2i());
            foreach (var item in DynamicObject.BonesHierarchy)
            {
                if (item.AttachedSprite != null && item.AttachedSprite.Resource != null && item.AttachedSprite.Resource.ID == res.ID)
                {
                    item.AttachedSprite.Resource = null;
                    item.AttachedSprite.InternalRect.Texture = null;
                }
            }
            res.Dispose();

            selection = null;

            form.UpdateInterface();
        }

        public static void ResizeTimeline()
        {
            timeLineDrawRect = new FloatRect();
            timeLineDrawRect.Top = 30 + Timeline.Size.Y / 15;
            timeLineDrawRect.Width = Timeline.Size.X;
            timeLineDrawRect.Height = Timeline.Size.Y - 30 - Timeline.Size.Y / 7.5f;
        }

        #endregion Public Methods

        #region Private Methods

        private static void DisplLoop()
        {
            Display.SetActive();
            VertexArray segs = new VertexArray(PrimitiveType.Lines);
            var backRect = new RectangleShape(new Vector2f(2000, 2000)) { Origin = new Vector2f(1000, 1000) };
            int typeGrabbed = 0;
            bool grabbing = false;
            Vector2f relativePos = default;
            Display.MouseButtonPressed += (sender, e) =>
            {
                var msPos = Display.MapPixelToCoords(Mouse.GetPosition(Display));
                if (selection is Bone bone)
                {
                    if ((bone.ComputedTransform.TransformPoint(default) - msPos).LengthSquared() < 10 * 10)
                    {
                        grabbing = true;
                        relativePos = bone.ComputedTransform.TransformPoint(default) - msPos;
                    }
                }
            };
            Display.MouseButtonReleased += (sender, e) =>
            {
                grabbing = false;
                askForUpdate = true;
            };
            Texture backTexture;
            {
                var img = new Image(2, 2, new Color(100, 100, 100));
                img.SetPixel(0, 0, new Color(200, 200, 200));
                img.SetPixel(1, 1, new Color(200, 200, 200));
                backTexture = new Texture(img);
            }
            backRect.Texture = backTexture;
            backRect.TextureRect = new IntRect(0, 0, 100, 100);
            backTexture.Repeated = true;
            while (form.Visible)
            {
                var mousPosition = Display.MapPixelToCoords(Mouse.GetPosition(Display));
                Display.DispatchEvents();
                DynamicObject.Update();

                segs.Clear();
                segs.Append(new Vertex(new Vector2f(-99999, 0), Color.Red));
                segs.Append(new Vertex(new Vector2f(99999, 0), Color.Red));
                segs.Append(new Vertex(new Vector2f(0, -99999), Color.Green));
                segs.Append(new Vertex(new Vector2f(0, 99999), Color.Green));

                if (selectedBone != null)
                {
                    var bone = selectedBone;
                    List<FloatRect> localRects = new List<FloatRect>();
                    List<Vector2f> pts = new List<Vector2f>();
                    var tr = bone.ComputedTransform;
                    if (bone.AttachedSprite != null)
                    {
                        var sprite = bone.AttachedSprite;
                        var sptr = tr * sprite.InternalRect.Transform;
                        pts.Add(sptr.TransformPoint(sprite.InternalRect.GetLocalBounds().TopLeft()));
                        pts.Add(sptr.TransformPoint(sprite.InternalRect.GetLocalBounds().TopRight()));
                        pts.Add(sptr.TransformPoint(sprite.InternalRect.GetLocalBounds().BotLeft()));
                        pts.Add(sptr.TransformPoint(sprite.InternalRect.GetLocalBounds().BotRight()));
                        localRects.Add(sprite.InternalRect.GetGlobalBounds());
                        var spriteBounds = sprite.InternalRect.GetLocalBounds();
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.TopLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.TopRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.TopRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.BotRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.BotRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.BotLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.BotLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex(sptr.TransformPoint(spriteBounds.TopLeft()), new Color(255, 130, 0)));
                    }
                    if (localRects.Count > 0)
                    {
                        Vector2f topleft = localRects.First().TopLeft();
                        Vector2f botright = localRects.First().BotRight();
                        foreach (var rect in localRects)
                        {
                            topleft.X = Utilities.Min(topleft.X, rect.TopLeft().X);
                            topleft.Y = Utilities.Min(topleft.Y, rect.TopLeft().Y);
                            botright.X = Utilities.Max(botright.X, rect.BotRight().X);
                            botright.Y = Utilities.Max(botright.Y, rect.BotRight().Y);
                        }
                        segs.Append(new Vertex(tr.TransformPoint(topleft.X, topleft.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(botright.X, topleft.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(botright.X, topleft.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(botright.X, botright.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(botright.X, botright.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(topleft.X, botright.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(topleft.X, botright.Y), Color.Black));
                        segs.Append(new Vertex(tr.TransformPoint(topleft.X, topleft.Y), Color.Black));
                    }
                    if (pts.Count > 0)
                    {
                        Vector2f topleft;
                        Vector2f botright;
                        {
                            var box = Utilities.CreateRect(pts.ToArray());
                            topleft = box.TopLeft();
                            botright = box.BotRight();
                        }
                        segs.Append(new Vertex(new Vector2f(topleft.X, topleft.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(botright.X, topleft.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(botright.X, topleft.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(botright.X, botright.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(botright.X, botright.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(topleft.X, botright.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(topleft.X, botright.Y), Color.Magenta));
                        segs.Append(new Vertex(new Vector2f(topleft.X, topleft.Y), Color.Magenta));
                    }
                    var tr2 = tr;
                    tr2.Translate(bone.Origin);
                    segs.Append(new Vertex(tr2.TransformPoint(-99999, 0), Color.Blue));
                    segs.Append(new Vertex(tr2.TransformPoint(99999, 0), Color.Blue));
                    segs.Append(new Vertex(tr2.TransformPoint(0, -99999), Color.Cyan));
                    segs.Append(new Vertex(tr2.TransformPoint(0, 99999), Color.Cyan));
                }
                if (grabbing)
                {
                    if (typeGrabbed == 0)
                        (selection as Bone).Position = mousPosition + relativePos;
                }
                if (selection is Resource && form.resSprite != null)
                    form.resSprite.Update(Chronometer.ElapsedTime);

                if (form.resDispl != null && form.resSprite != null)
                {
                    form.resDispl.Target.Clear(form.BackColor);

                    form.resDispl.Target.Draw(form.resSprite.InternalRect);

                    form.resDispl.Target.Display();
                }

                Display.Clear(Color.White);

                Display.Draw(backRect);

                Display.Draw(DynamicObject);

                Display.Draw(segs);

                Display.Display();
            }
        }

        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                try
                {
                    using (var stream = new System.IO.FileStream(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AnimMakerV2/params"), System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        Settings = (Options)formatter.Deserialize(stream);
                    }
                }
                catch (Exception)
                {
                    Settings = Options.Default;
                }
                askForUpdate = false;
                Clock autoSaveClock = new Clock();
                Application.EnableVisualStyles();
                form = new MainForm();
                Chronometer = new Chronometer();
                form.newObj();
                currentPath = null;
                selection = null;
                selectedKeys = null;
                selectedBone = null;
                selectedAnim = null;
                DynamicObject.Chronometer = Chronometer;
                font = new WGP.TEXT.Font(Properties.Resources.font, 16);
                textTimer = new WGP.TEXT.Text("", font, Color.Black);
                textTimer.Position = new Vector2f(10, 26);
                timeLineSegs = new VertexArray(PrimitiveType.Lines, 4);
                timeLineSegs[0] = new Vertex(new Vector2f(0, 30), Color.Black);
                timeLineSegs[1] = new Vertex(new Vector2f(9999, 30), Color.Black);
                timeLineSegs[2] = new Vertex(new Vector2f(), Color.Black);
                timeLineSegs[3] = new Vertex(new Vector2f(), Color.Black);
                seeking = false;
                keyControls = new List<KeyControl>();

                Display.SetVerticalSyncEnabled(true);

                var dispThread = new System.Threading.Thread(DisplLoop);
                Display.SetActive(false);
                Timeline.MouseButtonPressed += leftClick;

                if (args.Length > 0)
                {
                    var path = args[1];
                    form.OpenObject(path);
                }

                form.Show();
                ResizeTimeline();
                dispThread.Start();
                while (form.Visible)
                {
                    Application.DoEvents();
                    Timeline.DispatchEvents();
                    if (askForUpdate)
                    {
                        askForUpdate = false;
                        form.UpdateProp();
                    }
                    if (Settings.AutoFileSave && autoSaveClock.ElapsedTime > Settings.AutoFileTime.ToSFML())
                    {
                        autoSaveClock.Restart();
                        if (!System.IO.Directory.Exists(Settings.AutoFilePath))
                            System.IO.Directory.CreateDirectory(Settings.AutoFilePath);
                        System.Threading.ThreadStart save = () =>
                        {
                            System.IO.Stream stream = null;
                            try
                            {
                                stream = new System.IO.FileStream(System.IO.Path.Combine(Settings.AutoFilePath, CurrentID + ".wgdot"), System.IO.FileMode.Create, System.IO.FileAccess.Write);
                                DynamicObject.SaveAsTemplate(stream);
                            }
                            catch (Exception) { }
                            if (stream != null)
                                stream.Close();
                        };
                        System.Threading.Thread autoSaveThread = new System.Threading.Thread(save);
                        autoSaveThread.Start();
                    }

                    if (selectedAnim != null)
                    {
                        textTimer.String = DynamicObject.CurrentTime.AsSeconds().ToString("F") + " : " + selectedAnim.Duration.AsSeconds().ToString("F");
                        timeLineSegs[2] = new Vertex(new Vector2f(Utilities.Interpolation(
                            Utilities.Percent(DynamicObject.CurrentTime, Time.Zero, selectedAnim.Duration),
                            0,
                            timeLineDrawRect.Width), 30), Color.Black);
                        timeLineSegs[3] = new Vertex(new Vector2f(Utilities.Interpolation(
                            Utilities.Percent(DynamicObject.CurrentTime, Time.Zero, selectedAnim.Duration),
                            0,
                            timeLineDrawRect.Width), 9999), Color.Black);
                    }
                    if (selectedKeys != null)
                    {
                        Animation.Key key = null;
                        if (selection is Animation.Key k) key = k;
                        keyControls.Clear();
                        int count = 0;
                        foreach (var item in selectedKeys)
                        {
                            var tmp = new KeyControl(timeLineDrawRect.Height / 15);
                            if (key == item)
                                tmp.Color = Color.Yellow;
                            else
                                tmp.Color = new Color(100, 100, 100);
                            tmp.Position = new Vector2f(
                                Utilities.Interpolation(Utilities.Percent(item.Position, Time.Zero, selectedAnim.Duration), 0, timeLineDrawRect.Width),
                                Utilities.Interpolation(Utilities.Percent(item.Position, Time.Zero, selectedAnim.Duration), timeLineDrawRect.Top, timeLineDrawRect.BotLeft().Y)
                                );
                            if (count % 2 == 1)
                                tmp.Rotation = 45;
                            keyControls.Add(tmp);
                            count++;
                        }
                    }
                    if (seeking && selectedAnim != null)
                    {
                        var msPos = Timeline.MapPixelToCoords(Mouse.GetPosition(Timeline));
                        DynamicObject.CurrentTime = Utilities.Interpolation(Utilities.Percent(msPos.X, 0, timeLineDrawRect.Width), Time.Zero, selectedAnim.Duration);
                    }
                    if (!Mouse.IsButtonPressed(Mouse.Button.Left)) seeking = false;

                    Timeline.Clear(Color.White);

                    if (selectedAnim != null)
                    {
                        Timeline.Draw(textTimer);
                        Timeline.Draw(timeLineSegs);
                    }

                    if (selectedKeys != null)
                    {
                        foreach (var item in keyControls)
                        {
                            Timeline.Draw(item);
                        }
                    }

                    Timeline.Display();
                }
            }
            catch (Exception e)
            {
                new ThreadExceptionDialog(e).ShowDialog();
                if (MessageBox.Show("Tenter de sauvegarder l'objet ? ATTENTION : il est conseillé de ne pas écraser de fichier ; si la sauvegarde échoue, le fichier écrasé sera irrécupérable !", "Sauvegarde des modifications", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    form.SaveObject();
                Environment.Exit(1);
            }
        }

        #endregion Private Methods

        /*********************************************************************************************************************************/
    }
}