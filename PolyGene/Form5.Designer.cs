namespace PolyGene
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.NFileBox = new System.Windows.Forms.NumericUpDown();
            this.label40 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NullBox = new System.Windows.Forms.NumericUpDown();
            this.FormatBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DirBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MethodBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RepeatBox = new System.Windows.Forms.NumericUpDown();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.SaveStructureButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.FillMissingBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxNBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ExportFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.NFileBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatBox)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NFileBox
            // 
            this.NFileBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NFileBox.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NFileBox.Location = new System.Drawing.Point(336, 72);
            this.NFileBox.Maximum = new decimal(new int[] {
            65536000,
            0,
            0,
            0});
            this.NFileBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NFileBox.Name = "NFileBox";
            this.NFileBox.Size = new System.Drawing.Size(107, 23);
            this.NFileBox.TabIndex = 519;
            this.NFileBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NFileBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label40.Location = new System.Drawing.Point(7, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(50, 15);
            this.label40.TabIndex = 518;
            this.label40.Text = "# repeat";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(243, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 518;
            this.label1.Text = "# files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(7, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 518;
            this.label2.Text = "Null allele id";
            // 
            // NullBox
            // 
            this.NullBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NullBox.Location = new System.Drawing.Point(81, 97);
            this.NullBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.NullBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NullBox.Name = "NullBox";
            this.NullBox.Size = new System.Drawing.Size(107, 23);
            this.NullBox.TabIndex = 519;
            this.NullBox.Value = new decimal(new int[] {
            777,
            0,
            0,
            0});
            this.NullBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // FormatBox
            // 
            this.FormatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FormatBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormatBox.FormattingEnabled = true;
            this.FormatBox.Items.AddRange(new object[] {
            "PolyGene",
            "Genepop",
            "Structure",
            "PolyRelatedness",
            "Spagedi",
            "Genodive",
            "Migrate",
            "BayesAss"});
            this.FormatBox.Location = new System.Drawing.Point(81, 44);
            this.FormatBox.Name = "FormatBox";
            this.FormatBox.Size = new System.Drawing.Size(108, 23);
            this.FormatBox.TabIndex = 517;
            this.FormatBox.SelectedIndexChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(7, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 518;
            this.label3.Text = "Format";
            // 
            // DirBox
            // 
            this.DirBox.AcceptsReturn = true;
            this.DirBox.AcceptsTab = true;
            this.DirBox.HideSelection = false;
            this.DirBox.Location = new System.Drawing.Point(80, 124);
            this.DirBox.Multiline = true;
            this.DirBox.Name = "DirBox";
            this.DirBox.ReadOnly = true;
            this.DirBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DirBox.Size = new System.Drawing.Size(364, 103);
            this.DirBox.TabIndex = 520;
            this.DirBox.TextChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(9, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 518;
            this.label4.Text = "Directory";
            // 
            // MethodBox
            // 
            this.MethodBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MethodBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MethodBox.FormattingEnabled = true;
            this.MethodBox.Items.AddRange(new object[] {
            "n dummy diploid genotype (truncate)",
            "nv/2 dummy diploid genotype  (split)",
            "n polyploid genotype by posterior prob. (rand)"});
            this.MethodBox.Location = new System.Drawing.Point(81, 17);
            this.MethodBox.Name = "MethodBox";
            this.MethodBox.Size = new System.Drawing.Size(363, 23);
            this.MethodBox.TabIndex = 517;
            this.MethodBox.SelectedIndexChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(7, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 518;
            this.label5.Text = "Method";
            // 
            // RepeatBox
            // 
            this.RepeatBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RepeatBox.Location = new System.Drawing.Point(81, 71);
            this.RepeatBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RepeatBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RepeatBox.Name = "RepeatBox";
            this.RepeatBox.Size = new System.Drawing.Size(107, 23);
            this.RepeatBox.TabIndex = 519;
            this.RepeatBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RepeatBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.SaveStructureButton,
            this.toolStripSeparator1,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 521;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton2.Text = "&Export";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // SaveStructureButton
            // 
            this.SaveStructureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveStructureButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaveStructureButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveStructureButton.Image")));
            this.SaveStructureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveStructureButton.Name = "SaveStructureButton";
            this.SaveStructureButton.Size = new System.Drawing.Size(41, 22);
            this.SaveStructureButton.Text = "&Abort";
            this.SaveStructureButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(320, 22);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 25);
            this.button1.TabIndex = 522;
            this.button1.Text = "&Change";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.MethodBox);
            this.groupBox1.Controls.Add(this.label40);
            this.groupBox1.Controls.Add(this.DirBox);
            this.groupBox1.Controls.Add(this.FillMissingBox);
            this.groupBox1.Controls.Add(this.FormatBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.MaxNBox);
            this.groupBox1.Controls.Add(this.NullBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.RepeatBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NFileBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 238);
            this.groupBox1.TabIndex = 523;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(9, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 25);
            this.button3.TabIndex = 522;
            this.button3.Text = "&Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 25);
            this.button2.TabIndex = 522;
            this.button2.Text = "&Open";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FillMissingBox
            // 
            this.FillMissingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FillMissingBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FillMissingBox.FormattingEnabled = true;
            this.FillMissingBox.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.FillMissingBox.Location = new System.Drawing.Point(336, 44);
            this.FillMissingBox.Name = "FillMissingBox";
            this.FillMissingBox.Size = new System.Drawing.Size(108, 23);
            this.FillMissingBox.TabIndex = 517;
            this.FillMissingBox.SelectedIndexChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(243, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 518;
            this.label6.Text = "Fill missing data";
            // 
            // MaxNBox
            // 
            this.MaxNBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MaxNBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.MaxNBox.Location = new System.Drawing.Point(336, 97);
            this.MaxNBox.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.MaxNBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxNBox.Name = "MaxNBox";
            this.MaxNBox.Size = new System.Drawing.Size(107, 23);
            this.MaxNBox.TabIndex = 519;
            this.MaxNBox.Value = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.MaxNBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(243, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 518;
            this.label7.Text = "max(n) in pop";
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(455, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.Text = "Export genotypes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form5_FormClosing);
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NFileBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NullBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatBox)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxNBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.NumericUpDown NFileBox;
        public System.Windows.Forms.Label label40;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown NullBox;
        public System.Windows.Forms.ComboBox FormatBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox DirBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox MethodBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown RepeatBox;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.ToolStripButton SaveStructureButton;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ComboBox FillMissingBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.NumericUpDown MaxNBox;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.FolderBrowserDialog ExportFolderDialog;
    }
}