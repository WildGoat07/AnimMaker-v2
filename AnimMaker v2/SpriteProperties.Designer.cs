namespace AnimMaker_v2
{
    partial class SpriteProperties
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SizeX = new System.Windows.Forms.NumericUpDown();
            this.SizeY = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selectedRes = new System.Windows.Forms.ComboBox();
            this.TexPosX = new System.Windows.Forms.NumericUpDown();
            this.TexSizeX = new System.Windows.Forms.NumericUpDown();
            this.TexSizeY = new System.Windows.Forms.NumericUpDown();
            this.TexPosY = new System.Windows.Forms.NumericUpDown();
            this.adapt = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeY)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexPosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexPosY)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.adapt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(599, 446);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SizeX, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SizeY, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(211, 28);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Taille";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SizeX
            // 
            this.SizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeX.Location = new System.Drawing.Point(73, 3);
            this.SizeX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SizeX.Name = "SizeX";
            this.SizeX.Size = new System.Drawing.Size(64, 20);
            this.SizeX.TabIndex = 1;
            this.SizeX.ValueChanged += new System.EventHandler(this.SizeX_ValueChanged);
            // 
            // SizeY
            // 
            this.SizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SizeY.Location = new System.Drawing.Point(143, 3);
            this.SizeY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SizeY.Name = "SizeY";
            this.SizeY.Size = new System.Drawing.Size(65, 20);
            this.SizeY.TabIndex = 2;
            this.SizeY.ValueChanged += new System.EventHandler(this.SizeY_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(3, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 114);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Texture";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.selectedRes, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.TexPosX, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.TexSizeX, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.TexSizeY, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.TexPosY, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(208, 95);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "Position";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 31);
            this.label7.TabIndex = 1;
            this.label7.Text = "Taille";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectedRes
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.selectedRes, 3);
            this.selectedRes.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectedRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedRes.FormattingEnabled = true;
            this.selectedRes.Location = new System.Drawing.Point(3, 65);
            this.selectedRes.Name = "selectedRes";
            this.selectedRes.Size = new System.Drawing.Size(202, 21);
            this.selectedRes.TabIndex = 11;
            this.selectedRes.SelectedIndexChanged += new System.EventHandler(this.selectedRes_SelectedIndexChanged);
            // 
            // TexPosX
            // 
            this.TexPosX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TexPosX.Location = new System.Drawing.Point(72, 3);
            this.TexPosX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TexPosX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TexPosX.Name = "TexPosX";
            this.TexPosX.Size = new System.Drawing.Size(63, 20);
            this.TexPosX.TabIndex = 7;
            this.TexPosX.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // TexSizeX
            // 
            this.TexSizeX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TexSizeX.Location = new System.Drawing.Point(72, 34);
            this.TexSizeX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TexSizeX.Name = "TexSizeX";
            this.TexSizeX.Size = new System.Drawing.Size(63, 20);
            this.TexSizeX.TabIndex = 8;
            this.TexSizeX.ValueChanged += new System.EventHandler(this.TexSizeX_ValueChanged);
            // 
            // TexSizeY
            // 
            this.TexSizeY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TexSizeY.Location = new System.Drawing.Point(141, 34);
            this.TexSizeY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TexSizeY.Name = "TexSizeY";
            this.TexSizeY.Size = new System.Drawing.Size(64, 20);
            this.TexSizeY.TabIndex = 9;
            this.TexSizeY.ValueChanged += new System.EventHandler(this.TexSizeY_ValueChanged);
            // 
            // TexPosY
            // 
            this.TexPosY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TexPosY.Location = new System.Drawing.Point(141, 3);
            this.TexPosY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TexPosY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.TexPosY.Name = "TexPosY";
            this.TexPosY.Size = new System.Drawing.Size(64, 20);
            this.TexPosY.TabIndex = 10;
            this.TexPosY.ValueChanged += new System.EventHandler(this.TexPosY_ValueChanged);
            // 
            // adapt
            // 
            this.adapt.Location = new System.Drawing.Point(3, 157);
            this.adapt.Name = "adapt";
            this.adapt.Size = new System.Drawing.Size(214, 23);
            this.adapt.TabIndex = 12;
            this.adapt.Text = "Adapter à la texture";
            this.adapt.UseVisualStyleBackColor = true;
            this.adapt.Click += new System.EventHandler(this.adapt_Click);
            // 
            // SpriteProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "SpriteProperties";
            this.Size = new System.Drawing.Size(599, 446);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeY)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexPosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TexPosY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown SizeX;
        private System.Windows.Forms.NumericUpDown SizeY;
        private System.Windows.Forms.NumericUpDown TexPosX;
        private System.Windows.Forms.NumericUpDown TexSizeX;
        private System.Windows.Forms.NumericUpDown TexSizeY;
        private System.Windows.Forms.NumericUpDown TexPosY;
        private System.Windows.Forms.ComboBox selectedRes;
        private System.Windows.Forms.Button adapt;
    }
}
