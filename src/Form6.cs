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
    public partial class Form6 : System.Windows.Forms.Form
    {
        private Form1 f1;
        public static string result;
        private static int runstate = 0;
        private static int cloaded = 0;
        private static int loadcomplete = 0;
        private static int cid = 0;
        private static string[] indnames;
        private static StreamReader snpfile;
        public static int outputstyle = 0;//0 for phenotype, 1 for genotype, 2 for one-digit genotype with deliminator, 4 for one-digitgenotype without deliminator
        private static int k1 = 0;
        private static int k2 = 0;
        private static List<string> filterlist;
        private static int minqual = 0;
        private static int[] indv = null;
        private static double minhe = 0;
        private static double mingtrate = 0;
        private static double minmaf = 0;
        private static int windowsize = 0;
        private static int mingq = 0;
        private static int mindp = 0;
        private static ConcurrentDictionary<uint, SNP> snps;
        private static Thread[] threads;
        private static string errormsg = "";
        private static string[] buffer;

        public Form6(Form1 _f1)
        {
            f1 = _f1;
            InitializeComponent();
            OutputStyleBox.SelectedIndex = 0;
        }

        private void PreSaveSettings(object sender, EventArgs e)
        {
            f1.PreSaveSettings(sender, e);
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
                FileBox.Text = ImportFileDialog.FileName;
        }

        public class SNP
        {
            public int lineid = 0;
            public int k = 0;
            public uint windowid = 0;
            public double he = 0;
            public byte[][] genotypes;
            public string name = "";
            public int pass = 0;//1 for pass, 0 for unpass, -1 for error

            public SNP(int _lineid, string line, bool firstline)
            {
                lineid = _lineid;
                string[] fields = line.Split(new char[] { '\t' }, StringSplitOptions.None);
                name = fields[0] + "_" + fields[1] + "_" + fields[2];

                int pos = 0;
                int.TryParse(fields[1], out pos);
                windowid = Form1.HashString(fields[0] + "_" + (pos / windowsize));

                k = 2 + fields[4].Count(o => o == ',');
                if (!firstline && (k < k1 || k > k2)) return;

                int qual = 100;
                int.TryParse(fields[5], out qual);
                if (!firstline && qual < minqual) return;

                string filter = fields[6];
                if (!firstline && filterlist.IndexOf(filter) == -1) return;

                List<string> fmt = fields[8].Split(new char[] { ':' }, StringSplitOptions.None).ToList();
                int gtid = fmt.IndexOf("GT"), gqid = fmt.IndexOf("GQ"), dpid = fmt.IndexOf("DP");

                if (gtid == -1)
                {
                    pass = -1;
                    errormsg = "GT field not found! At line " + pos + ".";
                    return;
                }
                
                int ninds = fields.Length - 9, ntyped = 0;
                genotypes = new byte[ninds][];
                double[] freq = new double[k];

                for (int i = 0; i < ninds; ++i)
                {
                    int gq = 100, dp = 1000000;
                    string[] f2 = fields[i + 9].Split(new char[] { ':' }, StringSplitOptions.None);
                    
                    if (gqid != -1 && f2.Length > gqid) int.TryParse(f2[gqid], out gq);
                    if (dpid != -1 && f2.Length > dpid) int.TryParse(f2[dpid], out dp);

                    genotypes[i] = GetGenotype(f2[gtid], freq);
                    if (gq < mingq || dp < mindp) Form1.SetVal(genotypes[i], (byte)255);

                    if (indv != null && indv[i] != genotypes[i].Length && genotypes[i].Max() != 255)
                    {
                        if (indv[i] == 0)
                            indv[i] = genotypes[i].Length;
                        else
                        {
                            errormsg = "Inconsistent individual ploidy level, in individual " + (i + 1) + " at line " + pos;
                            pass = -1;
                            return;
                        }
                    }

                    if (genotypes[i][0] != 255) ntyped++;
                }
                
                Form1.Mul(freq, freq, 1.0 / freq.Sum());
                if (!firstline && freq.Min() < minmaf) return;
                if (!firstline && ntyped / (double)ninds < mingtrate) return;
                if (!firstline && 1.0 - freq.Sum(o => o * o) < minhe) return;

                pass = 1;
            }

            public void WriteGenotype(int i, StreamWriter sw)
            {
                if (genotypes[i][0] == 255)
                {
                    sw.Write(outputstyle == 3 ? " " : "\t");
                    return;
                }

                if (outputstyle == 0)
                {
                    sw.Write("\t");
                    for (int j = 0; j < genotypes[i].Length; ++j)
                    {
                        if (j == 0)
                            sw.Write(genotypes[i][j].ToString());
                        else if (genotypes[i][j] != genotypes[i][j - 1])
                            sw.Write("," + genotypes[i][j]);
                    }
                }
                else if (outputstyle == 1)
                {
                    sw.Write("\t");
                    for (int j = 0; j < genotypes[i].Length; ++j)
                    {
                        sw.Write(genotypes[i][j].ToString());
                        if (j != genotypes[i].Length - 1)
                            sw.Write(",");
                    }
                }
                else if (outputstyle == 2)
                {
                    int c = 0;
                    foreach (int v in genotypes[i])
                        if (v == 0)
                            c++;
                    if (c < 10)
                        sw.Write("\t" + c);
                    else
                        sw.Write("\t" + ('A' + c - 10));
                }
                else if (outputstyle == 3)
                {
                    int c = 0;
                    foreach (int v in genotypes[i])
                        if (v == 0)
                            c++;
                    if (c < 10)
                        sw.Write(c);
                    else
                        sw.Write(('A' + c - 10));
                }
            }

            private byte[] GetGenotype(string gstr, double[] freq)
            {
                int v = 1;
                for (int i = 0; i < gstr.Length; ++i)
                    if (gstr[i] == '/' || gstr[i] == '|')
                        v++;

                byte[] re = new byte[v];
                int p1 = 0, p2 = 0;
                int vi = 0;
                for (int i = 0; i <= gstr.Length; ++i)
                {
                    if (i == gstr.Length || gstr[i] == '/' || gstr[i] == '|')
                    {
                        p2 = i;
                        int d = 0;
                        if (gstr[p1] == '.')
                        {
                            Form1.SetVal(re, (byte)255);
                            return re;
                        }
                        else
                        {
                            for (int j = p1; j < p2; ++j)
                                d = d * 10 + (gstr[j] - '0');
                        }
                        re[vi++] = (byte)d;
                        p1 = i + 1;
                    }
                }

                for (int i = 0; i < v; ++i)
                    for (int j = i + 1; j < v; ++j)
                        if (re[i] > re[j])
                        {
                            byte t = re[i];
                            re[i] = re[j];
                            re[j] = t;
                        }
                for (int i = 0; i < v; ++i)
                    freq[re[i]]++;
                return re;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (runstate != 0) return;
            if (!File.Exists(FileBox.Text)) return;
            outputstyle = OutputStyleBox.SelectedIndex;
            k1 = (int)NAlleleBox1.Value;
            k2 = (int)NAlleleBox2.Value;
            if (outputstyle == 2) k1 = k2 = 2;
            filterlist = FilterBox.Text.Split(new char[] { ',' }, StringSplitOptions.None).ToList();
            minqual = (int)QualBox.Value;
            minhe = (double)HeBox.Value;
            mingtrate = (double)GenotypeRateBox.Value;
            minmaf = (double)MAFBox.Value;
            windowsize = (int)WindowSizeBox.Value;
            mingq = (int)GQBox.Value;
            mindp = (int)DPBox.Value;
            snps = new ConcurrentDictionary<uint, SNP>();
            
            snpfile = new StreamReader(new FileStream(FileBox.Text, FileMode.Open, FileAccess.Read));
            while (true)
            {
                string a = snpfile.ReadLine();
                if (a.Substring(0, 6) == "#CHROM")
                {
                    var indnameslist = a.Split(new char[] { '\t' }, StringSplitOptions.None).ToList();
                    indnameslist.RemoveRange(0, 9);
                    indnames = indnameslist.ToArray();

                    string firstline = snpfile.ReadLine();

                    SNP tsnp1 = new SNP(0, firstline, true);

                    indv = tsnp1.genotypes.Select(o => o.Max() == 255 ? 0 : o.Length).ToArray();
                    toolStripProgressBar1.Value = 0;
                    toolStripProgressBar1.Maximum = (int)((snpfile.BaseStream.Length - 1) >> 10);
                    
                    SNP tsnp2 = new SNP(0, firstline, false);
                    if (tsnp2.pass == -1)
                    {
                        runstate = -1;
                        return;
                    }
                    if (tsnp2.pass == 1)
                        snps[tsnp2.windowid] = tsnp2;
                    break;
                }
            }

            runstate = 1;
            loadcomplete = 0;
            cid = 0;
            cloaded = 0;
            buffer = new string[1024];

            int nthread = Form1.N_THREAD;
            threads = new Thread[nthread + 1];

            threads[nthread] = new Thread(new ParameterizedThreadStart(LoadSNPs));
            threads[nthread].Start(0);

            for (int i = 0; i < nthread; ++i)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(ProcessSNP));
                threads[i].Start(i);
            }
            timer1.Enabled = true;
        }

        public void LoadSNPs(object obj)
        {
            while (runstate >= 1 && snpfile.Peek() != -1)
            {
                while (runstate >= 1 && snpfile.Peek() != -1 && cloaded < cid + buffer.Length)
                    buffer[cloaded++ % buffer.Length] = snpfile.ReadLine();
                Thread.Sleep(10);
            }
            loadcomplete = 1;
        }

        public void ProcessSNP(object obj)
        {
            while (runstate >= 1)
            {
                int cid2 = 0;
                string linedata = null;
                lock (this)
                {
                    while (cloaded == 0) Thread.Sleep(10);
                    while (loadcomplete == 0 && cid == cloaded) Thread.Sleep(10);
                    if (loadcomplete == 1 && cid == cloaded)
                    {
                        runstate++;
                        break;
                    }

                    cid2 = cid++;
                    while (linedata == null)
                        linedata = buffer[cid2 % buffer.Length];
                }

                SNP tsnp = new SNP(cid2, linedata, false);

                if (tsnp.pass == -1)
                {
                    runstate = -1;
                    return;
                }
                    
                if (tsnp.pass == 1)
                {
                    if (!snps.ContainsKey(tsnp.windowid))
                        snps[tsnp.windowid] = tsnp;
                    else if (tsnp.he > snps[tsnp.windowid].he)
                        snps[tsnp.windowid] = tsnp;
                }
            }
        }

        private void ProgressTimerTick(object sender, EventArgs e)
        {
            if (runstate == 1)
                toolStripProgressBar1.Value = (int)(snpfile.BaseStream.Position >> 10);

            if (runstate == 1 + Form1.N_THREAD)
            {
                toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
                runstate = 0;
                StreamWriter sw = new StreamWriter(new FileStream("input.txt", FileMode.Create, FileAccess.Write), Encoding.UTF8);
                
                SNP[] snps2 = (from o in snps.Values orderby o.lineid select o).ToArray();

                if (outputstyle < 3)
                {
                    sw.Write("Ind\tPop\tPloidy");
                    foreach (SNP s in snps2)
                        sw.Write("\t" + s.name);
                    sw.Write("\r\n");
                }
                else
                {
                    sw.Write("Ind\tPop\tPloidy\t");
                    for (int i = 0; i < snps2.Length; ++i)
                        sw.Write(snps2[i].name + ( i == snps2.Length - 1 ? "" : ","));
                    sw.Write("\r\n");
                }

                for (int i = 0; i < indnames.Length; ++i)
                {
                    sw.Write(indnames[i] + "\ta\t" + indv[i]);
                    if (outputstyle == 3) sw.Write("\t");
                    foreach (SNP s in snps2)
                        s.WriteGenotype(i, sw);
                    sw.Write("\r\n");
                }
                sw.Close();

                result = File.ReadAllText("input.txt");
                snpfile.Close();
            }
            
            if (runstate == -1)
            {
                result = "";
                File.WriteAllText("input.txt", result);
                MessageBox.Show(errormsg, "Error");
                snpfile.Close();
                runstate = 0;
            }

            if (runstate == 0)
            {
                timer1.Enabled = false;
            }
        }

        private void OutputStyleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OutputStyleBox.SelectedIndex == 0)
                NAlleleBox1.Value = NAlleleBox2.Value = 2;
            PreSaveSettings(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            runstate = 0;
            timer1.Enabled = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            OutputStyleBox_SelectedIndexChanged(null, null);
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            runstate = 0;
            timer1.Enabled = false;
        }
    }
}
