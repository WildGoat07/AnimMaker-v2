namespace AnimMaker_v2
{
    partial class FunctionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.preview = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.linear = new System.Windows.Forms.RadioButton();
            this.pow = new System.Windows.Forms.RadioButton();
            this.root = new System.Windows.Forms.RadioButton();
            this.gauss = new System.Windows.Forms.RadioButton();
            this.binary = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.coeff = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.preview, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 596);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // preview
            // 
            this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preview.Location = new System.Drawing.Point(3, 241);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(694, 352);
            this.preview.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(694, 232);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 146);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type de fonction";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.linear);
            this.flowLayoutPanel2.Controls.Add(this.pow);
            this.flowLayoutPanel2.Controls.Add(this.root);
            this.flowLayoutPanel2.Controls.Add(this.gauss);
            this.flowLayoutPanel2.Controls.Add(this.binary);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(228, 127);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // linear
            // 
            this.linear.AutoSize = true;
            this.linear.Image = global::AnimMaker_v2.Properties.Resources.linear;
            this.linear.Location = new System.Drawing.Point(3, 3);
            this.linear.MinimumSize = new System.Drawing.Size(60, 30);
            this.linear.Name = "linear";
            this.linear.Size = new System.Drawing.Size(60, 30);
            this.linear.TabIndex = 0;
            this.linear.UseVisualStyleBackColor = true;
            this.linear.CheckedChanged += new System.EventHandler(this.linear_CheckedChanged);
            // 
            // pow
            // 
            this.pow.AutoSize = true;
            this.pow.Image = global::AnimMaker_v2.Properties.Resources.pow;
            this.pow.Location = new System.Drawing.Point(3, 39);
            this.pow.MinimumSize = new System.Drawing.Size(60, 30);
            this.pow.Name = "pow";
            this.pow.Size = new System.Drawing.Size(60, 30);
            this.pow.TabIndex = 1;
            this.pow.UseVisualStyleBackColor = true;
            this.pow.CheckedChanged += new System.EventHandler(this.pow_CheckedChanged);
            // 
            // root
            // 
            this.root.AutoSize = true;
            this.root.Image = global::AnimMaker_v2.Properties.Resources.root;
            this.root.Location = new System.Drawing.Point(3, 75);
            this.root.MinimumSize = new System.Drawing.Size(60, 30);
            this.root.Name = "root";
            this.root.Size = new System.Drawing.Size(60, 30);
            this.root.TabIndex = 2;
            this.root.UseVisualStyleBackColor = true;
            this.root.CheckedChanged += new System.EventHandler(this.root_CheckedChanged);
            // 
            // gauss
            // 
            this.gauss.AutoSize = true;
            this.gauss.Image = global::AnimMaker_v2.Properties.Resources.gauss;
            this.gauss.Location = new System.Drawing.Point(69, 3);
            this.gauss.MinimumSize = new System.Drawing.Size(60, 30);
            this.gauss.Name = "gauss";
            this.gauss.Size = new System.Drawing.Size(60, 30);
            this.gauss.TabIndex = 3;
            this.gauss.UseVisualStyleBackColor = true;
            this.gauss.CheckedChanged += new System.EventHandler(this.gauss_CheckedChanged);
            // 
            // binary
            // 
            this.binary.AutoSize = true;
            this.binary.Image = global::AnimMaker_v2.Properties.Resources.bin;
            this.binary.Location = new System.Drawing.Point(69, 39);
            this.binary.MinimumSize = new System.Drawing.Size(60, 30);
            this.binary.Name = "binary";
            this.binary.Size = new System.Drawing.Size(60, 30);
            this.binary.TabIndex = 4;
            this.binary.UseVisualStyleBackColor = true;
            this.binary.CheckedChanged += new System.EventHandler(this.binary_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label1);
            this.flowLayoutPanel3.Controls.Add(this.coeff);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 155);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(234, 30);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "coefficient";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // coeff
            // 
            this.coeff.DecimalPlaces = 2;
            this.coeff.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.coeff.Location = new System.Drawing.Point(65, 3);
            this.coeff.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.coeff.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.coeff.Name = "coeff";
            this.coeff.Size = new System.Drawing.Size(120, 20);
            this.coeff.TabIndex = 1;
            this.coeff.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.coeff.ValueChanged += new System.EventHandler(this.coeff_ValueChanged);
            // 
            // FunctionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 596);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FunctionDialog";
            this.Text = "Type de fonction d\'interpolation";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coeff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel preview;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.RadioButton linear;
        private System.Windows.Forms.RadioButton pow;
        private System.Windows.Forms.RadioButton root;
        private System.Windows.Forms.RadioButton gauss;
        private System.Windows.Forms.RadioButton binary;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown coeff;
    }
}