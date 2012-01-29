using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web;
using System.Security.Cryptography;

namespace scale
{
    public partial class newProject : Form
    {
        public static string binDirectory;
        public static string programsrcDirectory;
        public static string projdir;

        public static string[] stdcs = {
                                          "using System;",
                                          "using System.Diagnostics;",                                          
                                          "using System.Collections.Generic;",
                                          "using System.ComponentModel;",
                                          "",
                                          "namespace CSharpApp    {",
                                          "public class Program	{",                                          
                                          "public static void Main(String[] args)  {",
                                          "",
                                          "System.Console.WriteLine(\"Hello, World!\");",
                                          "System.Console.In.Read();",
                                          "      }",
                                          "   }",
                                          "}",

                                    };

        public string[] stdvb = {

                                       "Imports System",
                                       "Imports System.Collections",
                                       "Imports System.ComponentModel",
                                       "Imports System.Data",
                                       "",
                                       "Module Module1",
                                       "",
                                       "Sub Main(ByVal args() As String)",
                                       "\tConsole.WriteLine(\"Hello, World!\")",
                                       "\tConsole.ReadLine()",                                       
                                       "End Sub",
                                       "",
                                       "End Module",

                                };

        public string programfile;
        public newProject()
        {
            InitializeComponent();
            path.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void newProject_Load(object sender, EventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path.Text = fbd.SelectedPath;
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            
            if (path.Text.Length > 0 && projName.Text.Length > 0)
            {
                string def = path.Text + "\\" + projName.Text;
                Directory.CreateDirectory(def);
                if (createSol.Checked == true)
                    Directory.CreateDirectory(def + "\\" + projName.Text + ".scaleproj");
                Directory.CreateDirectory(def + "\\src");
                if (addFiles.Checked == true)
                    Directory.CreateDirectory(def + "\\docs");
                Directory.CreateDirectory(def + "\\bin");

                string bin = def + "\\bin\\";
                string src = def + "\\src\\";

                if (csBtn.Checked == true)
                {

                    if (createSol.Checked == true)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/" + projName.Text + ".scaleproj/" + projName.Text
                            + ".scsl"))
                        {
                            string ppr = projName.Text.ToString();
                            sw.WriteLine(ppr);
                            sw.WriteLine(bin);
                            sw.WriteLine(src + "Program.cs");
                            string lang;
                            if (csBtn.Checked == true)
                                lang = "{csharp}";
                            else lang = "{visualbasic}";

                            sw.WriteLine("executable");
                            sw.WriteLine("msdos");
                            sw.WriteLine(lang);

                            sw.WriteLine(".NETFramework");
                            sw.WriteLine("console\nscript/text");
                            sw.WriteLine("[ENVIRONMENT:A1]");
                            sw.WriteLine("[COMPILER:A1]");
                            sw.WriteLine("-> /bin");
                           

                            SHA1 sha1 = new SHA1CryptoServiceProvider();
                            string hashsum = string.Empty;
                            byte[] data = sha1.ComputeHash(Encoding.Unicode.GetBytes((ppr + path.Text).ToString()));
                            foreach (byte i in data)
                            {
                                hashsum += String.Format("{0,2:X2}", i);
                            }

                            sw.WriteLine(hashsum);

                            sw.Dispose();
                        }

                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/" + projName.Text + ".scaleproj/p.file"))
                        {
                            sw.Write(src + "Program.cs");
                            sw.Dispose();
                        }


                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/" + projName.Text + ".scaleproj/" + projName.Text
                            + ".log"))
                        {
                            sw.Write(DateTime.Now.ToLongDateString() + "\tPROJECT:CREATED");
                            sw.Dispose();
                        }

                        if (csBtn.Checked == true)
                        {
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(src + "program.cs"))
                            {
                                for (int i = 0; i < stdcs.Count(); i++)
                                    sw.WriteLine(stdcs[i]);
                                sw.Dispose();
                            }

                            programfile = (src + "program.cs");
                            string output = def + "/bin/";

                            form.outputlocation = output;
                            form.fileLocation = programfile;
                            form.isProject = true;
                        }

                    }

                    else
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/src/program.cs"))
                        {
                            for (int i = 0; i <= 10; i++)
                                sw.WriteLine(stdcs[i]);
                            sw.Dispose();
                        }

                        programfile = (src + "program.cs");
                        string output = def + "/bin/";

                        form.outputlocation = output;
                        form.fileLocation = programfile;
                        form.isProject = false;
                    }

                }

                else if (vbBtn.Checked == true)
                {
                    if (createSol.Checked == true)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/" + projName.Text + ".scaleproj/" + projName.Text
                            + ".scsl"))
                        {
                            string ppr = projName.Text.ToString();
                            sw.WriteLine(ppr);
                            sw.WriteLine(bin);
                            string lang;
                            if (csBtn.Checked == true)
                                lang = "{csharp}";
                            else lang = "{visualbasic}";

                            sw.WriteLine("executable");
                            sw.WriteLine("msdos");
                            sw.WriteLine(lang);

                            sw.WriteLine(".NETFramework");
                            sw.WriteLine("console\nscript/text");
                            sw.WriteLine("[ENVIRONMENT:A1]");
                            sw.WriteLine("[COMPILER:A1]");
                            sw.WriteLine("-> /bin");
                            sw.WriteLine(src + "Module1.vb");

                            SHA1 sha1 = new SHA1CryptoServiceProvider();
                            string hashsum = string.Empty;
                            byte[] data = sha1.ComputeHash(Encoding.Unicode.GetBytes((ppr + path.Text).ToString()));
                            foreach (byte i in data)
                            {
                                hashsum += String.Format("{0,2:X2}", i);
                            }

                            sw.WriteLine(hashsum);

                            sw.Dispose();
                        }


                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(def + "/" + projName.Text + ".scaleproj/" + projName.Text
                            + ".log"))
                        {
                            sw.Write(DateTime.Now.ToLongDateString() + "\tPROJECT:CREATED");
                            sw.Dispose();
                        }

                        if (vbBtn.Checked == true)
                        {
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(src + "Module1.vb"))
                            {
                                for (int i = 0; i < stdvb.Length; i++)
                                    sw.WriteLine(stdvb[i]);
                                sw.Dispose();
                            }

                            programfile = (src + "Module1.vb");
                            string output = def + "/bin/";

                            form.outputlocation = output;
                            form.fileLocation = programfile;
                            form.isProject = true;
                        }
                    }
                    
                }

                binDirectory = bin.ToString();
                programsrcDirectory = programfile.ToString();
                projdir = def.ToString();
            }

            else
            {
                MessageBox.Show("Fill in all fields!", "Scale", MessageBoxButtons.OK, MessageBoxIcon.Warning, 0);
            }

            this.Close();
        }

        private void createSol_CheckedChanged(object sender, EventArgs e)
        {
            if (!createSol.Checked)
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Unchecking this box will create a single file project.\nSaving preferences will be disabled.\nThis is not recommended.\nAre you sure you want to proceed?",
                    "Scale Compiler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                    createSol.Checked = false;
                else createSol.Checked = true;
            }
                
        }

        private void vbBtn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
