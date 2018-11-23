namespace AnimMaker_v2
{
    partial class ResProperties
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
            this.panel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.resourceMode = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.smooth = new System.Windows.Forms.CheckBox();
            this.repeated = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.exportPng = new System.Windows.Forms.SaveFileDialog();
            this.panel.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Controls.Add(this.flowLayoutPanel3);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.smooth);
            this.panel.Controls.Add(this.repeated);
            this.panel.Controls.Add(this.button2);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(866, 802);
            this.panel.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.name);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(224, 30);
            this.flowLayoutPanel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(47, 3);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(174, 20);
            this.name.TabIndex = 1;
            this.name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.name_KeyDown);
            this.name.Validated += new System.EventHandler(this.name_Validated);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comportement";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.resourceMode);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 50);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // resourceMode
            // 
            this.resourceMode.AutoSize = true;
            this.resourceMode.Location = new System.Drawing.Point(3, 0);
            this.resourceMode.Name = "resourceMode";
            this.resourceMode.Size = new System.Drawing.Size(35, 13);
            this.resourceMode.TabIndex = 0;
            this.resourceMode.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Modifier le comportement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // smooth
            // 
            this.smooth.AutoSize = true;
            this.smooth.Location = new System.Drawing.Point(3, 114);
            this.smooth.Name = "smooth";
            this.smooth.Size = new System.Drawing.Size(56, 17);
            this.smooth.TabIndex = 4;
            this.smooth.Text = "Lissée";
            this.smooth.UseVisualStyleBackColor = true;
            this.smooth.CheckedChanged += new System.EventHandler(this.smooth_CheckedChanged);
            // 
            // repeated
            // 
            this.repeated.AutoSize = true;
            this.repeated.Location = new System.Drawing.Point(3, 137);
            this.repeated.Name = "repeated";
            this.repeated.Size = new System.Drawing.Size(67, 17);
            this.repeated.TabIndex = 5;
            this.repeated.Text = "Répétée";
            this.repeated.UseVisualStyleBackColor = true;
            this.repeated.CheckedChanged += new System.EventHandler(this.repeated_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 160);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Exporter en PNG";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // exportPng
            // 
            this.exportPng.AutoUpgradeEnabled = false;
            this.exportPng.Filter = "Images PNG (*.png)|*.png";
            // 
            // ResProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "ResProperties";
            this.Size = new System.Drawing.Size(866, 802);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label resourceMode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.CheckBox smooth;
        private System.Windows.Forms.CheckBox repeated;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SaveFileDialog exportPng;
    }
}
