using System;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Change file name - start 1 to n");
            
            // Get path
            Console.Write("Enter path: ");
            string path = Console.ReadLine();

            // Get type files
            Console.Write("Enter type files: ");
            string typeFiles = Console.ReadLine();


            // Create the object which get information about dircetory
            DirectoryInfo di;
            try
            {
                di = new DirectoryInfo(path);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("You cannot input empty path value.");
                return;
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine("Entered path is not correct or not exist");
                return;
            }

            // Create object which get list all files whos have specified type.
            FileInfo[] files;

            // Check the path is exist
            if (!di.Exists)
            {
                Console.WriteLine("The file path is not exist.");
                return;
            }

            // Try get array
            try
            {
                files = di.GetFiles("*." + typeFiles);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }

            // The file number
            int n = 1;

            // Change file name 
            foreach(FileInfo file in files)
            {
                file.MoveTo(path + @"\" + n + "." + typeFiles, true);
                n++;
            }

            Console.WriteLine("The " + files.Length + " file(s) changed name.");
        }
    }
}
