using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fsystem;
using System.IO;

namespace scale
{
    public partial class batchexec : Form
    {
        public string fname;
        public batchexec()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Batch Files (.bat)|*.bat";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                batchPath.Text = openFile.FileName.ToString();
                execFileBtn.Enabled = true;
                fname = openFile.FileName;
            }

            using (System.IO.StreamReader sr = new System.IO.StreamReader(openFile.FileName))
            {
                scriptBox.Text = sr.ReadToEnd();
                sr.Dispose();
            }

            button2.Enabled = true;
        }

        private void execFileBtn_Click(object sender, EventArgs e)
        {
            systemfunctions.ExecCmd("start " + batchPath.Text.ToString());
        }

        private void scriptBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void execScript_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("main.bat"))
            {
                try
                {
                    sw.Write(scriptBox.Text);
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = "main.txt";
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.UseShellExecute = false;                   
                    proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    proc.StartInfo.CreateNoWindow = false;

                    while (proc.Start())
                        ;                    
                    File.Delete("main.bat");
                }

                catch
                {
                    MessageBox.Show("An error was caught!", "Scale Reporter", MessageBoxButtons.OK, MessageBoxIcon.Error
                        , MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }
                sw.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fname))
            {
                sw.Write(scriptBox.Text);
                sw.Dispose();
            }
        }
    }
}
