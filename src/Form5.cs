using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.IO;
using System.Threading;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Numerics;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace PolyGene
{
    public partial class Form5 : System.Windows.Forms.Form
    {
        private Form1 f1;
        public Form1.ExportMethod method;
        public Form1.ExportFormat format;
        public bool fillmissing;
        public int rep;
        public int nfiles;
        public int nullid;
        public int maxn;
        public string dir;

        public Form5(Form1 _f1)
        {
            f1 = _f1;
            InitializeComponent();
            MethodBox.SelectedIndex = 0;
            FormatBox.SelectedIndex = 0;
            FillMissingBox.SelectedIndex = 0;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DirBox.Text = Directory.GetCurrentDirectory() + "\\Export\\";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ExportFolderDialog.ShowDialog() && Directory.Exists(ExportFolderDialog.SelectedPath))
                DirBox.Text = ExportFolderDialog.SelectedPath;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            f1.Abort(null, null);
            groupBox1.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            dir = DirBox.Text;

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Output directory cannot be created.", "Error");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo fi in di.GetFiles("*.txt"))
                fi.Delete();

            if (di.GetFiles("*.txt").Count() > 0)
            {
                MessageBox.Show("Output directory cannot be cleared.", "Error");
                return;
            }

            groupBox1.Enabled = false;
            method = (Form1.ExportMethod)MethodBox.SelectedIndex;
            format = (Form1.ExportFormat)FormatBox.SelectedIndex;
            fillmissing = FillMissingBox.SelectedIndex == 1;
            rep = (int)RepeatBox.Value;
            nfiles = (int)NFileBox.Value;
            nullid = (int)NullBox.Value;
            maxn = (int)MaxNBox.Value;

            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = nfiles;
            Form1.THREAD_Ex = new Thread(new ThreadStart(f1.ExportDummyGenotype));
            Form1.THREAD_Ex.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dir = DirBox.Text;

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Output directory cannot be created.", "Error");
                return;
            }

            System.Diagnostics.Process.Start(DirBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dir = DirBox.Text;

            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("Output directory cannot be created.", "Error");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(dir);
            foreach (FileInfo fi in di.GetFiles("*.txt"))
                fi.Delete();
            if (di.GetFiles("*.txt").Count() > 0)
            {
                MessageBox.Show("Output directory cannot be cleared.", "Error");
                return;
            }
        }

        private void PreSaveSettings(object sender, EventArgs e)
        {
            f1.PreSaveSettings(sender, e);
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolStripButton1_Click(null, null);
        }

    }
}
