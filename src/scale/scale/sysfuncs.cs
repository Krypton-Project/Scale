using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fsystem;

namespace fsystem
{
    public class systemfunctions
    {
        public static string ExecCmd(string cmd)
        {
            /**
             * http://www.codeproject.com/KB/cs/Execute_Command_in_CSharp.aspx
             * 
             * Thanks to CodeProject!
             * 
             */

            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                   new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
                return result;
            }
            catch (Exception objException)
            {
                // Log the exception
                return ";";
            }

        }

        public static void ExecCmdVisible(string cmd)
        {
            /**
             * http://www.codeproject.com/KB/cs/Execute_Command_in_CSharp.aspx
             * 
             * Thanks to CodeProject!
             * 
             */

            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                   new System.Diagnostics.ProcessStartInfo("cmd", "/c " + cmd);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = false;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);

            }
            catch (Exception objException)
            {
                // Log the exception

            }

        }
    }
}