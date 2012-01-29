using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scale
{
    public partial class contents : Form
    {
        public contents()
        {
            InitializeComponent();
        }

        private void gNUGeneralPublicLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gnu.org/copyleft/gpl.html");
        }
    }
}
