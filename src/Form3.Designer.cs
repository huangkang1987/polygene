namespace PolyGene
{
    partial class Form3
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
            this.SecondColumnBox = new System.Windows.Forms.CheckBox();
            this.FirstRowBox = new System.Windows.Forms.CheckBox();
            this.PhaseBox = new System.Windows.Forms.CheckBox();
            this.PloidyBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.MissingBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.SingleRowBox = new System.Windows.Forms.CheckBox();
            this.FileBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.PloidyBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MissingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SecondColumnBox
            // 
            this.SecondColumnBox.AutoSize = true;
            this.SecondColumnBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SecondColumnBox.Location = new System.Drawing.Point(170, 36);
            this.SecondColumnBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SecondColumnBox.Name = "SecondColumnBox";
            this.SecondColumnBox.Size = new System.Drawing.Size(184, 19);
            this.SecondColumnBox.TabIndex = 0;
            this.SecondColumnBox.Text = "Second column for pop name";
            this.SecondColumnBox.UseVisualStyleBackColor = true;
            this.SecondColumnBox.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // FirstRowBox
            // 
            this.FirstRowBox.AutoSize = true;
            this.FirstRowBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FirstRowBox.Location = new System.Drawing.Point(10, 36);
            this.FirstRowBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FirstRowBox.Name = "FirstRowBox";
            this.FirstRowBox.Size = new System.Drawing.Size(153, 19);
            this.FirstRowBox.TabIndex = 1;
            this.FirstRowBox.Text = "First row for locus name";
            this.FirstRowBox.UseVisualStyleBackColor = true;
            this.FirstRowBox.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // PhaseBox
            // 
            this.PhaseBox.AutoSize = true;
            this.PhaseBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PhaseBox.Location = new System.Drawing.Point(10, 60);
            this.PhaseBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PhaseBox.Name = "PhaseBox";
            this.PhaseBox.Size = new System.Drawing.Size(123, 19);
            this.PhaseBox.TabIndex = 0;
            this.PhaseBox.Text = "Phase information";
            this.PhaseBox.UseVisualStyleBackColor = true;
            this.PhaseBox.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // PloidyBox
            // 
            this.PloidyBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.PloidyBox.Location = new System.Drawing.Point(61, 10);
            this.PloidyBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PloidyBox.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.PloidyBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PloidyBox.Name = "PloidyBox";
            this.PloidyBox.Size = new System.Drawing.Size(80, 23);
            this.PloidyBox.TabIndex = 2;
            this.PloidyBox.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.PloidyBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ploidy";
            // 
            // MissingBox
            // 
            this.MissingBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MissingBox.Location = new System.Drawing.Point(318, 10);
            this.MissingBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MissingBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.MissingBox.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.MissingBox.Name = "MissingBox";
            this.MissingBox.Size = new System.Drawing.Size(70, 23);
            this.MissingBox.TabIndex = 2;
            this.MissingBox.Value = new decimal(new int[] {
            9,
            0,
            0,
            -2147483648});
            this.MissingBox.ValueChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(223, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Missing data";
            // 
            // SingleRowBox
            // 
            this.SingleRowBox.AutoSize = true;
            this.SingleRowBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SingleRowBox.Location = new System.Drawing.Point(170, 60);
            this.SingleRowBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SingleRowBox.Name = "SingleRowBox";
            this.SingleRowBox.Size = new System.Drawing.Size(217, 19);
            this.SingleRowBox.TabIndex = 0;
            this.SingleRowBox.Text = "Data of each individual in single row";
            this.SingleRowBox.UseVisualStyleBackColor = true;
            this.SingleRowBox.CheckedChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // FileBox
            // 
            this.FileBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FileBox.Location = new System.Drawing.Point(61, 84);
            this.FileBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileBox.Name = "FileBox";
            this.FileBox.ReadOnly = true;
            this.FileBox.Size = new System.Drawing.Size(328, 23);
            this.FileBox.TabIndex = 4;
            this.FileBox.TextChanged += new System.EventHandler(this.PreSaveSettings);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button1.Location = new System.Drawing.Point(61, 110);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Browse);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.button2.Location = new System.Drawing.Point(226, 110);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Import";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Import);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(7, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "File";
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.Filter = "*.txt|*.txt|*.*|*.*";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(402, 146);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FileBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MissingBox);
            this.Controls.Add(this.PloidyBox);
            this.Controls.Add(this.FirstRowBox);
            this.Controls.Add(this.SingleRowBox);
            this.Controls.Add(this.PhaseBox);
            this.Controls.Add(this.SecondColumnBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Import from Structure";
            ((System.ComponentModel.ISupportInitialize)(this.PloidyBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MissingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox SecondColumnBox;
        public System.Windows.Forms.CheckBox FirstRowBox;
        public System.Windows.Forms.CheckBox PhaseBox;
        public System.Windows.Forms.NumericUpDown PloidyBox;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown MissingBox;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox SingleRowBox;
        public System.Windows.Forms.TextBox FileBox;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.OpenFileDialog ImportFileDialog;
    }
}