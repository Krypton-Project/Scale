namespace scale
{
    partial class newProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newProject));
            this.formBase = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addFiles = new System.Windows.Forms.CheckBox();
            this.createSol = new System.Windows.Forms.CheckBox();
            this.vbBtn = new System.Windows.Forms.RadioButton();
            this.csBtn = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.projName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.path = new System.Windows.Forms.TextBox();
            this.formBase.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formBase
            // 
            this.formBase.ColumnCount = 1;
            this.formBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.formBase.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.formBase.Controls.Add(this.panel1, 0, 0);
            this.formBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formBase.Location = new System.Drawing.Point(0, 0);
            this.formBase.Name = "formBase";
            this.formBase.RowCount = 2;
            this.formBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.3681F));
            this.formBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.6319F));
            this.formBase.Size = new System.Drawing.Size(515, 163);
            this.formBase.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.cancelBtn);
            this.flowLayoutPanel1.Controls.Add(this.okBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 134);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(509, 26);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelBtn.Location = new System.Drawing.Point(431, 3);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "&Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okBtn.Location = new System.Drawing.Point(350, 3);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "&Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addFiles);
            this.panel1.Controls.Add(this.createSol);
            this.panel1.Controls.Add(this.vbBtn);
            this.panel1.Controls.Add(this.csBtn);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 125);
            this.panel1.TabIndex = 1;
            // 
            // addFiles
            // 
            this.addFiles.AutoSize = true;
            this.addFiles.Location = new System.Drawing.Point(229, 101);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(116, 21);
            this.addFiles.TabIndex = 4;
            this.addFiles.Text = "Additional Files";
            this.addFiles.UseVisualStyleBackColor = true;
            // 
            // createSol
            // 
            this.createSol.AutoSize = true;
            this.createSol.Checked = true;
            this.createSol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.createSol.Location = new System.Drawing.Point(9, 101);
            this.createSol.Name = "createSol";
            this.createSol.Size = new System.Drawing.Size(214, 21);
            this.createSol.TabIndex = 3;
            this.createSol.Text = "Create Project Preference Log";
            this.createSol.UseVisualStyleBackColor = true;
            this.createSol.CheckedChanged += new System.EventHandler(this.createSol_CheckedChanged);
            // 
            // vbBtn
            // 
            this.vbBtn.AutoSize = true;
            this.vbBtn.Enabled = false;
            this.vbBtn.Location = new System.Drawing.Point(404, 99);
            this.vbBtn.Name = "vbBtn";
            this.vbBtn.Size = new System.Drawing.Size(96, 21);
            this.vbBtn.TabIndex = 2;
            this.vbBtn.Text = "Visual Basic";
            this.vbBtn.UseVisualStyleBackColor = true;
            this.vbBtn.CheckedChanged += new System.EventHandler(this.vbBtn_CheckedChanged);
            // 
            // csBtn
            // 
            this.csBtn.AutoSize = true;
            this.csBtn.Checked = true;
            this.csBtn.Location = new System.Drawing.Point(350, 100);
            this.csBtn.Name = "csBtn";
            this.csBtn.Size = new System.Drawing.Size(48, 21);
            this.csBtn.TabIndex = 1;
            this.csBtn.TabStop = true;
            this.csBtn.Text = "C#";
            this.csBtn.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.projName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.browseBtn);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.path);
            this.panel2.Location = new System.Drawing.Point(50, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 79);
            this.panel2.TabIndex = 0;
            // 
            // projName
            // 
            this.projName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projName.Location = new System.Drawing.Point(6, 39);
            this.projName.Name = "projName";
            this.projName.Size = new System.Drawing.Size(92, 26);
            this.projName.TabIndex = 6;
            this.projName.Text = "csApp1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // browseBtn
            // 
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.browseBtn.Location = new System.Drawing.Point(308, 40);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // path
            // 
            this.path.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.path.Location = new System.Drawing.Point(118, 39);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(186, 26);
            this.path.TabIndex = 0;
            // 
            // newProject
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(515, 163);
            this.ControlBox = false;
            this.Controls.Add(this.formBase);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scale New Project";
            this.Load += new System.EventHandler(this.newProject_Load);
            this.formBase.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel formBase;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton vbBtn;
        private System.Windows.Forms.RadioButton csBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.CheckBox createSol;
        private System.Windows.Forms.TextBox projName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox addFiles;
    }
}