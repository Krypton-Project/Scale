namespace scale
{
    partial class parameters
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
            this.param = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // param
            // 
            this.param.Location = new System.Drawing.Point(12, 12);
            this.param.Name = "param";
            this.param.Size = new System.Drawing.Size(294, 22);
            this.param.TabIndex = 0;
            this.param.TextChanged += new System.EventHandler(this.param_TextChanged);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.Control;
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancel.Location = new System.Drawing.Point(218, 46);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(88, 24);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "&Cancel";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // accept
            // 
            this.accept.BackColor = System.Drawing.SystemColors.Control;
            this.accept.Enabled = false;
            this.accept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.accept.Location = new System.Drawing.Point(124, 46);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(88, 24);
            this.accept.TabIndex = 2;
            this.accept.Text = "&OK";
            this.accept.UseVisualStyleBackColor = false;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // parameters
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(318, 75);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.param);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "parameters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scale -- Parameters";
            this.Load += new System.EventHandler(this.parameters_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox param;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button accept;
    }
}