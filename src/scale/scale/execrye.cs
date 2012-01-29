using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fsystem;

namespace scale
{
    public partial class execrye : Form
    {
        public execrye()
        {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (scLine.Text.Length <= 0)
                MessageBox.Show("Provide a script line!", "Scale", MessageBoxButtons.OK, MessageBoxIcon.Warning, 0, 0);
            else
            {
                string target = "bin/rye.exe -r " + scLine.Text;
                systemfunctions.ExecCmd(target);
            }
        }
    }
}
