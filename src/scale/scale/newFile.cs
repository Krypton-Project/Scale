using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace scale
{
    class newFile
    {
        public static string[] xstdcs = {
                                          "using System;",
                                          "using System.Diagnostics;",                                          
                                          "using System.Collections.Generic;",
                                          "using System.ComponentModel;",
                                          "",
                                          "namespace CSharpApp    {",
                                          "public class Program	{",                                          
                                          "public static void Main(String[] args)  {",
                                          "\t\t",                                          
                                          "      }",
                                          "   }",
                                          "}",

                                    };

        public static string CreateNewCSFile(string dir)
        {
            int i = 1;
            while (File.Exists(dir + "module" + i + ".cs"))
                i++;
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(dir + "module" + i + ".cs"))
            {
                for (int ii = 0; ii < xstdcs.Count(); ii++)
                    sw.WriteLine(xstdcs[ii]);
                sw.Dispose();
            }

            string ret = dir + "module" + i + ".cs";
            return ret;
        }
        
    }
}
