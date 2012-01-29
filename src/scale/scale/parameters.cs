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
    public partial class parameters : Form
    {
        public static string wParam;
        public parameters()
        {
            InitializeComponent();
        }

        private void parameters_Load(object sender, EventArgs e)
        {
            param.Text = wParam.ToString();
        }

        private void param_TextChanged(object sender, EventArgs e)
        {
            if (this.param.Text.Length > 0)
                this.accept.Enabled = true;
            else this.accept.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            wParam = string.Empty;
            this.Close();
        }

        private void accept_Click(object sender, EventArgs e)
        {
            wParam = param.Text.ToString();
            this.Close();
        }

        public static string returnParams()
        {
            return wParam;
        }
    }
}
