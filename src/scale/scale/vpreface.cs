using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace scale
{
    public partial class vpreface : Form
    {
        public vpreface()
        {
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void vpreface_Load(object sender, EventArgs e)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(setup.viewprefs))
            {
                string tfiletext = sr.ReadToEnd();
                string[] vprefs = tfiletext.Split('\n');
                int IT = vprefs.Count();
                try
                {
                    if (vprefs[0].IndexOf("false") != -1)
                    {
                        explorerBox.Checked = false;
                    }

                    else
                    {
                        explorerBox.Checked = true;
                    }

                    if (vprefs[1].IndexOf("false") != -1)
                    {
                        statusBox.Checked = false;
                    }

                    else
                    {
                        statusBox.Checked = true;
                    }

                    if (vprefs[3].IndexOf("false") != -1)
                        lnBox.Checked = false;
                    else lnBox.Checked = true;
                }

                catch { ; }

                sr.Dispose();
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(setup.viewprefs);
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(setup.viewprefs))
                {
                    if (explorerBox.Checked == true)
                        sw.WriteLine("true");
                    else sw.WriteLine("false");

                    if (statusBox.Checked == true)
                        sw.WriteLine("true");
                    else sw.WriteLine("false");

                    if (debuggingBox.Checked == true)
                        sw.WriteLine("true");
                    else sw.WriteLine("false");

                    if (lnBox.Checked)
                        sw.WriteLine("true");
                    else sw.WriteLine("false");

                    sw.Dispose();
                }
            }

            catch
            {
                MessageBox.Show("Could not save preferences.\nDefault values have been saved instead.",
                "Scale", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            this.Close();
        }

        private void lnBox_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void explorerBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
