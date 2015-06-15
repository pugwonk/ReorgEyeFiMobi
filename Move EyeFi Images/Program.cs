using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Move_EyeFi_Images
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
                Console.Error.WriteLine("Please pass a folder as an argument");
            else {
                string topFolder = args[0];
                DirectoryInfo d = new DirectoryInfo(topFolder);
                foreach (var dir in d.GetDirectories("*.*"))
                {
                    // Is this in the EyeFi yyyy-mm-dd format?
                    if (Regex.IsMatch(dir.Name, @"^\d\d\d\d-\d\d-\d\d$"))
                    {
                        string newFolder = dir.FullName.Substring(0, dir.FullName.Length - 3);
                        Console.Error.WriteLine("Moving EyeFi folder at: " + dir.Name + " to " + newFolder);
                        new Microsoft.VisualBasic.Devices.Computer().FileSystem.CopyDirectory(dir.FullName, newFolder, true);
                        dir.Delete(true);
                    }
                }
            }
            //Console.ReadKey();
        }
    }
}
