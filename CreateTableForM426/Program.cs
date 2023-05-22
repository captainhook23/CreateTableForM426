using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestClassOutput
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Cmd cmd = new Cmd();
            cmd.Main();
            Console.ReadLine();
        }
    }
}
