namespace AnimMaker_v2
{
    partial class BoneProperties
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
            this.statut = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.children = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addChild = new System.Windows.Forms.Button();
            this.removeChild = new System.Windows.Forms.Button();
            this.addChildList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.boneStatut = new System.Windows.Forms.Label();
            this.boneName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dispId = new System.Windows.Forms.Label();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.spriteButton = new System.Windows.Forms.Button();
            this.addSprite = new System.Windows.Forms.Button();
            this.removeSprite = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.alphaMode = new System.Windows.Forms.RadioButton();
            this.multMode = new System.Windows.Forms.RadioButton();
            this.subsMode = new System.Windows.Forms.RadioButton();
            this.addMode = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.affectedCateg = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rotation)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statut
            // 
            this.statut.AutoSize = true;
            this.statut.Location = new System.Drawing.Point(3, 728);
            this.statut.Name = "statut";
            this.statut.Size = new System.Drawing.Size(0, 13);
            this.statut.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Location = new System.Drawing.Point(3, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 214);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Enfants";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.children);
            this.flowLayoutPanel2.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(208, 195);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // children
            // 
            this.children.FormattingEnabled = true;
            this.children.Location = new System.Drawing.Point(3, 3);
            this.children.Name = "children";
            this.children.Size = new System.Drawing.Size(202, 121);
            this.children.TabIndex = 0;
            this.children.SelectedIndexChanged += new System.EventHandler(this.children_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.addChild, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.removeChild, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.addChildList, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 130);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(202, 61);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // addChild
            // 
            this.addChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addChild.Location = new System.Drawing.Point(3, 33);
            this.addChild.Name = "addChild";
            this.addChild.Size = new System.Drawing.Size(95, 25);
            this.addChild.TabIndex = 0;
            this.addChild.Text = "Ajouter";
            this.addChild.UseVisualStyleBackColor = true;
            this.addChild.Click += new System.EventHandler(this.button1_Click);
            // 
            // removeChild
            // 
            this.removeChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeChild.Location = new System.Drawing.Point(104, 33);
            this.removeChild.Name = "removeChild";
            this.removeChild.Size = new System.Drawing.Size(95, 25);
            this.removeChild.TabIndex = 1;
            this.removeChild.Text = "Supprimer";
            this.removeChild.UseVisualStyleBackColor = true;
            this.removeChild.Click += new System.EventHandler(this.removeChild_Click);
            // 
            // addChildList
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.addChildList, 2);
            this.addChildList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addChildList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addChildList.FormattingEnabled = true;
            this.addChildList.Location = new System.Drawing.Point(3, 3);
            this.addChildList.Name = "addChildList";
            this.addChildList.Size = new System.Drawing.Size(196, 21);
            this.addChildList.TabIndex = 2;
            this.addChildList.SelectedIndexChanged += new System.EventHandler(this.addChildList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(214, 141);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transformations";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(208, 122);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "Origine";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 30);
            this.label4.TabIndex = 2;
            this.label4.Text = "Échelle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Rotation";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PosX
            // 
            this.PosX.DecimalPlaces = 2;
            this.PosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PosX.Location = new System.Drawing.Point(72, 3);
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
            this.PosX.Size = new System.Drawing.Size(63, 20);
            this.PosX.TabIndex = 4;
            this.PosX.ValueChanged += new System.EventHandler(this.PosX_ValueChanged);
            // 
            // OriginX
            // 
            this.OriginX.DecimalPlaces = 2;
            this.OriginX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginX.Location = new System.Drawing.Point(72, 33);
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
            this.OriginX.Size = new System.Drawing.Size(63, 20);
            this.OriginX.TabIndex = 5;
            this.OriginX.ValueChanged += new System.EventHandler(this.OriginX_ValueChanged);
            // 
            // PosY
            // 
            this.PosY.DecimalPlaces = 2;
            this.PosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PosY.Location = new System.Drawing.Point(141, 3);
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
            this.PosY.Size = new System.Drawing.Size(64, 20);
            this.PosY.TabIndex = 6;
            this.PosY.ValueChanged += new System.EventHandler(this.PosY_ValueChanged);
            // 
            // OriginY
            // 
            this.OriginY.DecimalPlaces = 2;
            this.OriginY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginY.Location = new System.Drawing.Point(141, 33);
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
            this.OriginY.Size = new System.Drawing.Size(64, 20);
            this.OriginY.TabIndex = 7;
            this.OriginY.ValueChanged += new System.EventHandler(this.OriginY_ValueChanged);
            // 
            // ScaleX
            // 
            this.ScaleX.DecimalPlaces = 2;
            this.ScaleX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScaleX.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleX.Location = new System.Drawing.Point(72, 63);
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
            this.ScaleX.Size = new System.Drawing.Size(63, 20);
            this.ScaleX.TabIndex = 8;
            this.ScaleX.ValueChanged += new System.EventHandler(this.ScaleX_ValueChanged);
            // 
            // ScaleY
            // 
            this.ScaleY.DecimalPlaces = 2;
            this.ScaleY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScaleY.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleY.Location = new System.Drawing.Point(141, 63);
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
            this.ScaleY.Size = new System.Drawing.Size(64, 20);
            this.ScaleY.TabIndex = 9;
            this.ScaleY.ValueChanged += new System.EventHandler(this.ScaleY_ValueChanged);
            // 
            // Rotation
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.Rotation, 2);
            this.Rotation.DecimalPlaces = 2;
            this.Rotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Rotation.Location = new System.Drawing.Point(72, 93);
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
            this.Rotation.Size = new System.Drawing.Size(133, 20);
            this.Rotation.TabIndex = 10;
            this.Rotation.ValueChanged += new System.EventHandler(this.Rotation_ValueChanged);
            // 
            // boneStatut
            // 
            this.boneStatut.AutoSize = true;
            this.boneStatut.Location = new System.Drawing.Point(3, 51);
            this.boneStatut.Name = "boneStatut";
            this.boneStatut.Size = new System.Drawing.Size(33, 13);
            this.boneStatut.TabIndex = 5;
            this.boneStatut.Text = "statut";
            // 
            // boneName
            // 
            this.boneName.Location = new System.Drawing.Point(44, 3);
            this.boneName.Name = "boneName";
            this.boneName.Size = new System.Drawing.Size(167, 20);
            this.boneName.TabIndex = 1;
            this.boneName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boneName_KeyDown);
            this.boneName.Validated += new System.EventHandler(this.boneName_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.dispId);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel1.Controls.Add(this.boneStatut);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel1.Controls.Add(this.statut);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(910, 881);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dispId
            // 
            this.dispId.AutoSize = true;
            this.dispId.Location = new System.Drawing.Point(3, 0);
            this.dispId.Name = "dispId";
            this.dispId.Size = new System.Drawing.Size(35, 13);
            this.dispId.TabIndex = 8;
            this.dispId.Text = "label6";
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label1);
            this.flowLayoutPanel6.Controls.Add(this.boneName);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(214, 32);
            this.flowLayoutPanel6.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel3);
            this.groupBox3.Location = new System.Drawing.Point(3, 434);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(214, 116);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sprite";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.spriteButton);
            this.flowLayoutPanel3.Controls.Add(this.addSprite);
            this.flowLayoutPanel3.Controls.Add(this.removeSprite);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(208, 97);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // spriteButton
            // 
            this.spriteButton.Location = new System.Drawing.Point(3, 3);
            this.spriteButton.Name = "spriteButton";
            this.spriteButton.Size = new System.Drawing.Size(181, 23);
            this.spriteButton.TabIndex = 0;
            this.spriteButton.Text = "button1";
            this.spriteButton.UseVisualStyleBackColor = true;
            this.spriteButton.Click += new System.EventHandler(this.spriteButton_Click);
            // 
            // addSprite
            // 
            this.addSprite.Location = new System.Drawing.Point(3, 32);
            this.addSprite.Name = "addSprite";
            this.addSprite.Size = new System.Drawing.Size(181, 23);
            this.addSprite.TabIndex = 1;
            this.addSprite.Text = "Ajouter le sprite";
            this.addSprite.UseVisualStyleBackColor = true;
            this.addSprite.Click += new System.EventHandler(this.addSprite_Click);
            // 
            // removeSprite
            // 
            this.removeSprite.Location = new System.Drawing.Point(3, 61);
            this.removeSprite.Name = "removeSprite";
            this.removeSprite.Size = new System.Drawing.Size(181, 23);
            this.removeSprite.TabIndex = 2;
            this.removeSprite.Text = "Supprimer le sprite";
            this.removeSprite.UseVisualStyleBackColor = true;
            this.removeSprite.Click += new System.EventHandler(this.removeSprite_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel4);
            this.groupBox4.Location = new System.Drawing.Point(3, 556);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(214, 130);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mode de fusion";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.alphaMode);
            this.flowLayoutPanel4.Controls.Add(this.multMode);
            this.flowLayoutPanel4.Controls.Add(this.subsMode);
            this.flowLayoutPanel4.Controls.Add(this.addMode);
            this.flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(208, 111);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // alphaMode
            // 
            this.alphaMode.AutoSize = true;
            this.alphaMode.Location = new System.Drawing.Point(3, 3);
            this.alphaMode.Name = "alphaMode";
            this.alphaMode.Size = new System.Drawing.Size(52, 17);
            this.alphaMode.TabIndex = 0;
            this.alphaMode.TabStop = true;
            this.alphaMode.Text = "Alpha";
            this.alphaMode.UseVisualStyleBackColor = true;
            this.alphaMode.CheckedChanged += new System.EventHandler(this.alphaMode_CheckedChanged);
            // 
            // multMode
            // 
            this.multMode.AutoSize = true;
            this.multMode.Location = new System.Drawing.Point(3, 26);
            this.multMode.Name = "multMode";
            this.multMode.Size = new System.Drawing.Size(77, 17);
            this.multMode.TabIndex = 1;
            this.multMode.TabStop = true;
            this.multMode.Text = "Multiplicatif";
            this.multMode.UseVisualStyleBackColor = true;
            this.multMode.CheckedChanged += new System.EventHandler(this.multMode_CheckedChanged);
            // 
            // subsMode
            // 
            this.subsMode.AutoSize = true;
            this.subsMode.Location = new System.Drawing.Point(3, 49);
            this.subsMode.Name = "subsMode";
            this.subsMode.Size = new System.Drawing.Size(75, 17);
            this.subsMode.TabIndex = 2;
            this.subsMode.TabStop = true;
            this.subsMode.Text = "Soustractif";
            this.subsMode.UseVisualStyleBackColor = true;
            this.subsMode.CheckedChanged += new System.EventHandler(this.subsMode_CheckedChanged);
            // 
            // addMode
            // 
            this.addMode.AutoSize = true;
            this.addMode.Location = new System.Drawing.Point(3, 72);
            this.addMode.Name = "addMode";
            this.addMode.Size = new System.Drawing.Size(54, 17);
            this.addMode.TabIndex = 3;
            this.addMode.TabStop = true;
            this.addMode.Text = "Additif";
            this.addMode.UseVisualStyleBackColor = true;
            this.addMode.CheckedChanged += new System.EventHandler(this.addMode_CheckedChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label6);
            this.flowLayoutPanel5.Controls.Add(this.affectedCateg);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 692);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(237, 33);
            this.flowLayoutPanel5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Catégorie :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // affectedCateg
            // 
            this.affectedCateg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.affectedCateg.FormattingEnabled = true;
            this.affectedCateg.Location = new System.Drawing.Point(67, 3);
            this.affectedCateg.Name = "affectedCateg";
            this.affectedCateg.Size = new System.Drawing.Size(144, 21);
            this.affectedCateg.TabIndex = 9;
            this.affectedCateg.SelectedIndexChanged += new System.EventHandler(this.affectedCateg_SelectedIndexChanged);
            // 
            // BoneProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BoneProperties";
            this.Size = new System.Drawing.Size(910, 881);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
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
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label statut;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.ListBox children;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addChild;
        private System.Windows.Forms.Button removeChild;
        private System.Windows.Forms.ComboBox addChildList;
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
        private System.Windows.Forms.Label boneStatut;
        private System.Windows.Forms.TextBox boneName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton alphaMode;
        private System.Windows.Forms.RadioButton multMode;
        private System.Windows.Forms.RadioButton subsMode;
        private System.Windows.Forms.RadioButton addMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button spriteButton;
        private System.Windows.Forms.Button addSprite;
        private System.Windows.Forms.Button removeSprite;
        private System.Windows.Forms.Label dispId;
        private System.Windows.Forms.ComboBox affectedCateg;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
    }
}
