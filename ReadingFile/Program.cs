using System;
using System.IO;

namespace ReadingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //string masiv s imenata na failove s podrazdelenie html
            string juniorDevOpsFolder = "JuniorDevOps";
            string targetPath = Directory.GetCurrentDirectory();
            int endIndex = targetPath.IndexOf(juniorDevOpsFolder);
            var juniorDevOpsPath = targetPath.Substring(0, endIndex + juniorDevOpsFolder.Length);
            string directory = "Files";
            string targetDirectory = Path.Combine(juniorDevOpsPath, directory);
            //  Console.WriteLine(targetDirectory);
            ProcessDirectory(targetDirectory);
           
        }
            public static void ProcessDirectory(string targetDirectory)
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory);
                foreach (string fileName in fileEntries)
                    ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                //string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                //foreach (string subdirectory in subdirectoryEntries)
                //    ProcessDirectory(subdirectory);
            }
            public static void ProcessFile(string path)
            {
            int counter = 0;
                foreach (var line in File.ReadAllLines(path))
                {
                    if (line.Contains("href="))
                {
                    counter++;
                }
                }
                Console.WriteLine("Processed file '{0}'.", path);
                Console.WriteLine("In this file the number of appearance of href is '{0}'.", counter);
            Console.WriteLine();
            
        }
    }
    }
