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

namespace vsha1
{
    class Program
    {
        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // string root points to MyDocuments
        public static string prefs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/krypton-project/scale/legal/";    // legal folder

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "-v")
                {
                    Console.WriteLine("asdasd");
                    if (File.Exists(prefs + "/gkey"))
                    {
                            using (System.IO.StreamReader sr = new System.IO.StreamReader(prefs + "/gkey"))
                            {
                                string data = sr.ReadToEnd();
                                string[] f = data.Split('\n');
                                sr.Dispose();
                                if (f[0] == "accepted")
                                {
                                    string HASH = f[1].ToString();
                                    using (System.Security.Cryptography.SHA1CryptoServiceProvider sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider())
                                    {
                                        string hashsum = string.Empty;                  // Empty storage allocator
                                        byte[] da = sha1.ComputeHash(Encoding.Unicode.GetBytes(prefs + "/gkey"));       // byte array
                                        foreach (byte by in data)
                                        {
                                            hashsum += String.Format("{0,2:X2}", by);        // :-)
                                        }

                                        if (hashsum.ToString() != HASH.ToString())
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("SECURITY COMPROMISED!\n\nSHA1 HASH MODIFIED!\nRECORD DOES NOT MATCH G_KEY!\n\nCACHE WILL BE DELETED FOR SECURITY.");
                                            Console.Read();

                                        }

                                        else ;
                                        sha1.Dispose();

                                        try
                                        {
                                            Directory.Delete(prefs);
                                        }

                                        catch { ; }
                                    }
                                }

                            }
                         
                    }
                }

            }

            else
            {
                Console.Write("This is not a standalone application.");
            }
        }
    }
}
