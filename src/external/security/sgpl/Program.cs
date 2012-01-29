/**
 * 
 *  Copyright (C) 2011 KryptonX, Krypton-Project 2012
 * 
 *  This file is part of Scale (sub section).
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

/// <summary>
/// Please note the following:
///     * This Program is part of Scale
///     * A sub project of Scale only!
///     * NOT TO DISTRIBUTED INDIVIDUALLY
///     * Provided without any kind of warranty
/// As opensource as Scale :P
/// </summary>

/// <summary>
/// using statements (boring)
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace sgpl      // Declare namespace, nothing new
{
    class Program   // Declare the class
    {
        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // string root points to MyDocuments
        public static string prefs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/krypton-project/scale/legal/";    // legal folder
        public static string gpl = String.Empty;        // This string will remain empty until WebClient is used
        static void Main(string[] args)                 // Main(string[] args) function
        {
            if (!Directory.Exists(prefs))
                Directory.CreateDirectory(prefs);       // if <prefs> does not exist; create it
            WebClient webClient = new WebClient();      // Declare a new webclient (will be used to download the GPL Text
            webClient.DownloadFile("http://www.gnu.org/licenses/gpl.txt", @prefs + "/gpl.txt");     // Download the GPL text to a file in prefs @
            using (System.IO.StreamReader sr = new System.IO.StreamReader(prefs + "/gpl.txt"))      // Declare a StreamReader to read the GPL (from file)
            {
                gpl = sr.ReadToEnd();       // Store GNU General Public License in string::gpl
                sr.Dispose();               // I don't want it no more (just like in Six Blade Knife by Dire Straits...)
            }
            Console.WriteLine(gpl);         // Write GPL to screen
            Console.Write("Do you accept the GNU General Public License V3? (\"yes\" OR \"no\" "); // Accept or decline? The usual gig...

            string acc = string.Empty; 

            acc = System.Console.ReadLine();

            if (acc != "yes")
                Environment.Exit(0);    // KILLALL!
            else
            {
                /**
                 * 
                 * If the answer is YES
                 * 
                 **/
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(prefs + "/gkey")) 
                {
                    sw.WriteLine("accepted");       // Store yes in log

                    var sha1 = new SHA1CryptoServiceProvider();         // Declare SHA1 Generator (is this even correct?)
                    string hashsum = string.Empty;                  // Empty storage allocator
                    byte[] data = sha1.ComputeHash(Encoding.Unicode.GetBytes(prefs+"/gkey"));       // byte array
                    foreach (byte b in data)
                    {
                        hashsum += String.Format("{0,2:X2}", b);        // :-)
                    }
                    sw.Write(hashsum);

                    sw.Dispose();
                }
            }
        }

        // Guess what? This program is done
    }
}
