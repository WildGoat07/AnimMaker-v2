using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

        public static bool askForUpdate;
        public static bool ChangingEventArea;
        public static Chronometer Chronometer;
        public static int createdAnimations;
        public static int createdBones;
        public static int createdEvents;
        public static int createdCategories;
        public static Guid CurrentID;
        public static string currentPath;
        public static RenderWindow Display;
        public static SFDynamicObject DynamicObject;
        public static WGP.TEXT.Font font;
        public static WGP.TEXT.Font smallFont;
        public static MainForm form;
        public static Gizmo Gizmo;
        public static List<KeyControl> keyControls;
        public static DynamicObjectBuilder Manager;
        public static ConcurrentQueue<Notification> Notifications;
        public static bool seeking;
        public static Animation selectedAnim;
        public static Bone selectedBone;
        public static EventTrigger selectedEvent;
        public static List<Animation.Key> selectedKeys;
        public static object selection;
        public static Options Settings;
        public static WGP.TEXT.Text textTimer;
        public static RenderWindow Timeline;
        public static FloatRect timeLineDrawRect;
        public static VertexArray timeLineSegs;

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
            selectedAnim = null;
            DynamicObject.ResetAnimation();

            form.UpdateInterface();
        }

        public static void RemoveBone()
        {
            var bone = (Bone)selection;
            DynamicObject.BonesHierarchy.Remove(bone);
            DynamicObject.MasterBones.Remove(bone);
            try
            {
                var par = DynamicObject.BonesHierarchy.First((parent) => parent.Children.Contains(bone));
                if (par != null)
                    par.Children.Remove(bone);
            }
            catch (Exception) { }
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
            Vector2f areaPt1 = default, areaPt2 = default;
            bool clickedOnce = false;
            RectangleShape EventAreaDisp = new RectangleShape() { FillColor = new Color(255, 0, 0, 128) };
            VertexArray DrawnArea = new VertexArray(PrimitiveType.LineStrip);
            DrawnArea.Append(new Vertex(default, Color.White));
            DrawnArea.Append(new Vertex(default, Color.White));
            DrawnArea.Append(new Vertex(default, Color.White));
            DrawnArea.Append(new Vertex(default, Color.White));
            DrawnArea.Append(new Vertex(default, Color.White));
            RectangleShape backNotif = new RectangleShape();
            backNotif.OutlineColor = Color.Black;
            backNotif.OutlineThickness = -1;
            WGP.TEXT.Text textNotif = new WGP.TEXT.Text("", smallFont, Color.Black);
            Transform GetParentTransform(Bone bone) => bone.ComputedTransform * bone.InverseTransform;
            Transform GetParentTransformWithKey(Bone bone, Animation.Key key) => bone.ComputedTransform * new Transformable()
            { Position = bone.Position + key.Transform.Position, Origin = bone.Origin + key.Transform.Origin, Rotation = bone.Rotation + key.Transform.Rotation, Scale = bone.Scale * key.Transform.Scale }.InverseTransform;
            Transform TransformWithoutOri(Bone bone) => bone.ComputedTransform * new Transformable() { Origin = -bone.Origin }.Transform;
            Transform TransformWithoutOriWithKey(Bone bone, Animation.Key key) => bone.ComputedTransform * new Transformable() { Origin = -bone.Origin - key.Transform.Origin }.Transform;
            Transform GetPositionTransform(Bone bone) => bone.ComputedTransform * bone.InverseTransform * new Transformable() { Position = bone.Position }.Transform;
            Transform GetPositionTransformWithKey(Bone bone, Animation.Key key) => bone.ComputedTransform * new Transformable()
            { Position = bone.Position + key.Transform.Position, Origin = bone.Origin + key.Transform.Origin, Rotation = bone.Rotation + key.Transform.Rotation, Scale = bone.Scale * key.Transform.Scale }.InverseTransform
            * new Transformable() { Position = bone.Position + key.Transform.Position }.Transform;
            Display.SetActive();
            VertexArray segs = new VertexArray(PrimitiveType.Lines);
            var backRect = new RectangleShape(new Vector2f(2000, 2000)) { Origin = new Vector2f(1000, 1000) };
            int typeGrabbed = 0;
            bool grabbing = false;
            Vector2f basePt2 = default;
            Vector2f basePt = default;
            Vector2f baseOri = default;
            Vector2f basePos = default;
            Vector2f baseSca = default;
            float baseRot = default;
            Vector2f baseOriK = default;
            Vector2f basePosK = default;
            Vector2f baseScaK = default;
            float baseRotK = default;
            Angle baseAngle = default;
            Transform baseTr = default;
            Transform baseTr2 = default;
            bool wasPlaying = false;
            bool grabbingAnim = false;
            Display.MouseButtonPressed += (sender, e) =>
            {
                var msPos = Display.MapPixelToCoords(Mouse.GetPosition(Display));
                if (selection is Bone bone)
                {
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.POSITION)
                    {
                        typeGrabbed = 0;
                        grabbing = true;
                        baseTr = GetParentTransform(bone);
                        basePos = bone.Position;
                        basePt = baseTr.GetInverse().TransformPoint(msPos);
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.ORIGIN)
                    {
                        typeGrabbed = 1;
                        grabbing = true;
                        baseTr = TransformWithoutOri(bone);
                        baseTr2 = GetParentTransform(bone);
                        basePt2 = baseTr.GetInverse().TransformPoint(msPos);
                        basePt = baseTr2.GetInverse().TransformPoint(msPos);
                        baseOri = bone.Origin;
                        basePos = bone.Position;
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.SCALE)
                    {
                        typeGrabbed = 2;
                        grabbing = true;
                        baseTr = GetPositionTransform(bone);
                        basePt = baseTr.GetInverse().TransformPoint(msPos);
                        baseSca = bone.Scale;
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.ROTATION)
                    {
                        typeGrabbed = 3;
                        grabbing = true;
                        baseTr = GetPositionTransform(bone);
                        baseAngle = baseTr.GetInverse().TransformPoint(msPos).GetAngle();
                        baseRot = bone.Rotation;
                    }
                }
                if (selection is Animation.Key key)
                {
                    grabbingAnim = true;
                    wasPlaying = !Chronometer.Paused;
                    Chronometer.Paused = true;
                    DynamicObject.CurrentTime = key.Position;
                    DynamicObject.Update();
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.POSITION)
                    {
                        typeGrabbed = 10;
                        grabbing = true;
                        baseTr = GetPositionTransformWithKey(selectedBone, key);
                        basePosK = key.Transform.Position;
                        basePos = selectedBone.Position;
                        basePt = baseTr.GetInverse().TransformPoint(msPos);
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.ORIGIN)
                    {
                        typeGrabbed = 11;
                        grabbing = true;
                        baseTr = TransformWithoutOriWithKey(selectedBone, key);
                        baseTr2 = GetPositionTransformWithKey(selectedBone, key);
                        basePt2 = baseTr.GetInverse().TransformPoint(msPos);
                        basePt = baseTr2.GetInverse().TransformPoint(msPos);
                        baseOri = selectedBone.Origin;
                        basePos = selectedBone.Position;
                        baseOriK = key.Transform.Origin;
                        basePosK = key.Transform.Position;
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.SCALE)
                    {
                        typeGrabbed = 12;
                        grabbing = true;
                        baseTr = GetPositionTransformWithKey(selectedBone, key);
                        basePt = baseTr.GetInverse().TransformPoint(msPos);
                        baseSca = selectedBone.Scale;
                        baseScaK = key.Transform.Scale;
                    }
                    if (Gizmo.GetSelection(msPos) == Gizmo.TransformType.ROTATION)
                    {
                        typeGrabbed = 13;
                        grabbing = true;
                        baseTr = GetPositionTransformWithKey(selectedBone, key);
                        baseAngle = baseTr.GetInverse().TransformPoint(msPos).GetAngle();
                        baseRotK = key.Transform.Rotation;
                    }
                }
                if (ChangingEventArea)
                {
                    clickedOnce = true;
                    areaPt1 = msPos;
                }
            };
            Display.MouseButtonReleased += (sender, e) =>
            {
                var msPos = Display.MapPixelToCoords(Mouse.GetPosition(Display));
                grabbing = false;
                askForUpdate = true;

                if (wasPlaying && grabbingAnim)
                    Chronometer.Paused = false;
                grabbingAnim = false;
                if (ChangingEventArea)
                {
                    ChangingEventArea = false;
                    areaPt2 = msPos;
                    if (clickedOnce)
                        ((EventTrigger)selection).Area = Utilities.CreateRect(areaPt1, areaPt2);
                    clickedOnce = false;
                }
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
                var mousePosition = Display.MapPixelToCoords(Mouse.GetPosition(Display));
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
                    var key = selection as Animation.Key;
                    List<FloatRect> localRects = new List<FloatRect>();
                    List<Vector2f> pts = new List<Vector2f>();
                    Transform tr;
                    if (key != null)
                        tr = GetPositionTransformWithKey(bone, key);
                    else
                        tr = bone.ComputedTransform;
                    Transform tr3 = bone.ComputedTransform;
                    if (bone.AttachedSprite != null)
                    {
                        var sprite = bone.AttachedSprite;
                        var sptr = tr3 * sprite.InternalRect.Transform;
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
                    var tr2 = TransformWithoutOri(selectedBone);
                    if (key != null)
                        tr2 = TransformWithoutOriWithKey(selectedBone, key);
                    segs.Append(new Vertex(tr2.TransformPoint(-99999, 0), Color.Blue));
                    segs.Append(new Vertex(tr2.TransformPoint(99999, 0), Color.Blue));
                    segs.Append(new Vertex(tr2.TransformPoint(0, -99999), Color.Cyan));
                    segs.Append(new Vertex(tr2.TransformPoint(0, 99999), Color.Cyan));
                }
                Gizmo.Display = Gizmo.DisplayMode.NONE;
                if (grabbing)
                {
                    if (typeGrabbed == 0)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.XY;
                        var bone = selection as Bone;
                        bone.Position = baseTr.GetInverse().TransformPoint(mousePosition) - basePt + basePos;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            bone.Position = new Vector2f(bone.Position.X, basePos.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            bone.Position = new Vector2f(basePos.X, bone.Position.Y);
                    }
                    if (typeGrabbed == 10)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.XY;
                        var key = selection as Animation.Key;
                        key.Transform.Position = baseTr.GetInverse().TransformPoint(mousePosition) - basePt + basePosK;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            key.Transform.Position = new Vector2f(key.Transform.Position.X, basePosK.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            key.Transform.Position = new Vector2f(basePosK.X, key.Transform.Position.Y);
                    }
                    if (typeGrabbed == 1)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.XY;
                        var bone = selection as Bone;
                        bone.Origin = baseOri + baseTr.GetInverse().TransformPoint(mousePosition) - basePt2;
                        bone.Position = baseTr2.GetInverse().TransformPoint(mousePosition) - basePt + basePos;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            bone.Origin = new Vector2f(bone.Origin.X, baseOri.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            bone.Origin = new Vector2f(baseOri.X, bone.Origin.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            bone.Position = new Vector2f(bone.Position.X, basePos.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            bone.Position = new Vector2f(basePos.X, bone.Position.Y);
                    }
                    if (typeGrabbed == 11)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.XY;
                        var key = selection as Animation.Key;
                        key.Transform.Origin = baseOriK + baseTr.GetInverse().TransformPoint(mousePosition) - basePt2;
                        key.Transform.Position = baseTr2.GetInverse().TransformPoint(mousePosition) - basePt + basePosK;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            key.Transform.Origin = new Vector2f(key.Transform.Origin.X, baseOriK.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            key.Transform.Origin = new Vector2f(baseOriK.X, key.Transform.Origin.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.X))
                            key.Transform.Position = new Vector2f(key.Transform.Position.X, basePosK.Y);
                        if (Keyboard.IsKeyPressed(Keyboard.Key.Y))
                            key.Transform.Position = new Vector2f(basePosK.X, key.Transform.Position.Y);
                    }
                    if (typeGrabbed == 2)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.MAJ;
                        var bone = selection as Bone;
                        Vector2f coeff = baseTr.GetInverse().TransformPoint(mousePosition);
                        coeff.X /= basePt.X;
                        coeff.Y /= basePt.Y;
                        coeff.X = (coeff.X - 1) / 3 + 1;
                        coeff.Y = (coeff.Y - 1) / 3 + 1;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                            coeff = new Vector2f(Utilities.Min(coeff.X, coeff.Y), Utilities.Min(coeff.X, coeff.Y));
                        var sc = new Vector2f(baseSca.X * coeff.X, baseSca.Y * coeff.Y);
                        bone.Scale = sc;
                    }
                    if (typeGrabbed == 12)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.MAJ;
                        var key = selection as Animation.Key;
                        Vector2f coeff = baseTr.GetInverse().TransformPoint(mousePosition);
                        coeff.X /= basePt.X;
                        coeff.Y /= basePt.Y;
                        coeff.X = (coeff.X - 1) / 3 + 1;
                        coeff.Y = (coeff.Y - 1) / 3 + 1;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                            coeff = new Vector2f(Utilities.Min(coeff.X, coeff.Y), Utilities.Min(coeff.X, coeff.Y));
                        var sc = new Vector2f(baseScaK.X * coeff.X, baseScaK.Y * coeff.Y);
                        key.Transform.Scale = sc;
                    }
                    if (typeGrabbed == 3)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.MAJ;
                        var bone = selection as Bone;
                        Angle addAngle = baseTr.GetInverse().TransformPoint(mousePosition).GetAngle() - baseAngle;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                            addAngle -= addAngle % (Angle.Loop / 8);
                        bone.Rotation = (baseRot + addAngle.Degree) % 360;
                    }
                    if (typeGrabbed == 13)
                    {
                        Gizmo.Display = Gizmo.DisplayMode.MAJ;
                        var key = selection as Animation.Key;
                        Angle addAngle = baseTr.GetInverse().TransformPoint(mousePosition).GetAngle() - baseAngle;
                        if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) || Keyboard.IsKeyPressed(Keyboard.Key.RShift))
                            addAngle -= addAngle % (Angle.Loop / 8);
                        key.Transform.Rotation = (baseRotK + addAngle.Degree) % 360;
                    }
                }
                if (selection is Resource && form.resSprite != null)
                    form.resSprite.Update(Chronometer.ElapsedTime);
                {
                    if (selection is Bone bone)
                    {
                        Gizmo.Position = GetPositionTransform(bone).TransformPoint(default);
                    }
                    if (selection is Animation.Key key)
                    {
                        Gizmo.Position = GetPositionTransformWithKey(selectedBone, key).TransformPoint(default);
                    }
                }

                if (form.resDispl != null && form.resSprite != null)
                {
                    form.resDispl.Target.Clear(form.BackColor);

                    form.resDispl.Target.Draw(form.resSprite.InternalRect);

                    form.resDispl.Target.Display();
                }
                if (selectedEvent != null)
                {
                    EventAreaDisp.Position = selectedEvent.Area.TopLeft();
                    EventAreaDisp.Size = selectedEvent.Area.Size();
                }
                if (clickedOnce)
                {
                    DrawnArea[0] = new Vertex(areaPt1, Color.White);
                    DrawnArea[1] = new Vertex(mousePosition.OnlyX() + areaPt1.OnlyY(), Color.White);
                    DrawnArea[2] = new Vertex(mousePosition, Color.White);
                    DrawnArea[3] = new Vertex(mousePosition.OnlyY() + areaPt1.OnlyX(), Color.White);
                    DrawnArea[4] = new Vertex(areaPt1, Color.White);
                }

                Display.Clear(Color.White);

                Display.Draw(backRect);

                Display.Draw(DynamicObject);

                if (selectedEvent != null)
                {
                    Display.Draw(EventAreaDisp);
                }
                if (clickedOnce)
                {
                    Display.Draw(DrawnArea, new RenderStates(new BlendMode(BlendMode.Factor.OneMinusDstColor, BlendMode.Factor.OneMinusSrcColor)));
                }
                {
                    Vector2f offset = Display.MapPixelToCoords(new Vector2i(0, 0));
                    bool removeFirst = false;
                    foreach (var item in Notifications)
                    {
                        backNotif.FillColor = new Color(255, (byte)Utilities.Interpolation(Utilities.Percent(item.Chronometer.ElapsedTime, Time.Zero, item.LivingTime), 255f, 0f), 0);
                        backNotif.Position = offset;
                        textNotif.Position = new Vector2f(5, 5 + textNotif.Font.CharSize) + offset;
                        offset.Y += 10 + textNotif.Font.CharSize;
                        textNotif.String = item.Description;
                        backNotif.Size = new Vector2f(10 + textNotif.GetGlobalBounds().Width, 10 + textNotif.Font.CharSize);
                        Display.Draw(backNotif);
                        Display.Draw(textNotif);
                        if (item.Chronometer.ElapsedTime > item.LivingTime || Notifications.Count > 10)
                            removeFirst = true;
                    }
                    Notification notif;
                    if (removeFirst)
                        Notifications.TryDequeue(out notif);
                }

                Display.Draw(segs);

                if (selection is Bone b)
                {
                    if ((GetPositionTransform(b).TransformPoint(default) - mousePosition).LengthSquared() < 100 * 100 || grabbing)
                        Display.Draw(Gizmo);
                }
                if (selection is Animation.Key k)
                {
                    if ((GetPositionTransformWithKey(selectedBone, k).TransformPoint(default) - mousePosition).LengthSquared() < 100 * 100 || grabbing)
                        Display.Draw(Gizmo);
                }

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
                ChangingEventArea = false;
                Notifications = new ConcurrentQueue<Notification>();
                askForUpdate = false;
                Clock autoSaveClock = new Clock();
                Application.EnableVisualStyles();
                form = new MainForm();
                Chronometer = new Chronometer();
                Gizmo = new Gizmo();
                form.newObj();
                currentPath = null;
                selection = null;
                selectedKeys = null;
                selectedBone = null;
                selectedEvent = null;
                selectedAnim = null;
                DynamicObject.Chronometer = Chronometer;
                font = new WGP.TEXT.Font(Properties.Resources.font, 16);
                smallFont = new WGP.TEXT.Font(Properties.Resources.font, 11);
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
                    var path = args[0];
                    form.OpenObject(path);
                }

                form.Show();
                ResizeTimeline();
                dispThread.Start();
                RectangleShape eventPosition = new RectangleShape(new Vector2f(10, 9999)) { Origin = new Vector2f(5, 0), FillColor = Color.Red };
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
                        void save()
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
                        }
                        System.Threading.Thread autoSaveThread = new System.Threading.Thread(save);
                        autoSaveThread.Start();
                    }
                    if (selectedEvent != null)
                    {
                        eventPosition.Position = new Vector2f(Utilities.Interpolation(
                            Utilities.Percent(selectedEvent.Time, Time.Zero, selectedAnim.Duration),
                            0,
                            timeLineDrawRect.Width), 30);
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

                    if (selectedEvent != null)
                        Timeline.Draw(eventPosition);

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