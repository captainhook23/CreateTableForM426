using TestClassOutput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassOutput
{
    public class Cmd
    {
        private static readonly string strDir = "RawData/";
        private static readonly string console = "RawData$";
        public void Main()
        {
            while (true)
            {
                Console.Write(console);
                string input = Convert.ToString(Console.ReadLine());

                if (input == "ls")
                {
                    GetFiles();
                }

                if (input == "exit")
                {
                    Environment.Exit(0);
                }

                if (input == "transform" || input == "--t")
                {
                    Console.WriteLine("Welche Datei möchten Sie umwandeln?");
                    input = Convert.ToString(Console.ReadLine());

                    if (input == "all")
                    {
                        Console.WriteLine();
                        foreach (String stringFilePath in Directory.GetFiles(strDir))
                        {
                            string FileName = Path.GetFileName(stringFilePath);
                            ReadData r = new ReadData();
                            string[] lines = File.ReadAllLines(stringFilePath);
                            r.SetData(lines,FileName);
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        string FileName = Path.GetFileName(input);
                        ReadData r = new ReadData();
                        string[] lines = File.ReadAllLines(input);
                        r.SetData(lines, FileName);
                    }
                }
            }
        }

        public static void GetFiles()
        {
            foreach (String stringFilePath in Directory.GetFiles(strDir))
            {
                Console.WriteLine(stringFilePath);
            }
        }
    }
}

