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
    public partial class Form4 : System.Windows.Forms.Form
    {
        private Form1 f1;
        public bool[] drc = new bool[6];
        public bool[] selfc = new bool[4];
        public bool[] pyc = new bool[2];
        public bool[] betac = new bool[2];

        public Form4(Form1 _f1)
        {
            f1 = _f1;
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = dr3.Right + 20;
            groupBox1.Enabled = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (!groupBox1.Enabled) return;
            groupBox1.Enabled = false;
            drc[0] = dr0.Checked;
            drc[1] = dr1.Checked;
            drc[2] = dr2.Checked;
            drc[3] = dr3.Checked;
            drc[4] = dr4.Checked;
            drc[5] = dr5.Checked;
            selfc[0] = self0.Checked;
            selfc[1] = self1.Checked;
            selfc[2] = self2.Checked;
            selfc[3] = self3.Checked;
            pyc[0] = py0.Checked;
            pyc[1] = py1.Checked;
            betac[0] = beta0.Checked;
            betac[1] = beta1.Checked;
            toolStripProgressBar1.Value = 0;
            toolStripProgressBar1.Maximum = 100;
            Form1.THREAD_Ex = new Thread(new ThreadStart(f1.ModelTest));
            Form1.THREAD_Ex.Start();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            f1.Abort(null, null);
            f1.MODEL_TEST = false;
            groupBox1.Enabled = true;
        }

        private void PreSaveSettings(object sender, EventArgs e)
        {
            f1.PreSaveSettings(sender, e);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Abort(null, null);
            groupBox1.Enabled = true;
            f1.MODEL_TEST = false;
        }
    }
}
