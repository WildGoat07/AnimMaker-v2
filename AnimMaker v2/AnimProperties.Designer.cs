namespace AnimMaker_v2
{
    partial class AnimProperties
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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.animName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.Duration = new System.Windows.Forms.NumericUpDown();
            this.bones = new System.Windows.Forms.ListBox();
            this.selectKeys = new System.Windows.Forms.Button();
            this.bonesList = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.addBone = new System.Windows.Forms.Button();
            this.removeBone = new System.Windows.Forms.Button();
            this.events = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.modEv = new System.Windows.Forms.Button();
            this.delEv = new System.Windows.Forms.Button();
            this.dispId = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dispId);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Controls.Add(this.bones);
            this.flowLayoutPanel1.Controls.Add(this.selectKeys);
            this.flowLayoutPanel1.Controls.Add(this.bonesList);
            this.flowLayoutPanel1.Controls.Add(this.tableLayoutPanel1);
            this.flowLayoutPanel1.Controls.Add(this.events);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.modEv);
            this.flowLayoutPanel1.Controls.Add(this.delEv);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1069, 814);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.animName);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(222, 26);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // animName
            // 
            this.animName.Location = new System.Drawing.Point(38, 3);
            this.animName.Name = "animName";
            this.animName.Size = new System.Drawing.Size(181, 20);
            this.animName.TabIndex = 1;
            this.animName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.animName_KeyDown);
            this.animName.Validated += new System.EventHandler(this.animName_Validated);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.AutoSize = true;
            this.flowLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel3.Controls.Add(this.label2);
            this.flowLayoutPanel3.Controls.Add(this.Duration);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 48);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(222, 26);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Durée";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Duration
            // 
            this.Duration.DecimalPlaces = 2;
            this.Duration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.Duration.Location = new System.Drawing.Point(45, 3);
            this.Duration.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(174, 20);
            this.Duration.TabIndex = 1;
            this.Duration.ValueChanged += new System.EventHandler(this.Duration_ValueChanged);
            // 
            // bones
            // 
            this.bones.FormattingEnabled = true;
            this.bones.Location = new System.Drawing.Point(3, 80);
            this.bones.Name = "bones";
            this.bones.Size = new System.Drawing.Size(222, 173);
            this.bones.TabIndex = 2;
            this.bones.SelectedIndexChanged += new System.EventHandler(this.bones_SelectedIndexChanged);
            // 
            // selectKeys
            // 
            this.selectKeys.Location = new System.Drawing.Point(3, 259);
            this.selectKeys.Name = "selectKeys";
            this.selectKeys.Size = new System.Drawing.Size(222, 23);
            this.selectKeys.TabIndex = 3;
            this.selectKeys.Text = "Selectionner les clés";
            this.selectKeys.UseVisualStyleBackColor = true;
            this.selectKeys.Click += new System.EventHandler(this.selectKeys_Click);
            // 
            // bonesList
            // 
            this.bonesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bonesList.FormattingEnabled = true;
            this.bonesList.Location = new System.Drawing.Point(3, 288);
            this.bonesList.Name = "bonesList";
            this.bonesList.Size = new System.Drawing.Size(222, 21);
            this.bonesList.TabIndex = 4;
            this.bonesList.SelectedIndexChanged += new System.EventHandler(this.bonesList_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.addBone, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.removeBone, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 315);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(222, 41);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // addBone
            // 
            this.addBone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBone.Location = new System.Drawing.Point(3, 3);
            this.addBone.Name = "addBone";
            this.addBone.Size = new System.Drawing.Size(105, 35);
            this.addBone.TabIndex = 0;
            this.addBone.Text = "Ajouter";
            this.addBone.UseVisualStyleBackColor = true;
            this.addBone.Click += new System.EventHandler(this.addBone_Click);
            // 
            // removeBone
            // 
            this.removeBone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.removeBone.Location = new System.Drawing.Point(114, 3);
            this.removeBone.Name = "removeBone";
            this.removeBone.Size = new System.Drawing.Size(105, 35);
            this.removeBone.TabIndex = 1;
            this.removeBone.Text = "Supprimer";
            this.removeBone.UseVisualStyleBackColor = true;
            this.removeBone.Click += new System.EventHandler(this.removeBone_Click);
            // 
            // events
            // 
            this.events.FormattingEnabled = true;
            this.events.Location = new System.Drawing.Point(3, 362);
            this.events.Name = "events";
            this.events.Size = new System.Drawing.Size(222, 173);
            this.events.TabIndex = 6;
            this.events.SelectedIndexChanged += new System.EventHandler(this.events_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ajouter un évènement";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // modEv
            // 
            this.modEv.Location = new System.Drawing.Point(3, 570);
            this.modEv.Name = "modEv";
            this.modEv.Size = new System.Drawing.Size(222, 23);
            this.modEv.TabIndex = 9;
            this.modEv.Text = "Modifier l\'évènement";
            this.modEv.UseVisualStyleBackColor = true;
            this.modEv.Click += new System.EventHandler(this.modEv_Click);
            // 
            // delEv
            // 
            this.delEv.Location = new System.Drawing.Point(3, 599);
            this.delEv.Name = "delEv";
            this.delEv.Size = new System.Drawing.Size(222, 23);
            this.delEv.TabIndex = 8;
            this.delEv.Text = "Supprimer un évènement";
            this.delEv.UseVisualStyleBackColor = true;
            this.delEv.Click += new System.EventHandler(this.delEv_Click);
            // 
            // dispId
            // 
            this.dispId.AutoSize = true;
            this.dispId.Location = new System.Drawing.Point(3, 0);
            this.dispId.Name = "dispId";
            this.dispId.Size = new System.Drawing.Size(35, 13);
            this.dispId.TabIndex = 10;
            this.dispId.Text = "label3";
            // 
            // AnimProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AnimProperties";
            this.Size = new System.Drawing.Size(1069, 814);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duration)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox animName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox bones;
        private System.Windows.Forms.Button selectKeys;
        private System.Windows.Forms.ComboBox bonesList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button addBone;
        private System.Windows.Forms.Button removeBone;
        private System.Windows.Forms.NumericUpDown Duration;
        private System.Windows.Forms.ListBox events;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button modEv;
        private System.Windows.Forms.Button delEv;
        private System.Windows.Forms.Label dispId;
    }
}
