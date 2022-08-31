using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PolyGene
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        private Form1 f1;
        public static string result = "";

        public Form3(Form1 _f1)
        {
            f1 = _f1;
            InitializeComponent();
        }

        private void Browse(object sender, EventArgs e)
        {
            if (DialogResult.OK == ImportFileDialog.ShowDialog())
                FileBox.Text = ImportFileDialog.FileName;
        }

        private void Import(object sender, EventArgs e)
        {
            if (File.Exists(FileBox.Text))
            {
                string[] data = File.ReadAllLines(FileBox.Text);
                int ploidy = (int)PloidyBox.Value;
                int missing = (int)MissingBox.Value;
                int nlocus = data[1].Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries).Length - 1;
                if (SecondColumnBox.Checked) nlocus--;
                if (SingleRowBox.Checked) nlocus /= ploidy;
                int ninds = data.Length - (FirstRowBox.Checked ? 1 : 0);
                if (!SingleRowBox.Checked) ninds /= ploidy;

                StreamWriter wt = new StreamWriter(new MemoryStream());
                wt.Write("Ind\tPop\tPloidy");
                if (FirstRowBox.Checked)
                {
                    string[] locus = data[0].Split(new char[] { ' ' , '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < locus.Length; ++i)
                        wt.Write("\t" + locus[i]);
                }
                else
                {
                    for (int i = 1; i <= nlocus; ++i)
                        wt.Write("\tloc" + i);
                }

                string[][] data2 = new string[data.Length][];
                for (int i = 0; i < data.Length; ++i)
                    data2[i] = data[i].Split(new char[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (SingleRowBox.Checked)
                {
                    //single line
                    for (int i = FirstRowBox.Checked ? 1 : 0; i < data.Length; i += PhaseBox.Checked ? 2 : 1)
                    {
                        if (SecondColumnBox.Checked)
                            wt.Write("\r\n" + data2[i][0] + "\t" + data2[i][1] + "\t" + ploidy);
                        else
                            wt.Write("\r\n" + data2[i][0] + "\tpop1\t" + ploidy);

                        for (int j = SecondColumnBox.Checked ? 2 : 1; j < data2[i].Length; j += ploidy)
                        {
                            bool ismissing = false;
                            for (int k = 0; k < ploidy; ++k)
                                if (int.Parse(data2[i][j + k]) == missing)
                                    ismissing = true;

                            wt.Write("\t");

                            if (!ismissing)
                            {
                                wt.Write(data2[i][j]);
                                for (int k = 1; k < ploidy; ++k)
                                    wt.Write("," + data2[i][j + k]);
                            }
                        }
                    }
                }
                else
                {
                    //multiple line
                    for (int i = FirstRowBox.Checked ? 1 : 0; i < data.Length; i += ploidy + (PhaseBox.Checked ? 1 : 0))
                    {
                        if (SecondColumnBox.Checked)
                            wt.Write("\r\n" + data2[i][0] + "\t" + data2[i][1] + "\t" + ploidy);
                        else
                            wt.Write("\r\n" + data2[i][0] + "\tpop1\t" + ploidy);

                        for (int j = SecondColumnBox.Checked ? 2 : 1; j < data2[i].Length; j ++)
                        {
                            bool ismissing = false;
                            for (int k = 0; k < ploidy; ++k)
                                if (int.Parse(data2[i + k][j]) == missing)
                                    ismissing = true;

                            wt.Write("\t");

                            if (!ismissing)
                            {
                                wt.Write(data2[i][j]);
                                for (int k = 1; k < ploidy; ++k)
                                    wt.Write("," + data2[i + k][j]);
                            }
                        }
                    }
                }

                wt.Flush();
                StreamReader rt = new StreamReader(wt.BaseStream);
                rt.BaseStream.Position = 0;
                result = rt.ReadToEnd();
                this.Close();
            }
        }

        private void PreSaveSettings(object sender, EventArgs e)
        {
            f1.PreSaveSettings(sender, e);
        }
    }
}
