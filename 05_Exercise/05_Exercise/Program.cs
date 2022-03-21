using System;
using System.IO;

namespace _05_Exercise
{
    class Program
    {
        //List information of all drives
        static void info()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                Console.WriteLine($"Drive {drive.Name}");
                Console.WriteLine($"Drive type: {drive.DriveType}");
                if (drive.IsReady == true)
                {
                    Console.WriteLine($"Volume label: {drive.VolumeLabel}");
                    Console.WriteLine($"File system: {drive.DriveFormat}");
                    Console.WriteLine($"Available space to current user:{drive.AvailableFreeSpace,15} bytes");
                    Console.WriteLine($"Total available space:          {drive.TotalFreeSpace,15} bytes");
                    Console.WriteLine($"Total size of drive:            {drive.TotalSize,15} bytes ");
                }
            }
        }

        //List all file in your My Documents

        static void ListMyDocuments()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //get path my documents
             string[] files = Directory.GetFiles(path);//get all files
             foreach(string file in files)
             {
                 Console.WriteLine(file);
             }
        }

        //Read a text file in My Documents folder and print to the console.
        static void ReadAndPrint()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string pathfile = path + @"\text.txt";
            string text = File.ReadAllText(pathfile);
            System.Console.WriteLine($"Contents of file:\n {text}");
        }
        static void Main(string[] args)
        {
            info();
            ListMyDocuments();
            ReadAndPrint();
        }
    }
}
