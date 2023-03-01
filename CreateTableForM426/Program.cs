using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTableForM426
{
    internal class Program
    {
        private static readonly string strDir = "RawData/";
        static void Main(string[] args)
         {
            foreach (String stringFilePath in Directory.GetFiles(strDir))
            {            
                _ = new ReadData(stringFilePath);
            }
            Console.ReadLine();
        }
    }
}
