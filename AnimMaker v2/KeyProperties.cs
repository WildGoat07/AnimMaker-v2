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
    public partial class KeyProperties : UserControl
    {
        #region Private Fields

        private static int[] customColors = null;

        private bool init;

        #endregion Private Fields

        #region Public Constructors

        public KeyProperties()
        {
            init = false;
            InitializeComponent();

            if (Program.selection != null)
            {
                var keys = Program.selectedKeys;

                var selectKey = (Animation.Key)Program.selection;

                int count = 1;
                foreach (var key in keys)
                {
                    keysList.Items.Add(count.ToString("00") + " : " + key.Position.AsSeconds().ToString("F"));
                    count++;
                    if (selectKey == key)
                        keysList.SelectedIndex = count - 2;
                }

                time.Value = (decimal)selectKey.Position.AsSeconds();
                PosX.Value = (decimal)selectKey.Transform.Position.X;
                PosY.Value = (decimal)selectKey.Transform.Position.Y;
                OriginX.Value = (decimal)selectKey.Transform.Origin.X;
                OriginY.Value = (decimal)selectKey.Transform.Origin.Y;
                ScaleX.Value = (decimal)selectKey.Transform.Scale.X;
                ScaleY.Value = (decimal)selectKey.Transform.Scale.Y;
                Rotation.Value = (decimal)selectKey.Transform.Rotation;
                Opacity.Value = selectKey.Opacity;
                switch (selectKey.PosFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        PosFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        PosFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        PosFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        PosFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        PosFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.OriginFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        OriFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        OriFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        OriFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        OriFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        OriFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.ScaleFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        ScaFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        ScaFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        ScaFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        ScaFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        ScaFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.RotFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        RotFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        RotFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        RotFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        RotFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        RotFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.OpacityFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        OpaFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        OpaFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        OpaFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        OpaFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        OpaFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.ColorFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        ColFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        ColFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        ColFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        ColFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        ColFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.OutlineColorFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        OColFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        OColFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        OColFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        OColFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        OColFunc.Image = Properties.Resources.bin;
                        break;
                }
                switch (selectKey.OutlineThicknessFunction)
                {
                    case Animation.Key.Fct.LINEAR:
                        OThFunc.Image = Properties.Resources.linear;
                        break;

                    case Animation.Key.Fct.POWER:
                        OThFunc.Image = Properties.Resources.pow;
                        break;

                    case Animation.Key.Fct.ROOT:
                        OThFunc.Image = Properties.Resources.root;
                        break;

                    case Animation.Key.Fct.GAUSS:
                        OThFunc.Image = Properties.Resources.gauss;
                        break;

                    case Animation.Key.Fct.BINARY:
                        OThFunc.Image = Properties.Resources.bin;
                        break;
                }
                keyColor.Image = (Bitmap)new SFML.Graphics.Image(100, 100, selectKey.Color);
                keyOColor.Image = (Bitmap)new SFML.Graphics.Image(100, 100, selectKey.OutlineColor);
                keyOTh.Value = (decimal)selectKey.OutlineThickness;
            }
            init = true;
        }

        #endregion Public Constructors

        #region Private Methods

        private void button1_Click(object sender, EventArgs e)
        {
            Program.selectedKeys.Add(new Animation.Key() { Position = Program.DynamicObject.CurrentTime, Transform = new Transformable(), Opacity = 255 });

            Program.form.UpdateProp();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.selectedKeys.Remove((Animation.Key)Program.selection);

            Program.form.UpdateProp();
        }

        private void ColFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.ColorFunction;
            tmp.Coefficient = key.ColorFctCoeff;

            tmp.Start();

            key.ColorFunction = tmp.Function;
            key.ColorFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void keyColor_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var dialog = new ColorDialog();
            dialog.CustomColors = customColors;
            dialog.Color = System.Drawing.Color.FromArgb(key.Color.A, key.Color.R, key.Color.G, key.Color.B);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                key.Color = new SFML.Graphics.Color(dialog.Color.R, dialog.Color.G, dialog.Color.B, dialog.Color.A);
                Program.form.UpdateProp();
            }
            customColors = dialog.CustomColors;
        }

        private void keyOColor_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var dialog = new ColorDialog();
            dialog.CustomColors = customColors;
            dialog.Color = System.Drawing.Color.FromArgb(key.OutlineColor.A, key.OutlineColor.R, key.OutlineColor.G, key.OutlineColor.B);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                key.OutlineColor = new SFML.Graphics.Color(dialog.Color.R, dialog.Color.G, dialog.Color.B, dialog.Color.A);
                Program.form.UpdateProp();
            }
            customColors = dialog.CustomColors;
        }

        private void keyOTh_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            key.OutlineThickness = (float)keyOTh.Value;
        }

        private void keysList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init && keysList.SelectedIndex > -1)
            {
                var keys = Program.selectedKeys;
                Program.selection = keys[int.Parse(keysList.Items[keysList.SelectedIndex].ToString().Substring(0, 2)) - 1];

                Program.form.UpdateProp();
            }
        }

        private void OColFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.OutlineColorFunction;
            tmp.Coefficient = key.OutlineColorFctCoeff;

            tmp.Start();

            key.OutlineColorFunction = tmp.Function;
            key.OutlineColorFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void Opacity_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            key.Opacity = (byte)Opacity.Value;
        }

        private void OpaFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.OpacityFunction;
            tmp.Coefficient = key.OpacityFctCoeff;

            tmp.Start();

            key.OpacityFunction = tmp.Function;
            key.OpacityFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void OriFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.OriginFunction;
            tmp.Coefficient = key.OriginFctCoeff;

            tmp.Start();

            key.OriginFunction = tmp.Function;
            key.OriginFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void OriginX_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Origin;

            vec.X = (float)OriginX.Value;

            key.Transform.Origin = vec;
        }

        private void OriginY_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Origin;

            vec.Y = (float)OriginY.Value;

            key.Transform.Origin = vec;
        }

        private void OThFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.OutlineThicknessFunction;
            tmp.Coefficient = key.OutlineThicknessFctCoeff;

            tmp.Start();

            key.OutlineThicknessFunction = tmp.Function;
            key.OutlineThicknessFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void PosFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.PosFunction;
            tmp.Coefficient = key.PosFctCoeff;

            tmp.Start();

            key.PosFunction = tmp.Function;
            key.PosFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void PosX_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Position;

            vec.X = (float)PosX.Value;

            key.Transform.Position = vec;
        }

        private void PosY_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Position;

            vec.Y = (float)PosY.Value;

            key.Transform.Position = vec;
        }

        private void Rotation_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            key.Transform.Rotation = (float)Rotation.Value;
        }

        private void RotFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.RotFunction;
            tmp.Coefficient = key.RotFctCoeff;

            tmp.Start();

            key.RotFunction = tmp.Function;
            key.RotFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void ScaFunc_Click(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;
            var tmp = new FunctionDialog();
            tmp.Function = key.ScaleFunction;
            tmp.Coefficient = key.ScaleFctCoeff;

            tmp.Start();

            key.ScaleFunction = tmp.Function;
            key.ScaleFctCoeff = tmp.Coefficient;

            Program.form.UpdateProp();
        }

        private void ScaleX_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Scale;

            vec.X = (float)ScaleX.Value;

            key.Transform.Scale = vec;
        }

        private void ScaleY_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            var vec = key.Transform.Scale;

            vec.Y = (float)ScaleY.Value;

            key.Transform.Scale = vec;
        }

        private void time_ValueChanged(object sender, EventArgs e)
        {
            var key = (Animation.Key)Program.selection;

            key.Position = Time.FromSeconds((float)time.Value);
        }

        #endregion Private Methods
    }
}