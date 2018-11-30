namespace AnimMaker_v2
{
    partial class CategoryProperties
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
            this.categID = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.categName = new System.Windows.Forms.TextBox();
            this.categEnabled = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.categID);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.categEnabled);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(519, 600);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // categID
            // 
            this.categID.AutoSize = true;
            this.categID.Location = new System.Drawing.Point(3, 0);
            this.categID.Name = "categID";
            this.categID.Size = new System.Drawing.Size(15, 13);
            this.categID.TabIndex = 0;
            this.categID.Text = "id";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.categName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(296, 29);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nom :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // categName
            // 
            this.categName.Location = new System.Drawing.Point(44, 3);
            this.categName.Name = "categName";
            this.categName.Size = new System.Drawing.Size(189, 20);
            this.categName.TabIndex = 1;
            this.categName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.categName_KeyDown);
            this.categName.Validated += new System.EventHandler(this.categName_Validated);
            // 
            // categEnabled
            // 
            this.categEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.categEnabled.AutoSize = true;
            this.categEnabled.Location = new System.Drawing.Point(3, 51);
            this.categEnabled.Name = "categEnabled";
            this.categEnabled.Size = new System.Drawing.Size(78, 23);
            this.categEnabled.TabIndex = 1;
            this.categEnabled.Text = "display mode";
            this.categEnabled.UseVisualStyleBackColor = true;
            this.categEnabled.CheckedChanged += new System.EventHandler(this.categEnabled_CheckedChanged);
            // 
            // CategoryProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CategoryProperties";
            this.Size = new System.Drawing.Size(519, 600);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label categID;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox categName;
        private System.Windows.Forms.CheckBox categEnabled;
    }
}
