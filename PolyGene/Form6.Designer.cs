namespace PolyGene
{
    partial class Form6
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form6));
            this.MAFBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.WindowSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.HeBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.OutputStyleBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GenotypeRateBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.QualBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FilterBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.NAlleleBox1 = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.NAlleleBox2 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveStructureButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.GQBox = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.DPBox = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MAFBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenotypeRateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAlleleBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAlleleBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GQBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MAFBox
            // 
            this.MAFBox.DecimalPlaces = 4;
            this.MAFBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MAFBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MAFBox.Location = new System.Drawing.Point(437, 134);
            this.MAFBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MAFBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.MAFBox.Name = "MAFBox";
            this.MAFBox.Size = new System.Drawing.Size(91, 23);
            this.MAFBox.TabIndex = 1;
            this.MAFBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.MAFBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(313, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Minor allele freq >";
            // 
            // WindowSizeBox
            // 
            this.WindowSizeBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.WindowSizeBox.Location = new System.Drawing.Point(167, 187);
            this.WindowSizeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.WindowSizeBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.WindowSizeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WindowSizeBox.Name = "WindowSizeBox";
            this.WindowSizeBox.Size = new System.Drawing.Size(91, 23);
            this.WindowSizeBox.TabIndex = 1;
            this.WindowSizeBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WindowSizeBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(9, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Window size (bp)";
            // 
            // HeBox
            // 
            this.HeBox.DecimalPlaces = 4;
            this.HeBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HeBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.HeBox.Location = new System.Drawing.Point(437, 108);
            this.HeBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HeBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            262144});
            this.HeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.HeBox.Name = "HeBox";
            this.HeBox.Size = new System.Drawing.Size(91, 23);
            this.HeBox.TabIndex = 1;
            this.HeBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.HeBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(390, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "He >";
            // 
            // OutputStyleBox
            // 
            this.OutputStyleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputStyleBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.OutputStyleBox.FormattingEnabled = true;
            this.OutputStyleBox.Items.AddRange(new object[] {
            "Phenotype",
            "Genotype",
            "One-digit genotype with deliminator",
            "One-digit genotype without deliminator"});
            this.OutputStyleBox.Location = new System.Drawing.Point(133, 29);
            this.OutputStyleBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OutputStyleBox.Name = "OutputStyleBox";
            this.OutputStyleBox.Size = new System.Drawing.Size(379, 23);
            this.OutputStyleBox.TabIndex = 3;
            this.OutputStyleBox.SelectedIndexChanged += new System.EventHandler(this.OutputStyleBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Output style";
            // 
            // GenotypeRateBox
            // 
            this.GenotypeRateBox.DecimalPlaces = 4;
            this.GenotypeRateBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GenotypeRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.GenotypeRateBox.Location = new System.Drawing.Point(167, 134);
            this.GenotypeRateBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GenotypeRateBox.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GenotypeRateBox.Name = "GenotypeRateBox";
            this.GenotypeRateBox.Size = new System.Drawing.Size(91, 23);
            this.GenotypeRateBox.TabIndex = 1;
            this.GenotypeRateBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.Location = new System.Drawing.Point(9, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Genotyping rate >";
            // 
            // QualBox
            // 
            this.QualBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.QualBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.QualBox.Location = new System.Drawing.Point(167, 108);
            this.QualBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.QualBox.Name = "QualBox";
            this.QualBox.Size = new System.Drawing.Size(91, 23);
            this.QualBox.TabIndex = 1;
            this.QualBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(9, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Quality (QUAL) >";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.Location = new System.Drawing.Point(9, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "FILTER =";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.Location = new System.Drawing.Point(365, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 15);
            this.label8.TabIndex = 2;
            this.label8.Text = "(Separated with comma)";
            // 
            // FilterBox
            // 
            this.FilterBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FilterBox.Location = new System.Drawing.Point(133, 82);
            this.FilterBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FilterBox.Name = "FilterBox";
            this.FilterBox.Size = new System.Drawing.Size(207, 23);
            this.FilterBox.TabIndex = 4;
            this.FilterBox.Text = "PASS,.";
            this.FilterBox.TextChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label11.Location = new System.Drawing.Point(269, 188);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(297, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "(Use loci with highest He in non-overlapping windows)";
            // 
            // NAlleleBox1
            // 
            this.NAlleleBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NAlleleBox1.Location = new System.Drawing.Point(133, 55);
            this.NAlleleBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NAlleleBox1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NAlleleBox1.Name = "NAlleleBox1";
            this.NAlleleBox1.Size = new System.Drawing.Size(77, 23);
            this.NAlleleBox1.TabIndex = 1;
            this.NAlleleBox1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NAlleleBox1.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label12.Location = new System.Drawing.Point(9, 57);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 15);
            this.label12.TabIndex = 2;
            this.label12.Text = "#Alleles";
            // 
            // NAlleleBox2
            // 
            this.NAlleleBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NAlleleBox2.Location = new System.Drawing.Point(261, 55);
            this.NAlleleBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.NAlleleBox2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NAlleleBox2.Name = "NAlleleBox2";
            this.NAlleleBox2.Size = new System.Drawing.Size(77, 23);
            this.NAlleleBox2.TabIndex = 1;
            this.NAlleleBox2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NAlleleBox2.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label13.Location = new System.Drawing.Point(227, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "to";
            // 
            // FileBox
            // 
            this.FileBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileBox.Location = new System.Drawing.Point(167, 213);
            this.FileBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileBox.Name = "FileBox";
            this.FileBox.ReadOnly = true;
            this.FileBox.Size = new System.Drawing.Size(363, 23);
            this.FileBox.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.Location = new System.Drawing.Point(9, 215);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "File";
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.Filter = "VCF files|*.vcf";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveStructureButton,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripProgressBar1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(601, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveStructureButton
            // 
            this.SaveStructureButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveStructureButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveStructureButton.Image")));
            this.SaveStructureButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveStructureButton.Name = "SaveStructureButton";
            this.SaveStructureButton.Size = new System.Drawing.Size(55, 22);
            this.SaveStructureButton.Text = "&Browse";
            this.SaveStructureButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 22);
            this.toolStripButton2.Text = "&Import";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton3.Text = "&Abort";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(225, 22);
            // 
            // GQBox
            // 
            this.GQBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GQBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.GQBox.Location = new System.Drawing.Point(167, 161);
            this.GQBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GQBox.Name = "GQBox";
            this.GQBox.Size = new System.Drawing.Size(91, 23);
            this.GQBox.TabIndex = 1;
            this.GQBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label10.Location = new System.Drawing.Point(283, 161);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "Genotype Depth (DP) >";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label15.Location = new System.Drawing.Point(9, 162);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Genotype Quality (GQ) >";
            // 
            // DPBox
            // 
            this.DPBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DPBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.DPBox.Location = new System.Drawing.Point(437, 161);
            this.DPBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DPBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.DPBox.Name = "DPBox";
            this.DPBox.Size = new System.Drawing.Size(91, 23);
            this.DPBox.TabIndex = 1;
            this.DPBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.ProgressTimerTick);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 245);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.FilterBox);
            this.Controls.Add(this.OutputStyleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WindowSizeBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NAlleleBox2);
            this.Controls.Add(this.NAlleleBox1);
            this.Controls.Add(this.GQBox);
            this.Controls.Add(this.DPBox);
            this.Controls.Add(this.QualBox);
            this.Controls.Add(this.GenotypeRateBox);
            this.Controls.Add(this.HeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MAFBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form6";
            this.Text = "Import from VCF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form6_FormClosing);
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MAFBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WindowSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GenotypeRateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QualBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAlleleBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NAlleleBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GQBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown MAFBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown WindowSizeBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown HeBox;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox OutputStyleBox;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown GenotypeRateBox;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown QualBox;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox FilterBox;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.NumericUpDown NAlleleBox1;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.NumericUpDown NAlleleBox2;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox FileBox;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.OpenFileDialog ImportFileDialog;
        public System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton SaveStructureButton;
        public System.Windows.Forms.ToolStripButton toolStripButton2;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        public System.Windows.Forms.NumericUpDown GQBox;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.NumericUpDown DPBox;
        public System.Windows.Forms.ToolStripButton toolStripButton3;
        public System.Windows.Forms.Timer timer1;
    }
}