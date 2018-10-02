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
        public static RenderWindow Display;
        public static RenderWindow Timeline;
        public static ResourceManager Resources;
        public static SFDynamicObject DynamicObject;
        public static Chronometer Chronometer;
        public static MainForm form;
        public static object selection;
        public static List<Animation.Key> selectedKeys;
        public static Animation selectedAnim;
        public static Bone selectedBone;
        public static int createdBones;
        public static int createdResources;
        public static int createdAnimations;
        public static WGP.TEXT.Font font;
        public static WGP.TEXT.Text textTimer;
        public static VertexArray timeLineSegs;
        public static FloatRect timeLineDrawRect;
        public static List<KeyControl> keyControls;
        public static bool seeking;
        
        static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                form = new MainForm();
                Chronometer = new Chronometer();
                DynamicObject = new SFDynamicObject();
                Resources = new ResourceManager();
                form.newObj();
                form.newRes();
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
                    for (int i = 0; i < args.Length; i++)
                    {
                        var curr = args[i];
                        if (curr == "/r")
                        {
                            i++;
                            var path = args[i];
                            form.OpenRes(path);
                        }
                        else if (curr == "/o")
                        {
                            i++;
                            var path = args[i];
                            form.OpenObject(path);
                        }
                    }
                }

                form.Show();
                ResizeTimeline();
                dispThread.Start();
                while (form.Visible)
                {
                    Application.DoEvents();
                    Timeline.DispatchEvents();

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
                    if (seeking)
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
        static void DisplLoop()
        {
            Display.SetActive();
            VertexArray segs = new VertexArray(PrimitiveType.Lines);

            while (form.Visible)
            {
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
                    foreach (var sprite in bone.AttachedSprites)
                    {
                        pts.Add((tr * sprite.Value.Transform).TransformPoint(sprite.Value.GetLocalBounds().TopLeft()));
                        pts.Add((tr * sprite.Value.Transform).TransformPoint(sprite.Value.GetLocalBounds().TopRight()));
                        pts.Add((tr * sprite.Value.Transform).TransformPoint(sprite.Value.GetLocalBounds().BotLeft()));
                        pts.Add((tr * sprite.Value.Transform).TransformPoint(sprite.Value.GetLocalBounds().BotRight()));
                    }
                    foreach (var sprite in bone.AttachedSprites)
                    {
                        localRects.Add(sprite.Value.GetGlobalBounds());
                        var spriteBounds = sprite.Value.GetLocalBounds();
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.TopLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.TopRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.TopRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.BotRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.BotRight()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.BotLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.BotLeft()), new Color(255, 130, 0)));
                        segs.Append(new Vertex((tr * sprite.Value.Transform).TransformPoint(spriteBounds.TopLeft()), new Color(255, 130, 0)));
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

                Display.Clear(Color.White);

                Display.Draw(DynamicObject);

                Display.Draw(segs);

                Display.Display();
            }
        }
        /*********************************************************************************************************************************/
        public static void ResizeTimeline()
        {
            timeLineDrawRect = new FloatRect();
            timeLineDrawRect.Top = 30 + Timeline.Size.Y / 15;
            timeLineDrawRect.Width = Timeline.Size.X;
            timeLineDrawRect.Height = Timeline.Size.Y - 30 - Timeline.Size.Y / 7.5f;
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
        public static void RemoveBone()
        {
            var bone = (Bone)selection;
            DynamicObject.BonesHierarchy.Remove(bone);
            DynamicObject.MasterBones.Remove(bone);
            DynamicObject.BonesHierarchy.Remove(bone);
            var par = DynamicObject.BonesHierarchy.Find((parent) => parent.ChildBones.Contains(bone));
            if (par != null)
                par.ChildBones.Remove(bone);
            foreach (var child in bone.ChildBones)
            {
                DynamicObject.MasterBones.Add(child);
            }
            selection = null;

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
                    Resources.Add(key, new ResourceManager.Resource() { Path = file, Data = new Texture(file) });
                    selection = Resources.First((pair) => pair.Key == key);
                }
                DynamicObject.ReloadManager();
                form.UpdateInterface();
            }
        }
        public static void RemoveResource()
        {
            var pair = (KeyValuePair<string, ResourceManager.Resource>)selection;
            Resources.Remove(pair.Key);

            selection = null;

            DynamicObject.ReloadManager();
            form.UpdateInterface();
        }
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
        public static void RemoveAnimation()
        {
            var anim = (Animation)selection;
            DynamicObject.Animations.Remove(anim);
            selection = null;
            DynamicObject.ResetAnimation();

            form.UpdateInterface();
        }
    }
}
