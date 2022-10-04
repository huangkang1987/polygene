namespace PolyGene
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dr5 = new System.Windows.Forms.CheckBox();
            this.dr3 = new System.Windows.Forms.CheckBox();
            this.beta1 = new System.Windows.Forms.CheckBox();
            this.py1 = new System.Windows.Forms.CheckBox();
            this.dr1 = new System.Windows.Forms.CheckBox();
            this.dr4 = new System.Windows.Forms.CheckBox();
            this.dr2 = new System.Windows.Forms.CheckBox();
            this.beta0 = new System.Windows.Forms.CheckBox();
            this.py0 = new System.Windows.Forms.CheckBox();
            this.self0 = new System.Windows.Forms.CheckBox();
            this.self3 = new System.Windows.Forms.CheckBox();
            this.self2 = new System.Windows.Forms.CheckBox();
            this.self1 = new System.Windows.Forms.CheckBox();
            this.dr0 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ModelTestResBox = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.ModelText = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 56);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1978, 766);
            this.splitContainer1.SplitterDistance = 324;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dr5);
            this.groupBox1.Controls.Add(this.dr3);
            this.groupBox1.Controls.Add(this.beta1);
            this.groupBox1.Controls.Add(this.py1);
            this.groupBox1.Controls.Add(this.dr1);
            this.groupBox1.Controls.Add(this.dr4);
            this.groupBox1.Controls.Add(this.dr2);
            this.groupBox1.Controls.Add(this.beta0);
            this.groupBox1.Controls.Add(this.py0);
            this.groupBox1.Controls.Add(this.self0);
            this.groupBox1.Controls.Add(this.self3);
            this.groupBox1.Controls.Add(this.self2);
            this.groupBox1.Controls.Add(this.self1);
            this.groupBox1.Controls.Add(this.dr0);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(324, 766);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parameters";
            // 
            // dr5
            // 
            this.dr5.AutoSize = true;
            this.dr5.Checked = true;
            this.dr5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr5.Location = new System.Drawing.Point(280, 192);
            this.dr5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr5.Name = "dr5";
            this.dr5.Size = new System.Drawing.Size(119, 41);
            this.dr5.TabIndex = 1;
            this.dr5.Text = "PES rs";
            this.dr5.UseVisualStyleBackColor = true;
            this.dr5.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // dr3
            // 
            this.dr3.AutoSize = true;
            this.dr3.Checked = true;
            this.dr3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr3.Location = new System.Drawing.Point(280, 138);
            this.dr3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr3.Name = "dr3";
            this.dr3.Size = new System.Drawing.Size(188, 41);
            this.dr3.TabIndex = 1;
            this.dr3.Text = "PES rs=0.25";
            this.dr3.UseVisualStyleBackColor = true;
            this.dr3.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // beta1
            // 
            this.beta1.AutoSize = true;
            this.beta1.Checked = true;
            this.beta1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beta1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.beta1.Location = new System.Drawing.Point(280, 620);
            this.beta1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.beta1.Name = "beta1";
            this.beta1.Size = new System.Drawing.Size(154, 41);
            this.beta1.TabIndex = 1;
            this.beta1.Text = "Consider";
            this.beta1.UseVisualStyleBackColor = true;
            this.beta1.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // py1
            // 
            this.py1.AutoSize = true;
            this.py1.Checked = true;
            this.py1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.py1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.py1.Location = new System.Drawing.Point(280, 522);
            this.py1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.py1.Name = "py1";
            this.py1.Size = new System.Drawing.Size(154, 41);
            this.py1.TabIndex = 1;
            this.py1.Text = "Consider";
            this.py1.UseVisualStyleBackColor = true;
            this.py1.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // dr1
            // 
            this.dr1.AutoSize = true;
            this.dr1.Checked = true;
            this.dr1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr1.Location = new System.Drawing.Point(280, 84);
            this.dr1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr1.Name = "dr1";
            this.dr1.Size = new System.Drawing.Size(111, 41);
            this.dr1.TabIndex = 1;
            this.dr1.Text = "PRCS";
            this.dr1.UseVisualStyleBackColor = true;
            this.dr1.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // dr4
            // 
            this.dr4.AutoSize = true;
            this.dr4.Checked = true;
            this.dr4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr4.Location = new System.Drawing.Point(52, 192);
            this.dr4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr4.Name = "dr4";
            this.dr4.Size = new System.Drawing.Size(173, 41);
            this.dr4.TabIndex = 1;
            this.dr4.Text = "PES rs=0.5";
            this.dr4.UseVisualStyleBackColor = true;
            this.dr4.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // dr2
            // 
            this.dr2.AutoSize = true;
            this.dr2.Checked = true;
            this.dr2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr2.Location = new System.Drawing.Point(52, 138);
            this.dr2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr2.Name = "dr2";
            this.dr2.Size = new System.Drawing.Size(94, 41);
            this.dr2.TabIndex = 1;
            this.dr2.Text = "CES";
            this.dr2.UseVisualStyleBackColor = true;
            this.dr2.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // beta0
            // 
            this.beta0.AutoSize = true;
            this.beta0.Checked = true;
            this.beta0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beta0.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.beta0.Location = new System.Drawing.Point(52, 620);
            this.beta0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.beta0.Name = "beta0";
            this.beta0.Size = new System.Drawing.Size(141, 41);
            this.beta0.TabIndex = 1;
            this.beta0.Text = "Neglect";
            this.beta0.UseVisualStyleBackColor = true;
            this.beta0.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // py0
            // 
            this.py0.AutoSize = true;
            this.py0.Checked = true;
            this.py0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.py0.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.py0.Location = new System.Drawing.Point(52, 522);
            this.py0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.py0.Name = "py0";
            this.py0.Size = new System.Drawing.Size(141, 41);
            this.py0.TabIndex = 1;
            this.py0.Text = "Neglect";
            this.py0.UseVisualStyleBackColor = true;
            this.py0.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // self0
            // 
            this.self0.AutoSize = true;
            this.self0.Checked = true;
            this.self0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.self0.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.self0.Location = new System.Drawing.Point(52, 290);
            this.self0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.self0.Name = "self0";
            this.self0.Size = new System.Drawing.Size(141, 41);
            this.self0.TabIndex = 1;
            this.self0.Text = "Neglect";
            this.self0.UseVisualStyleBackColor = true;
            this.self0.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // self3
            // 
            this.self3.AutoSize = true;
            this.self3.Checked = true;
            this.self3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.self3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.self3.Location = new System.Drawing.Point(52, 424);
            this.self3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.self3.Name = "self3";
            this.self3.Size = new System.Drawing.Size(319, 41);
            this.self3.TabIndex = 1;
            this.self3.Text = "Hardy 2015 g2z-based";
            this.self3.UseVisualStyleBackColor = true;
            this.self3.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // self2
            // 
            this.self2.AutoSize = true;
            this.self2.Checked = true;
            this.self2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.self2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.self2.Location = new System.Drawing.Point(52, 380);
            this.self2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.self2.Name = "self2";
            this.self2.Size = new System.Drawing.Size(301, 41);
            this.self2.TabIndex = 1;
            this.self2.Text = "Hardy 2015 Fz-based";
            this.self2.UseVisualStyleBackColor = true;
            this.self2.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // self1
            // 
            this.self1.AutoSize = true;
            this.self1.Checked = true;
            this.self1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.self1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.self1.Location = new System.Drawing.Point(52, 334);
            this.self1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.self1.Name = "self1";
            this.self1.Size = new System.Drawing.Size(296, 41);
            this.self1.TabIndex = 1;
            this.self1.Text = "Maximum-likelihood";
            this.self1.UseVisualStyleBackColor = true;
            this.self1.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // dr0
            // 
            this.dr0.AutoSize = true;
            this.dr0.Checked = true;
            this.dr0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dr0.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dr0.Location = new System.Drawing.Point(52, 84);
            this.dr0.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dr0.Name = "dr0";
            this.dr0.Size = new System.Drawing.Size(202, 41);
            this.dr0.TabIndex = 1;
            this.dr0.Text = "Disomic/RCS";
            this.dr0.UseVisualStyleBackColor = true;
            this.dr0.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(21, 578);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "Negative amplification";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(21, 480);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Null allele";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(21, 249);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Self-fertilization";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(21, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inheritance models";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ModelTestResBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(1648, 766);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Results";
            // 
            // ModelTestResBox
            // 
            this.ModelTestResBox.AcceptsReturn = true;
            this.ModelTestResBox.AcceptsTab = true;
            this.ModelTestResBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModelTestResBox.HideSelection = false;
            this.ModelTestResBox.Location = new System.Drawing.Point(6, 42);
            this.ModelTestResBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ModelTestResBox.MaxLength = 32767000;
            this.ModelTestResBox.Multiline = true;
            this.ModelTestResBox.Name = "ModelTestResBox";
            this.ModelTestResBox.ReadOnly = true;
            this.ModelTestResBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ModelTestResBox.Size = new System.Drawing.Size(1636, 718);
            this.ModelTestResBox.TabIndex = 2;
            this.ModelTestResBox.WordWrap = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.toolStripSeparator1,
            this.toolStripProgressBar1,
            this.toolStripLabel3,
            this.ModelText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1978, 56);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(75, 50);
            this.toolStripLabel1.Text = "&Start";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(88, 50);
            this.toolStripLabel2.Text = "&Abort";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 56);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(524, 50);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(201, 50);
            this.toolStripLabel3.Text = "Current model: ";
            // 
            // ModelText
            // 
            this.ModelText.Name = "ModelText";
            this.ModelText.Size = new System.Drawing.Size(0, 50);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(216F, 216F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1978, 822);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form4";
            this.Text = "ModelTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form4_FormClosing);
            this.Load += new System.EventHandler(this.Form4_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.CheckBox dr5;
        public System.Windows.Forms.CheckBox dr3;
        public System.Windows.Forms.CheckBox dr1;
        public System.Windows.Forms.CheckBox dr4;
        public System.Windows.Forms.CheckBox dr2;
        public System.Windows.Forms.CheckBox self1;
        public System.Windows.Forms.CheckBox dr0;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.CheckBox beta1;
        public System.Windows.Forms.CheckBox py1;
        public System.Windows.Forms.CheckBox beta0;
        public System.Windows.Forms.CheckBox py0;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox ModelTestResBox;
        public System.Windows.Forms.CheckBox self0;
        public System.Windows.Forms.CheckBox self3;
        public System.Windows.Forms.CheckBox self2;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.ToolStripLabel toolStripLabel3;
        public System.Windows.Forms.ToolStripLabel ModelText;
        public System.Windows.Forms.ToolStripButton toolStripLabel1;
        public System.Windows.Forms.ToolStripButton toolStripLabel2;
    }
}