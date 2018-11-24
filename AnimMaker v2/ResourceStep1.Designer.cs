namespace AnimMaker_v2
{
    partial class ResourceStep1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.staticTexture = new System.Windows.Forms.RadioButton();
            this.animatedTexture = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.staticTexture, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.animatedTexture, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(730, 354);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // staticTexture
            // 
            this.staticTexture.Appearance = System.Windows.Forms.Appearance.Button;
            this.staticTexture.AutoSize = true;
            this.staticTexture.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.staticTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.staticTexture.Location = new System.Drawing.Point(3, 3);
            this.staticTexture.Name = "staticTexture";
            this.staticTexture.Size = new System.Drawing.Size(359, 348);
            this.staticTexture.TabIndex = 0;
            this.staticTexture.TabStop = true;
            this.staticTexture.Text = "Texture fixe";
            this.staticTexture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.staticTexture.UseVisualStyleBackColor = true;
            // 
            // animatedTexture
            // 
            this.animatedTexture.Appearance = System.Windows.Forms.Appearance.Button;
            this.animatedTexture.AutoSize = true;
            this.animatedTexture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animatedTexture.Location = new System.Drawing.Point(368, 3);
            this.animatedTexture.Name = "animatedTexture";
            this.animatedTexture.Size = new System.Drawing.Size(359, 348);
            this.animatedTexture.TabIndex = 1;
            this.animatedTexture.TabStop = true;
            this.animatedTexture.Text = "Texture animée";
            this.animatedTexture.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.animatedTexture.UseVisualStyleBackColor = true;
            // 
            // ResourceStep1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ResourceStep1";
            this.Size = new System.Drawing.Size(730, 354);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.RadioButton staticTexture;
        public System.Windows.Forms.RadioButton animatedTexture;
    }
}
