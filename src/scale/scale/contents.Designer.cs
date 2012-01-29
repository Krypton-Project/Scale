namespace scale
{
    partial class contents
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contents));
            this.thisContents = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gNUGeneralPublicLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // thisContents
            // 
            this.thisContents.BackColor = System.Drawing.SystemColors.Control;
            this.thisContents.ContextMenuStrip = this.contextMenuStrip1;
            this.thisContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thisContents.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thisContents.Location = new System.Drawing.Point(0, 0);
            this.thisContents.Multiline = true;
            this.thisContents.Name = "thisContents";
            this.thisContents.ReadOnly = true;
            this.thisContents.Size = new System.Drawing.Size(244, 389);
            this.thisContents.TabIndex = 0;
            this.thisContents.Text = resources.GetString("thisContents.Text");
            this.thisContents.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gNUGeneralPublicLicenseToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(261, 50);
            // 
            // gNUGeneralPublicLicenseToolStripMenuItem
            // 
            this.gNUGeneralPublicLicenseToolStripMenuItem.Name = "gNUGeneralPublicLicenseToolStripMenuItem";
            this.gNUGeneralPublicLicenseToolStripMenuItem.Size = new System.Drawing.Size(260, 24);
            this.gNUGeneralPublicLicenseToolStripMenuItem.Text = "GNU General Public License";
            this.gNUGeneralPublicLicenseToolStripMenuItem.Click += new System.EventHandler(this.gNUGeneralPublicLicenseToolStripMenuItem_Click);
            // 
            // contents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(244, 389);
            this.Controls.Add(this.thisContents);
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "contents";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contents";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox thisContents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gNUGeneralPublicLicenseToolStripMenuItem;
    }
}