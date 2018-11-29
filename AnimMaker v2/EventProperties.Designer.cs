namespace AnimMaker_v2
{
    partial class EventProperties
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
            this.dispId = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.evName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.posX = new System.Windows.Forms.NumericUpDown();
            this.posY = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.sizeX = new System.Windows.Forms.NumericUpDown();
            this.sizeY = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.seconds = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).BeginInit();
            this.flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeY)).BeginInit();
            this.flowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dispId);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel6);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(512, 612);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // dispId
            // 
            this.dispId.AutoSize = true;
            this.dispId.Location = new System.Drawing.Point(3, 0);
            this.dispId.Name = "dispId";
            this.dispId.Size = new System.Drawing.Size(35, 13);
            this.dispId.TabIndex = 0;
            this.dispId.Text = "label1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.evName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(271, 27);
            this.flowLayoutPanel2.TabIndex = 1;
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
            // evName
            // 
            this.evName.Location = new System.Drawing.Point(44, 3);
            this.evName.Name = "evName";
            this.evName.Size = new System.Drawing.Size(190, 20);
            this.evName.TabIndex = 1;
            this.evName.Validated += new System.EventHandler(this.evName_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel3);
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 118);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zone";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel4);
            this.flowLayoutPanel3.Controls.Add(this.flowLayoutPanel5);
            this.flowLayoutPanel3.Controls.Add(this.button1);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(228, 99);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.label2);
            this.flowLayoutPanel4.Controls.Add(this.posX);
            this.flowLayoutPanel4.Controls.Add(this.posY);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(228, 23);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Position";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // posX
            // 
            this.posX.DecimalPlaces = 2;
            this.posX.Location = new System.Drawing.Point(53, 3);
            this.posX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.posX.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.posX.Name = "posX";
            this.posX.Size = new System.Drawing.Size(83, 20);
            this.posX.TabIndex = 1;
            this.posX.ValueChanged += new System.EventHandler(this.posX_ValueChanged);
            // 
            // posY
            // 
            this.posY.DecimalPlaces = 2;
            this.posY.Location = new System.Drawing.Point(142, 3);
            this.posY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.posY.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.posY.Name = "posY";
            this.posY.Size = new System.Drawing.Size(80, 20);
            this.posY.TabIndex = 2;
            this.posY.ValueChanged += new System.EventHandler(this.posY_ValueChanged);
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.label3);
            this.flowLayoutPanel5.Controls.Add(this.sizeX);
            this.flowLayoutPanel5.Controls.Add(this.sizeY);
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 32);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(228, 26);
            this.flowLayoutPanel5.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "Taille";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sizeX
            // 
            this.sizeX.DecimalPlaces = 2;
            this.sizeX.Location = new System.Drawing.Point(41, 3);
            this.sizeX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.sizeX.Name = "sizeX";
            this.sizeX.Size = new System.Drawing.Size(83, 20);
            this.sizeX.TabIndex = 1;
            this.sizeX.ValueChanged += new System.EventHandler(this.sizeX_ValueChanged);
            // 
            // sizeY
            // 
            this.sizeY.DecimalPlaces = 2;
            this.sizeY.Location = new System.Drawing.Point(130, 3);
            this.sizeY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.sizeY.Name = "sizeY";
            this.sizeY.Size = new System.Drawing.Size(80, 20);
            this.sizeY.TabIndex = 2;
            this.sizeY.ValueChanged += new System.EventHandler(this.sizeY_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Définir la zone";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Controls.Add(this.label4);
            this.flowLayoutPanel6.Controls.Add(this.seconds);
            this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 173);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(234, 30);
            this.flowLayoutPanel6.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "Position temporelle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // seconds
            // 
            this.seconds.DecimalPlaces = 2;
            this.seconds.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.seconds.Location = new System.Drawing.Point(104, 3);
            this.seconds.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.seconds.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.seconds.Name = "seconds";
            this.seconds.Size = new System.Drawing.Size(88, 20);
            this.seconds.TabIndex = 1;
            this.seconds.ValueChanged += new System.EventHandler(this.seconds_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(216, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Synchroniser sur le temps actuel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EventProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EventProperties";
            this.Size = new System.Drawing.Size(512, 612);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posY)).EndInit();
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeY)).EndInit();
            this.flowLayoutPanel6.ResumeLayout(false);
            this.flowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label dispId;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox evName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown posX;
        private System.Windows.Forms.NumericUpDown posY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown sizeX;
        private System.Windows.Forms.NumericUpDown sizeY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown seconds;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
