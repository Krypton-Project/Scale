using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace scale
{
    class setup
    {
        public static string prefs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/krypton-project/preferences/";
        public static string viewprefs = prefs + "scale/view.prefs";
        public static string lang = prefs + "scale/lang.krml";
        public static bool init()
        {
            if (Directory.Exists(prefs) && Directory.Exists(prefs + "scale")
                && File.Exists(prefs + "scale/defaults") && File.Exists(prefs + "scale/view.prefs") && File.Exists("scale/lang.krml")
                && File.Exists(prefs + "scale/std.prefs"))
                return true;
            else
            {
                Directory.CreateDirectory(prefs);
                Directory.CreateDirectory(prefs + "scale");

                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(prefs + "scale/defaults"))
                {
                    sw.WriteLine("[0x21]");
                    sw.Dispose();
                }

                if (!File.Exists(prefs + "scale/view.prefs"))
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(prefs + "scale/view.prefs"))
                    {
                        sw.WriteLine("true");
                        sw.WriteLine("true");
                        sw.WriteLine("true");
                        sw.WriteLine("true");
                        sw.Dispose();
                    }
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(prefs + "scale/lang.krml"))
                    {
                        sw.WriteLine("<lang>");
                        sw.WriteLine("csharp");
                        sw.WriteLine("</lang>");
                        sw.Dispose();
                    }

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(prefs + "scale/std.prefs"))
                    {
                        sw.WriteLine("...");
                        sw.Dispose();
                    }
                }

                return false;
            }
        }
    }
}
