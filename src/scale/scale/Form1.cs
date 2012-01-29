/**
 * 
 *  Copyright (C) 2011 KryptonX, Krypton-Project 2012
 * 
 *  This file is part of Scale 
 *  
 *  Scale is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  Scale is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 * 
 *  You should have received a copy of the GNU General Public License
 *  along with Scale.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * 
 **/

// using...
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using fsystem;

namespace scale
{
    public partial class form : Form
    {
        public string proj = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ScaleIDE/";   // IMPORTANT FOLDER PATH
        public const string compiler_location = "kcsv.exe";     // compiler_location
        public static string outputlocation;    // output location (compiled file)
        public static string fileLocation;
        public string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
        // plenty of booleans...
        public string loadedfile;
        public static bool isProject = false;
        public bool fileSaved = false;
        public bool dataWritten = false;

        public static bool willLoad = false;
        private string pfiledirectory;

        // array galore

        public static string[] lproj;
        public string parameter = string.Empty;
        
        int index;
        int lline;
        int firstChar;
        int column;

        public form()
        {
            // make sure ALL is in order (directories)
            
                setup.init();   // if everything is already setup NOTHING will happen

                InitializeComponent();

                PopulateTreeView(desktop);
                /* Line */
                index = codeWindow.SelectionStart;
                lline = codeWindow.GetLineFromCharIndex(index);
                this.lnLbl.Text = "Line: " + lline.ToString();
                tline.Text = "Lines: " + codeWindow.Lines.Count().ToString();
                /* col */
                firstChar = codeWindow.GetFirstCharIndexFromLine(lline);
                column = index - firstChar;
                clLbl.Text = "Column: " + column.ToString();
                /* Position */
                this.locationLbl.Text = codeWindow.Location.ToString();
                /* Lines Total */
                this.lineN.Text = "Lines: " + codeWindow.Lines.Count();
                /* Length */
                this.lengthN.Text = "Length: " + codeWindow.TextLength.ToString();
                /* Selection */
                this.sel.Text = "ChSel: " + codeWindow.SelectedText.Count().ToString();
                /* Encoding */
                this.encodingLbl.Text = "Encoding: " + "UTF-8";
                /* Operating System */
                this.osLbl.Text = Environment.OSVersion.Platform.ToString();
                /* DOS */
                this.dosLbl.Text = "DOS/Windows";
                /* OS VERSION STRING */
                this.vs.Text = Environment.Version.ToString();
                /* OSSTR */
                this.osstr.Text = Environment.OSVersion.VersionString;
                /* CMPSTR */
                this.userdomain.Text = Environment.UserDomainName.ToString();
                /* End Label */
                this.endlbl.Text = Environment.WorkingSet.ToString();

                osRelease.Text = Environment.OSVersion.VersionString;
                sysData.Text = Environment.OSVersion.Platform.ToString();
                machineID.Text = Environment.MachineName.ToString();

                if (Environment.Is64BitOperatingSystem)
                    languageLbl.Text = "64bit OS";
                else languageLbl.Text = "32bit OS";

                codeWindow.Settings.Keywords.Add("print");
                codeWindow.Settings.Keywords.Add("echo");
                codeWindow.Settings.Keywords.Add("system");
                codeWindow.Settings.Keywords.Add("ToFloat");
                codeWindow.Settings.Keywords.Add("if");
                codeWindow.Settings.Keywords.Add("ToDouble");
                codeWindow.Settings.Keywords.Add("ToShort");
                codeWindow.Settings.Keywords.Add("ToLong");
                codeWindow.Settings.Keywords.Add("string");                
                codeWindow.Settings.Keywords.Add("import");               
                codeWindow.Settings.Keywords.Add("forever");
                codeWindow.Settings.Keywords.Add("for");
                codeWindow.Settings.Keywords.Add("do");
                codeWindow.Settings.Keywords.Add("while");
                codeWindow.Settings.Keywords.Add("in");

                
                
           
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtf.SendToBack();
            
            // Add the keywords to the list.


            // Set the comment identifier. 

            // For Lua this is two minus-signs after each other (--).

            // For C++ code we would set this property to "//".

            codeWindow.Settings.Comment = "#";

            // Set the colors that will be used.

            codeWindow.Settings.KeywordColor = Color.Blue;
            codeWindow.Settings.CommentColor = Color.Firebrick;
            codeWindow.Settings.StringColor = Color.LimeGreen;
            codeWindow.Settings.IntegerColor = Color.Black;
            codeWindow.Settings.EnableComments = true;


            codeWindow.Settings.EnableStrings = true;
            codeWindow.Settings.EnableIntegers = true;

            codeWindow.CompileKeywords();

            // Load a file and update the syntax highlighting.

            codeWindow.ZoomFactor = zoomFactorBar.Value;
            
            try
            {
                loadPreferences();
            }

            catch
            {
                MessageBox.Show("Could not load preferences.\nDefault values have been loaded instead.",
                    "Scale", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

            if (!Directory.Exists(proj))
                Directory.CreateDirectory(proj);
            if (!Directory.Exists(proj + "projects"))
                Directory.CreateDirectory(proj + "projects");
            if (!Directory.Exists(proj + "docs"))
                Directory.CreateDirectory(proj + "docs");
        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProject == false)
            {
  
                        saveFilePrompt();
                        fileSaved = true;
                        dataWritten = true;
                        string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                        if (res.IndexOf("error") != -1)
                            MessageBox.Show(res, "Compilation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (File.Exists(desktop + "/a.exe"))
                            File.Delete(desktop + "/a.exe");
                        if (File.Exists("a.exe"))
                        {
                            File.Copy("a.exe", desktop + "/a.exe");
                            File.Delete("a.exe");
                        }
                        
                  
            
            }
            else
            {
                if (fileSaved == false || dataWritten == false)
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Scale needs to save the file first.\nSave file?", "Scale",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        saveFilePrompt();
                        fileSaved = true;
                        dataWritten = true;
                        string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                        if (res.IndexOf("error") != -1)
                            MessageBox.Show(res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (File.Exists(outputlocation + "a.exe"))
                            File.Delete(outputlocation + "a.exe");
                        if (File.Exists("a.exe"))
                        {
                            File.Copy("a.exe", outputlocation + "a.exe");
                            File.Delete("a.exe");
                        }
                    }

                    else if (dr == DialogResult.No)
                        ;
                }

                else if (rtf.Text.Length == 0)
                {
                    MessageBox.Show("Why on earth are you trying to compile an empty file!?",
                        "Scale", MessageBoxButtons.OK, MessageBoxIcon.Information, 0, MessageBoxOptions.ServiceNotification);
                }

                else
                {
                   string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                   if (res.IndexOf("error") != -1)
                       MessageBox.Show(res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (outputlocation != string.Empty)
                    {
                        if (File.Exists(outputlocation + "a.exe"))
                            File.Delete(outputlocation + "a.exe");
                        if (File.Exists("a.exe"))
                        {
                            File.Copy("a.exe", outputlocation + "a.exe");
                            File.Delete("a.exe");
                        }
                    }

                    else {
                        if (File.Exists(desktop + "/a.exe"))
                        {
                            File.Delete(desktop + "/a.exe");
                            if (File.Exists("a.exe"))
                            {
                                File.Copy("a.exe", desktop + "/a.exe");
                                File.Delete("a.exe");
                            }
                        }
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = desktop;
            openFile.Filter = "Zenon Scripts (.zn)|*.zn";
            if (openFile.ShowDialog() == DialogResult.OK)
            {               
                loadedfile = openFile.FileName;
                pfiledirectory = Path.GetDirectoryName(openFile.FileName);

                if (loadedfile.IndexOf(".scsl") == (-1))
                {

                    if (fileSaved == true || codeWindow.Text != "")
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(loadedfile))
                        {
                            codeWindow.Text = sr.ReadToEnd();
                            sr.Dispose();
                            codeWindow.ProcessAllLines();
                        }
                        

                    }

                    else
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(loadedfile))
                        {
                            codeWindow.Text = sr.ReadToEnd();
                            sr.Dispose();
                            codeWindow.ProcessAllLines();
                        }
                    }
                }

                else if (loadedfile.IndexOf(".scsl") != (-1))
                {                    
                    loadProjectFromFile(loadedfile);
                    codeWindow.ProcessAllLines();
                }

                fileSaved = true;
                dataWritten = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileSaved)
            {
                SaveFileDialog sv = new SaveFileDialog();
                sv.Filter = "Zenon Scripts (.zn)|*.zn"; ;

                if (sv.ShowDialog() == DialogResult.OK)
                {
                    loadedfile = sv.FileName;
                    fileSaved = true;
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                    {
                        sw.Write(codeWindow.Text);
                        sw.Dispose();
                        dataWritten = true;
                    }
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                {
                    sw.Write(codeWindow.Text);
                    sw.Dispose();
                    dataWritten = true;

                }
            }

        }

        private void status_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            index = codeWindow.SelectionStart;
            lline = codeWindow.GetLineFromCharIndex(index);
            string p_line = "Ln: " + lline.ToString() + "\n";

            /* Columns */
            firstChar = codeWindow.GetFirstCharIndexFromLine(lline);
            column = index - firstChar;
            string p_col = "Col: " + column.ToString() + "\n";

            /* Position */
            string p_pos = "Point: " + codeWindow.Location.ToString() + "\n";

            /* Lines Total */
            string p_l = "Lines: " + codeWindow.Lines.Count() + "\n";

            /* Length */
            string p_length = "Length: " + codeWindow.TextLength.ToString() + "\n";

            /* Encoding */
            string p_enc = "Encoding: " + "UTF-8" + "\n";

            MessageBox.Show(("File Info\n\n" + "File Path: " + loadedfile + "\nCode Type: C#" + "\nScript Type: Runtime\n")
                    + "" + ("\nData Info\n\n" + p_line + p_col + p_pos + p_l + p_length + p_enc), "Workspace Values: ",
                MessageBoxButtons.OK, MessageBoxIcon.Information, 0, 0);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Zenon Scripts (.zn)|*.zn"; ;

            if (sv.ShowDialog() == DialogResult.OK)
            {
                loadedfile = sv.FileName;
                fileSaved = true;
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                {
                    sw.Write(codeWindow.Text);
                    sw.Dispose();
                    dataWritten = true;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void codeWindow_TextChanged(object sender, EventArgs e)
        {
            index = codeWindow.SelectionStart;
            lline = codeWindow.GetLineFromCharIndex(index);
            this.lnLbl.Text = "Line: " + lline.ToString(); column = index - firstChar;
            clLbl.Text = "Column: " + column.ToString();
            /* Position */
            this.locationLbl.Text = codeWindow.Location.ToString();
            tline.Text = "Lines: " + codeWindow.Lines.Count().ToString();
            dataWritten = false;            
        }

        private void toolStripStatusLabel16_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fileSaved == false || dataWritten == false)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Exit without saving data?", "Scale",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    fileSaved = true;
                    dataWritten = true;
                    Application.Exit();
                }
                else if (dr == DialogResult.Cancel)
                    e.Cancel = true;
                else if (dr == DialogResult.No)
                {
                    if (fileSaved == false)
                    {
                        SaveFileDialog sv = new SaveFileDialog();
                        sv.Filter = "CSharp Code (.cs)|*.cs";
                        if (sv.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                loadedfile = sv.FileName;
                                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                                {
                                    sw.Write(codeWindow.Text);
                                    fileSaved = true;
                                }
                            }
                            catch { ; }
                        }
                    }
                    else
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                        {
                            sw.Write(codeWindow.Text);
                            sw.Dispose();
                        }
                    }
                }
            }
        }

        private void compileRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isProject == false)
            {

                        saveFilePrompt();
                        fileSaved = true;
                        dataWritten = true;
                        string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                        if (res.IndexOf("error") != -1)
                            MessageBox.Show(res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (File.Exists(desktop + "/a.exe"))
                            File.Delete(desktop + "/a.exe");
                        if (File.Exists("a.exe"))
                        {
                            File.Copy("a.exe", desktop + "/a.exe");
                            systemfunctions.ExecCmd("start " + desktop + "/a.exe " + parameter);
                        }
                   
                

            }
            else
            {
                if (fileSaved == false || dataWritten == false)
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Scale needs to save the file first.\nSave file?", "Scale",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        saveFilePrompt();
                        fileSaved = true;
                        dataWritten = true;
                       string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                       if (res.IndexOf("error") != -1)
                           MessageBox.Show(res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        if (outputlocation != string.Empty)
                        {
                            if (File.Exists(outputlocation + "a.exe"))
                                File.Delete(outputlocation + "a.exe");
                            if (File.Exists("a.exe"))
                            {
                                File.Copy("a.exe", outputlocation + "a.exe");
                                systemfunctions.ExecCmd("start " + outputlocation + "a.exe" + " " + parameter);
                                File.Delete("a.exe");
                            }
                        }

                        else
                        {
                            if (File.Exists(desktop + "/a.exe"))
                                File.Delete(desktop + "/a.exe");
                            File.Copy("a.exe", desktop + "/a.exe");
                            string _res = systemfunctions.ExecCmd("start " + desktop + "/a.exe" + " " + parameter);
                            if (_res.IndexOf("error") != -1)
                                MessageBox.Show(_res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            File.Delete("a.exe");
                        }
                    }

                    else if (dr == DialogResult.No)
                        ;
                }
                

                else
                {
                   string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                   if (res.IndexOf("error") != -1)
                       MessageBox.Show(res, "Compilation Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    if (outputlocation != string.Empty)
                    {
                        if (File.Exists(outputlocation + "a.exe"))
                             File.Delete(outputlocation + "a.exe");
                        if (File.Exists("a.exe"))
                        {
                            File.Copy("a.exe", outputlocation + "a.exe");
                            systemfunctions.ExecCmd("start " + outputlocation + "a.exe" + " " + parameter);
                            File.Delete("a.exe");
                        }
                    }

                    else { File.Copy("a.exe", desktop + "/a.exe");
                    systemfunctions.ExecCmd("start " + desktop + "/a.exe");
                    File.Delete("a.exe");
                    }
                }
            }
            
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (isProject == true)
            {
                if (File.Exists(outputlocation + "a.exe"))                
                    systemfunctions.ExecCmd("start " + outputlocation + "a.exe" + " " + parameter);
                    
                else MessageBox.Show("Project is not compiled!", "Scale", MessageBoxButtons.OK
                    , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

            else
            {
                if (File.Exists(desktop + "/a.exe"))
                    systemfunctions.ExecCmd("start " + desktop + "/a.exe");
                else MessageBox.Show("Project is not compiled!", "Scale", MessageBoxButtons.OK
                    , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        public void saveFilePrompt()
        {
            if (!dataWritten)
            {
                if (!fileSaved)
                {
                    SaveFileDialog sv = new SaveFileDialog();
                    sv.Filter = "CSharp Code (.cs)|*.cs";

                    if (sv.ShowDialog() == DialogResult.OK)
                    {
                        loadedfile = sv.FileName;
                        fileSaved = true;
                        dataWritten = true;
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                        {
                            sw.Write(codeWindow.Text);
                            sw.Dispose();
                        }
                    }
                }

                else
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                    {
                        sw.Write(codeWindow.Text);
                        sw.Dispose();
                    }
                }
            }
            else
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(loadedfile))
                {
                    sw.Write(codeWindow.Text);
                    sw.Dispose();
                }
            }
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fileSaved == false && codeWindow.Text.Length > 0)
            {
                (new form()).Show();
            }

            else
            {
               string pt =  newFile.CreateNewCSFile(newProject.programsrcDirectory);
               LoadInNewWindow(pt);    
            };
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new newProject()).ShowDialog();
            loadNewProject();
            codeWindow.ProcessAllLines();
        }

        public void loadNewProject()
        {
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(newProject.programsrcDirectory))
                {
                    this.codeWindow.Text = sr.ReadToEnd();
                    sr.Dispose();
                    outputlocation = newProject.binDirectory.ToString();
                    loadedfile = newProject.programsrcDirectory.ToString();
                    fileSaved = true;
                    dataWritten = true;
                    isProject = true;
                    PopulateTreeView(newProject.projdir);
                    tabPage1.Text = newProject.programsrcDirectory.ToString();
                }
            }

            catch { ; }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.codeWindow.CanUndo == true)
                    this.codeWindow.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.codeWindow.CanRedo == true)
                this.codeWindow.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeWindow.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeWindow.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeWindow.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.codeWindow.SelectAll();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new contents()).ShowDialog(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new about()).ShowDialog(this);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            (new about()).ShowDialog(this);
        }

        private void PopulateTreeView(string dir)
        {
            TreeNode rootNode;
            TreeNode fNode;

            DirectoryInfo info = new DirectoryInfo(@dir);
            
            if (info.Exists)
            {
                rootNode = new TreeNode(info.Name);
                fNode = new TreeNode(info.Name);
                rootNode.Tag = info;
                fNode.Tag = info;
                GetDirectories(info.GetDirectories(), rootNode);
                
                treeView1.Nodes.Add(rootNode);
            }
        }

        private void GetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {

            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    GetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            listView1.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            try
            {
                foreach (FileInfo file in nodeDirInfo.GetFiles())
                {
                    item = new ListViewItem(file.Name, 1);
                    subItems = new ListViewItem.ListViewSubItem[]
            { new ListViewItem.ListViewSubItem(item, "File"), 
             new ListViewItem.ListViewSubItem(item, 
                file.LastAccessTime.ToShortDateString())};

                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
            }

            catch { ; }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);            
        }

        /// <summary>
        /// Now the static functions so that the project functions can use it
        /// </summary>
        /// 

        public static void SGetDirectories(DirectoryInfo[] subDirs,
            TreeNode nodeToAddTo)
        {

            TreeNode aNode;
            DirectoryInfo[] subSubDirs;
            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                aNode.ImageKey = "folder";
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    SGetDirectories(subSubDirs, aNode);
                }
                nodeToAddTo.Nodes.Add(aNode);
            }

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string msg = string.Empty;
            if (fileSaved == true)
                msg = loadedfile.ToString();
            foreach (ToolStripItem i in statusStrip1.Items)
            {
                msg += i.Text;
                msg += System.Environment.NewLine;
            }

           

            MessageBox.Show(msg, "Scale Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        public void LoadFile(string file)
        {
            using (System.IO.StreamReader sr = new System.IO.StreamReader(file))
            {
                this.codeWindow.Text = sr.ReadToEnd();
                sr.Dispose();
            }
        }

        public void LoadInNewWindow(string fpath)
        {
            form frm = new form();
            frm.Show();
            frm.LoadFile(fpath);
        }

        
        private void showExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showExplorerToolStripMenuItem.Checked)
            {
                leftPanels.Visible = false;
                lowerPanel.ColumnCount = 1;
            }

            else 
            {
                lowerPanel.ColumnCount = 2;
                leftPanels.Visible = true;
            }
        }

        public void loadPreferences()
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
                        showExplorerToolStripMenuItem.Checked = false;
                        leftPanels.Visible = false;
                        lowerPanel.ColumnCount = 1;
                    }

                    else
                    {
                        showExplorerToolStripMenuItem.Checked = true;
                        leftPanels.Visible = true;
                        lowerPanel.ColumnCount = 2;
                    }

                    if (vprefs[1].IndexOf("false") != -1)
                    {
                        statusStrip1.Visible = false;
                        showStatusStripToolStripMenuItem.Checked = false;
                    }

                    else
                    {
                        showStatusStripToolStripMenuItem.Checked = true;
                        statusStrip1.Visible = true;
                    }

                    
                    if (vprefs[3].IndexOf("false") != -1)
                    {
                        lineNumbersToolStripMenuItem.Checked = false;
                        splitContainer1.Panel1.Hide();
                    }

                    else
                    {
                        lineNumbersToolStripMenuItem.Checked = true;
                        splitContainer1.Panel1.Show();
                    }
                }

                catch { ; }

                sr.Dispose();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showStatusStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!showStatusStripToolStripMenuItem.Checked)
                statusStrip1.Visible = false;
            else statusStrip1.Visible = true;
        }

    
        private void preferencesManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new vpreface()).ShowDialog(this);
        }

        private void stopDebuggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ;
        }

        public void loadProjectFromFile(string project)
        {
            string ftext;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(project))
            {
                string projectf = sr.ReadToEnd();
                lproj = projectf.Split('\n'); 
                sr.Dispose();
            }

            int j = lproj.Count();
            try
            {
                outputlocation = lproj[1];
                ftext = lproj[2];
                fileSaved = true;                
                dataWritten = true;
                isProject = true;
                string pfaith;
                using (System.IO.StreamReader sr = new System.IO.StreamReader(pfiledirectory + "\\p.file"))
                {
                    pfaith = sr.ReadLine();
                    sr.Dispose();
                }

                using (System.IO.StreamReader sr = new System.IO.StreamReader(pfaith))
                {
                    codeWindow.Text = sr.ReadToEnd();
                    sr.Dispose();
                }
                
            }

            catch { MessageBox.Show("Formatting Error!", "Scale", MessageBoxButtons.OK, MessageBoxIcon.Error, 0, MessageBoxOptions.ServiceNotification); }


        }

              

        private void codeWindow_TextChanged_1(object sender, EventArgs e)
        {
            index = codeWindow.SelectionStart;
            lline = codeWindow.GetLineFromCharIndex(index);
            this.lnLbl.Text = "Line: " + lline.ToString(); column = index - firstChar;
            clLbl.Text = "Column: " + column.ToString();
            /* Position */
            this.locationLbl.Text = codeWindow.Location.ToString();
            tline.Text = "Lines: " + codeWindow.Lines.Count().ToString();
            dataWritten = false;

        }

        private void lineNumbersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lineNumbersToolStripMenuItem.Checked)
                splitContainer1.Panel1.Hide();
            else splitContainer1.Panel1.Show();
        }

        private void codeWindow_TextChanged_2(object sender, EventArgs e)
        {
            rtf.Text = codeWindow.Text;
            rtf.Text += " ";
            dataWritten = false;
            index = codeWindow.SelectionStart;
            lline = codeWindow.GetLineFromCharIndex(index);
            this.lnLbl.Text = "Line: " + lline.ToString(); column = index - firstChar;
            clLbl.Text = "Column: " + column.ToString();
            /* Position */
            this.locationLbl.Text = codeWindow.Location.ToString();
            tline.Text = "Lines: " + codeWindow.Lines.Count().ToString();
           
            

            codeWindow.ProcessAllLines();

            

                        
        }


        private void codeWindow_KeyDown(object sender, KeyEventArgs e)
        {
            int c = e.KeyValue;
            if (e.KeyCode == Keys.Enter)
                rtf.Text += "\n";            
               
        }

        private void zoomFactorBar_Scroll(object sender, EventArgs e)
        {
            if (zoomFactorBar.Value >= 1)
                this.codeWindow.ZoomFactor = this.zoomFactorBar.Value;
        }

        private void updateNumberLabel()
        {
            //we get index of first visible char and number of first visible line
            Point pos = new Point(0, 0);
            int firstIndex = rtf.GetCharIndexFromPosition(pos);
            int firstLine = rtf.GetLineFromCharIndex(firstIndex);

            //now we get index of last visible char and number of last visible line
            pos.X = ClientRectangle.Width;
            pos.Y = ClientRectangle.Height;
            int lastIndex = rtf.GetCharIndexFromPosition(pos);
            int lastLine = rtf.GetLineFromCharIndex(lastIndex);

            //this is point position of last visible char, we'll use its Y value for calculating numberLabel size
            pos = rtf.GetPositionFromCharIndex(lastIndex);


            //finally, renumber label
            numberLabel.Text = "";
            for (int i = firstLine; i <= lastLine + 1; i++)
            {
                numberLabel.Text += i + 1 + "\n";
            }

        }

        private void codeWindow_VScroll(object sender, EventArgs e)
        {
            //move location of numberLabel for amount of pixels caused by scrollbar
            int d = codeWindow.GetPositionFromCharIndex(0).Y % (codeWindow.Font.Height + 1);
            numberLabel.Location = new Point(0, d);

            updateNumberLabel();
        }

        private void rtf_TextChanged(object sender, EventArgs e)
        {
            updateNumberLabel();
            dataWritten = false;
        }

        private void rtf_VScroll(object sender, EventArgs e)
        {
            //move location of numberLabel for amount of pixels caused by scrollbar
            int d = codeWindow.GetPositionFromCharIndex(0).Y % (codeWindow.Font.Height + 1);
            numberLabel.Location = new Point(0, d);

            updateNumberLabel();
        }

        private void batchScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new batchexec()).ShowDialog(this);
        }

        private void ryeScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new execrye()).ShowDialog(this);
        }

        private void fileAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toExecutableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Executable (.exe)|*.exe|Class Library (.dll)|*.dll";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string ff = saveFile.FileName;
                string res = systemfunctions.ExecCmd("kcsc -c " + loadedfile);
                if (res.IndexOf("error") != -1)
                    MessageBox.Show(res, "Compilation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                else
                {
                    if (File.Exists("a.exe"))
                    {
                        File.Copy("a.exe", ff);
                    }
                    
                }
                saveFile.Dispose();
            }
        }

        private void fullscreenModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }

            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Maximized;
            }

        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new parameters()).ShowDialog();
            parameter = parameters.wParam.ToString();
        }

        private void cSharpHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codeproject.com/KB/cs/");
        }

        private void searchWikipediaENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://en.wikipedia.org/wiki/Main_Page");
        }

        private void recherchezWikipediaFRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://fr.wikipedia.org/wiki/Wikip%C3%A9dia:Accueil_principal");
        }

        private void launchFirefoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("firefox");
        }

        private void launchChromeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PStart("chrome");
        }

        public void PStart(string proc)
        {
            System.Diagnostics.Process.Start(proc);
        }

        private void launchOperaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PStart("opera");
        }

        private void launchSafariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PStart("safari");
        }

        private void mSDOSCommandPromptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("bin/ccd.exe");
        }

        public static int verify()
        {
            if (File.Exists("SyntaxHighlighter.dll"))
                return 0;
            else return (-1);
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
