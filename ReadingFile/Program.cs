using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ReadingFile
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //string masiv s imenata na failove s podrazdelenie html
            string juniorDevOpsFolder = "JuniorDevOps";
            string targetPath = Directory.GetCurrentDirectory();
            int endIndex = targetPath.IndexOf(juniorDevOpsFolder);
            var juniorDevOpsPath = targetPath.Substring(0, endIndex + juniorDevOpsFolder.Length);
            string directory = "Files";
            string targetDirectory = Path.Combine(juniorDevOpsPath, directory);
            //  Console.WriteLine(targetDirectory);
            ProcessDirectory(targetDirectory);
            stopwatch.Stop();

            // Write hours, minutes and seconds.
            Console.WriteLine("Time elapsed: {0}", stopwatch.ElapsedMilliseconds + "ms");
        }
        public static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                    ProcessFile(fileName);
        }

        public static void ProcessFile(string path)
        {
            string folder = Path.GetDirectoryName(path);
            string file = Path.GetFileName(path);

            // Keep the first 6 characters from the source file and include hrefcount
            string newFile = file.Substring(0, 6) + " hrefcount.txt";
            string newPath = Path.Combine(folder, newFile); 

            //Retrieve counter with IEnumerable and LinQ
            int counter = File.ReadLines(path).Count(x => x.Contains("href="));
   
            File.WriteAllText(newPath, $"The number of times href appears is {counter}");
            File.Delete(newPath);            
        }
    }
}

