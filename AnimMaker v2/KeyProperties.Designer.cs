namespace AnimMaker_v2
{
    partial class KeyProperties
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.keysList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RotFunc = new System.Windows.Forms.Button();
            this.ScaFunc = new System.Windows.Forms.Button();
            this.OriFunc = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.PosX = new System.Windows.Forms.NumericUpDown();
            this.OriginX = new System.Windows.Forms.NumericUpDown();
            this.PosY = new System.Windows.Forms.NumericUpDown();
            this.OriginY = new System.Windows.Forms.NumericUpDown();
            this.ScaleX = new System.Windows.Forms.NumericUpDown();
            this.ScaleY = new System.Windows.Forms.NumericUpDown();
            this.Rotation = new System.Windows.Forms.NumericUpDown();
            this.PosFunc = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.Opacity = new System.Windows.Forms.NumericUpDown();
            this.OpaFunc = new System.Windows.Forms.Button();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.keyColor = new System.Windows.Forms.Button();
            this.ColFunc = new System.Windows.Forms.Button();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.keyOColor = new System.Windows.Forms.Button();
            this.OColFunc = new System.Windows.Forms.Button();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.keyOTh = new System.Windows.Forms.NumericUpDown();
            this.OThFunc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opacity)).BeginInit();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyOTh)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.keysList);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1014, 771);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // keysList
            // 
            this.keysList.FormattingEnabled = true;
            this.keysList.Location = new System.Drawing.Point(3, 3);
            this.keysList.Name = "keysList";
            this.keysList.Size = new System.Drawing.Size(127, 134);
            this.keysList.TabIndex = 0;
            this.keysList.SelectedIndexChanged += new System.EventHandler(this.keysList_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ajouter une clé";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.time);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 172);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(211, 26);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position temporelle (sec) :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // time
            // 
            this.time.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.time.DecimalPlaces = 2;
            this.time.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.time.Location = new System.Drawing.Point(136, 3);
            this.time.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(72, 20);
            this.time.TabIndex = 1;
            this.time.ValueChanged += new System.EventHandler(this.time_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(255, 166);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transformations";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.10027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.10027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.10027F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.69919F));
            this.tableLayoutPanel1.Controls.Add(this.RotFunc, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ScaFunc, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.OriFunc, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PosX, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.OriginX, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PosY, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.OriginY, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.ScaleX, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ScaleY, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.Rotation, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.PosFunc, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 147);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RotFunc
            // 
            this.RotFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotFunc.Location = new System.Drawing.Point(204, 111);
            this.RotFunc.Name = "RotFunc";
            this.RotFunc.Size = new System.Drawing.Size(42, 33);
            this.RotFunc.TabIndex = 14;
            this.RotFunc.UseVisualStyleBackColor = true;
            this.RotFunc.Click += new System.EventHandler(this.RotFunc_Click);
            // 
            // ScaFunc
            // 
            this.ScaFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScaFunc.Location = new System.Drawing.Point(204, 75);
            this.ScaFunc.Name = "ScaFunc";
            this.ScaFunc.Size = new System.Drawing.Size(42, 30);
            this.ScaFunc.TabIndex = 13;
            this.ScaFunc.UseVisualStyleBackColor = true;
            this.ScaFunc.Click += new System.EventHandler(this.ScaFunc_Click);
            // 
            // OriFunc
            // 
            this.OriFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriFunc.Location = new System.Drawing.Point(204, 39);
            this.OriFunc.Name = "OriFunc";
            this.OriFunc.Size = new System.Drawing.Size(42, 30);
            this.OriFunc.TabIndex = 12;
            this.OriFunc.UseVisualStyleBackColor = true;
            this.OriFunc.Click += new System.EventHandler(this.OriFunc_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 36);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 36);
            this.label3.TabIndex = 1;
            this.label3.Text = "Origine";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 36);
            this.label4.TabIndex = 2;
            this.label4.Text = "Échelle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 39);
            this.label5.TabIndex = 3;
            this.label5.Text = "Rotation";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PosX
            // 
            this.PosX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PosX.DecimalPlaces = 2;
            this.PosX.Location = new System.Drawing.Point(70, 8);
            this.PosX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PosX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(61, 20);
            this.PosX.TabIndex = 4;
            this.PosX.ValueChanged += new System.EventHandler(this.PosX_ValueChanged);
            // 
            // OriginX
            // 
            this.OriginX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OriginX.DecimalPlaces = 2;
            this.OriginX.Location = new System.Drawing.Point(70, 44);
            this.OriginX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.OriginX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.OriginX.Name = "OriginX";
            this.OriginX.Size = new System.Drawing.Size(61, 20);
            this.OriginX.TabIndex = 5;
            this.OriginX.ValueChanged += new System.EventHandler(this.OriginX_ValueChanged);
            // 
            // PosY
            // 
            this.PosY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PosY.DecimalPlaces = 2;
            this.PosY.Location = new System.Drawing.Point(137, 8);
            this.PosY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.PosY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(61, 20);
            this.PosY.TabIndex = 6;
            this.PosY.ValueChanged += new System.EventHandler(this.PosY_ValueChanged);
            // 
            // OriginY
            // 
            this.OriginY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OriginY.DecimalPlaces = 2;
            this.OriginY.Location = new System.Drawing.Point(137, 44);
            this.OriginY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.OriginY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.OriginY.Name = "OriginY";
            this.OriginY.Size = new System.Drawing.Size(61, 20);
            this.OriginY.TabIndex = 7;
            this.OriginY.ValueChanged += new System.EventHandler(this.OriginY_ValueChanged);
            // 
            // ScaleX
            // 
            this.ScaleX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScaleX.DecimalPlaces = 2;
            this.ScaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleX.Location = new System.Drawing.Point(70, 80);
            this.ScaleX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ScaleX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.ScaleX.Name = "ScaleX";
            this.ScaleX.Size = new System.Drawing.Size(61, 20);
            this.ScaleX.TabIndex = 8;
            this.ScaleX.ValueChanged += new System.EventHandler(this.ScaleX_ValueChanged);
            // 
            // ScaleY
            // 
            this.ScaleY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ScaleY.DecimalPlaces = 2;
            this.ScaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleY.Location = new System.Drawing.Point(137, 80);
            this.ScaleY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ScaleY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.ScaleY.Name = "ScaleY";
            this.ScaleY.Size = new System.Drawing.Size(61, 20);
            this.ScaleY.TabIndex = 9;
            this.ScaleY.ValueChanged += new System.EventHandler(this.ScaleY_ValueChanged);
            // 
            // Rotation
            // 
            this.Rotation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.Rotation, 2);
            this.Rotation.DecimalPlaces = 2;
            this.Rotation.Location = new System.Drawing.Point(70, 117);
            this.Rotation.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Rotation.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.Rotation.Name = "Rotation";
            this.Rotation.Size = new System.Drawing.Size(128, 20);
            this.Rotation.TabIndex = 10;
            this.Rotation.ValueChanged += new System.EventHandler(this.Rotation_ValueChanged);
            // 
            // PosFunc
            // 
            this.PosFunc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PosFunc.Location = new System.Drawing.Point(204, 3);
            this.PosFunc.Name = "PosFunc";
            this.PosFunc.Size = new System.Drawing.Size(42, 30);
            this.PosFunc.TabIndex = 11;
            this.PosFunc.UseVisualStyleBackColor = true;
            this.PosFunc.Click += new System.EventHandler(this.PosFunc_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.Opacity);
            this.flowLayoutPanel3.Controls.Add(this.OpaFunc);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 376);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(255, 41);
            this.flowLayoutPanel3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 39);
            this.label6.TabIndex = 0;
            this.label6.Text = "Opacité";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Opacity
            // 
            this.Opacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Opacity.Location = new System.Drawing.Point(53, 10);
            this.Opacity.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Opacity.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Opacity.Name = "Opacity";
            this.Opacity.Size = new System.Drawing.Size(77, 20);
            this.Opacity.TabIndex = 1;
            this.Opacity.ValueChanged += new System.EventHandler(this.Opacity_ValueChanged);
            // 
            // OpaFunc
            // 
            this.OpaFunc.Location = new System.Drawing.Point(136, 3);
            this.OpaFunc.Name = "OpaFunc";
            this.OpaFunc.Size = new System.Drawing.Size(41, 33);
            this.OpaFunc.TabIndex = 12;
            this.OpaFunc.UseVisualStyleBackColor = true;
            this.OpaFunc.Click += new System.EventHandler(this.OpaFunc_Click);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label7);
            this.flowLayoutPanel4.Controls.Add(this.keyColor);
            this.flowLayoutPanel4.Controls.Add(this.ColFunc);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 423);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(255, 39);
            this.flowLayoutPanel4.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 39);
            this.label7.TabIndex = 0;
            this.label7.Text = "Couleur";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keyColor
            // 
            this.keyColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyColor.Location = new System.Drawing.Point(52, 8);
            this.keyColor.Name = "keyColor";
            this.keyColor.Size = new System.Drawing.Size(75, 23);
            this.keyColor.TabIndex = 1;
            this.keyColor.UseVisualStyleBackColor = true;
            this.keyColor.Click += new System.EventHandler(this.keyColor_Click);
            // 
            // ColFunc
            // 
            this.ColFunc.Location = new System.Drawing.Point(133, 3);
            this.ColFunc.Name = "ColFunc";
            this.ColFunc.Size = new System.Drawing.Size(41, 33);
            this.ColFunc.TabIndex = 13;
            this.ColFunc.UseVisualStyleBackColor = true;
            this.ColFunc.Click += new System.EventHandler(this.ColFunc_Click);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label8);
            this.flowLayoutPanel5.Controls.Add(this.keyOColor);
            this.flowLayoutPanel5.Controls.Add(this.OColFunc);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 468);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(255, 40);
            this.flowLayoutPanel5.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 39);
            this.label8.TabIndex = 0;
            this.label8.Text = "Couleur externe";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keyOColor
            // 
            this.keyOColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyOColor.Location = new System.Drawing.Point(90, 8);
            this.keyOColor.Name = "keyOColor";
            this.keyOColor.Size = new System.Drawing.Size(75, 23);
            this.keyOColor.TabIndex = 1;
            this.keyOColor.UseVisualStyleBackColor = true;
            this.keyOColor.Click += new System.EventHandler(this.keyOColor_Click);
            // 
            // OColFunc
            // 
            this.OColFunc.Location = new System.Drawing.Point(171, 3);
            this.OColFunc.Name = "OColFunc";
            this.OColFunc.Size = new System.Drawing.Size(41, 33);
            this.OColFunc.TabIndex = 13;
            this.OColFunc.UseVisualStyleBackColor = true;
            this.OColFunc.Click += new System.EventHandler(this.OColFunc_Click);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label9);
            this.flowLayoutPanel6.Controls.Add(this.keyOTh);
            this.flowLayoutPanel6.Controls.Add(this.OThFunc);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 514);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(255, 40);
            this.flowLayoutPanel6.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 39);
            this.label9.TabIndex = 0;
            this.label9.Text = "Épaisseur externe";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // keyOTh
            // 
            this.keyOTh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.keyOTh.DecimalPlaces = 2;
            this.keyOTh.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.keyOTh.Location = new System.Drawing.Point(100, 9);
            this.keyOTh.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.keyOTh.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.keyOTh.Name = "keyOTh";
            this.keyOTh.Size = new System.Drawing.Size(77, 20);
            this.keyOTh.TabIndex = 1;
            this.keyOTh.ValueChanged += new System.EventHandler(this.keyOTh_ValueChanged);
            // 
            // OThFunc
            // 
            this.OThFunc.Location = new System.Drawing.Point(183, 3);
            this.OThFunc.Name = "OThFunc";
            this.OThFunc.Size = new System.Drawing.Size(41, 33);
            this.OThFunc.TabIndex = 13;
            this.OThFunc.UseVisualStyleBackColor = true;
            this.OThFunc.Click += new System.EventHandler(this.OThFunc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 560);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Supprimer";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // KeyProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "KeyProperties";
            this.Size = new System.Drawing.Size(1014, 771);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Opacity)).EndInit();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyOTh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ListBox keysList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown PosX;
        private System.Windows.Forms.NumericUpDown OriginX;
        private System.Windows.Forms.NumericUpDown PosY;
        private System.Windows.Forms.NumericUpDown OriginY;
        private System.Windows.Forms.NumericUpDown ScaleX;
        private System.Windows.Forms.NumericUpDown ScaleY;
        private System.Windows.Forms.NumericUpDown Rotation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Opacity;
        private System.Windows.Forms.Button RotFunc;
        private System.Windows.Forms.Button ScaFunc;
        private System.Windows.Forms.Button OriFunc;
        private System.Windows.Forms.Button PosFunc;
        private System.Windows.Forms.Button OpaFunc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button keyColor;
        private System.Windows.Forms.Button ColFunc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button keyOColor;
        private System.Windows.Forms.Button OColFunc;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown keyOTh;
        private System.Windows.Forms.Button OThFunc;
    }
}
