namespace setup
{
    partial class Form1
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.pathBox = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.createLink = new MetroFramework.Controls.MetroCheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.addQuickStart = new MetroFramework.Controls.MetroCheckBox();
            this.userOnly = new MetroFramework.Controls.MetroCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(678, 355);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(110, 35);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Annuler";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.Color.LawnGreen;
            this.metroButton2.Location = new System.Drawing.Point(556, 355);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(107, 35);
            this.metroButton2.TabIndex = 0;
            this.metroButton2.Text = "Installer";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(282, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(231, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Installation de AnimMaker v2";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(130, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Chemin d\'installation";
            // 
            // pathBox
            // 
            // 
            // 
            // 
            this.pathBox.CustomButton.Image = null;
            this.pathBox.CustomButton.Location = new System.Drawing.Point(442, 1);
            this.pathBox.CustomButton.Name = "";
            this.pathBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.pathBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.pathBox.CustomButton.TabIndex = 1;
            this.pathBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.pathBox.CustomButton.UseSelectable = true;
            this.pathBox.CustomButton.Visible = false;
            this.pathBox.Lines = new string[] {
        "metroTextBox1"};
            this.pathBox.Location = new System.Drawing.Point(149, 114);
            this.pathBox.MaxLength = 32767;
            this.pathBox.Name = "pathBox";
            this.pathBox.PasswordChar = '\0';
            this.pathBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.pathBox.SelectedText = "";
            this.pathBox.SelectionLength = 0;
            this.pathBox.SelectionStart = 0;
            this.pathBox.ShortcutsEnabled = true;
            this.pathBox.Size = new System.Drawing.Size(464, 23);
            this.pathBox.TabIndex = 4;
            this.pathBox.Text = "metroTextBox1";
            this.pathBox.UseSelectable = true;
            this.pathBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.pathBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(619, 114);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(70, 23);
            this.metroButton3.TabIndex = 5;
            this.metroButton3.Text = "Parcourir";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // createLink
            // 
            this.createLink.AutoSize = true;
            this.createLink.Checked = true;
            this.createLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createLink.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.createLink.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.createLink.Location = new System.Drawing.Point(13, 159);
            this.createLink.Name = "createLink";
            this.createLink.Size = new System.Drawing.Size(180, 19);
            this.createLink.TabIndex = 6;
            this.createLink.Text = "Créer un lien sur le bureau";
            this.createLink.UseSelectable = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::setup.Properties.Resources.logox64;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 77);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // addQuickStart
            // 
            this.addQuickStart.AutoSize = true;
            this.addQuickStart.Checked = true;
            this.addQuickStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addQuickStart.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.addQuickStart.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.addQuickStart.Location = new System.Drawing.Point(13, 185);
            this.addQuickStart.Name = "addQuickStart";
            this.addQuickStart.Size = new System.Drawing.Size(184, 19);
            this.addQuickStart.TabIndex = 8;
            this.addQuickStart.Text = "Ajouter au menu Démarrer";
            this.addQuickStart.UseSelectable = true;
            // 
            // userOnly
            // 
            this.userOnly.AutoSize = true;
            this.userOnly.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.userOnly.FontWeight = MetroFramework.MetroCheckBoxWeight.Light;
            this.userOnly.Location = new System.Drawing.Point(13, 210);
            this.userOnly.Name = "userOnly";
            this.userOnly.Size = new System.Drawing.Size(254, 19);
            this.userOnly.TabIndex = 9;
            this.userOnly.Text = "Installer pour cet utilisateur uniquement";
            this.userOnly.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.ControlBox = false;
            this.Controls.Add(this.userOnly);
            this.Controls.Add(this.addQuickStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.createLink);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "    ";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox pathBox;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroCheckBox createLink;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroCheckBox addQuickStart;
        private MetroFramework.Controls.MetroCheckBox userOnly;
    }
}

