using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace CreateTableForM426
{
    public class Output
    {
        //Changeable Const and String Variables as User wish...
        private const int space = 10;
        private const int spaceName = 25;

        private string rank = "Rank";
        private string team = "Team";
        private string w = "W";
        private string t = "T";
        private string l = "L";
        private string plus = "+";
        private string minus = "-";
        private string equal = "=";
        private string p = "P";


        private string underscore = null;
        private string newFile { get; set; }        
        public Output(Club c, int index, string fileName)
        {
            newFile = "Tables/" + fileName;
            OutputTable(c, index);
        }
        private void OutputTable(Club c, int index)
        {
            OutputIndex(index);
            OutputClubName(c);
            OutputStats(c);
        }
        private void OutputIndex(int index)
        {
            string nameSpace = null;
            for (int i = index.ToString().Length; i < space - 1; i++)
            {
                nameSpace += " ";
            }
            Console.Write(index + "." + nameSpace);
            File.AppendAllText(newFile, index + "." + nameSpace);
        }
        private void OutputClubName(Club c)
        {
            string nameSpace = null;
            for (int i = c.Name.Length; i < spaceName; i++)
            {
                nameSpace += " ";
            }
            Console.Write(nameSpace + c.Name + "  ");
            File.AppendAllText(newFile, nameSpace + c.Name + "  ");
        }
        private void OutputStats(Club c)
        {
            List<int> Stats = new List<int>() { c.Wins, c.Ties, c.Loss, c.GoalsPositive, c.GoalsNegative, c.GoalsDifference, c.Points };

            foreach (int result in Stats)
            {
                string input = result.ToString();
                OutputItemFromIntList(input);
            }
            Console.WriteLine();
            File.AppendAllText(newFile, "\n");
        }
        public void OutputItemFromIntList(string s)
        {
            string nameSpace = null;
            for (int i = s.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            Console.Write(nameSpace + s);                        
            File.AppendAllText(newFile, nameSpace+s);
        }



        public Output(string fileName)
        {
            newFile = "Tables/" + fileName;
            OutputTableDesign();
        }
        private void OutputTableDesign()
        {
            List<string> Header = new List<string>() { w, t, l, plus, minus, equal, p };
            OutputRank();
            OutputTeam();
            foreach (string s in Header)
            {
                OutputItemFromStringList(s);
            }
            Console.WriteLine();
            File.AppendAllText(newFile, "\n");
            OutputUnderscore();
        }
        private void OutputRank()
        {
            string nameSpace = null;
            for (int i = rank.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            Console.Write(rank + nameSpace);
            File.AppendAllText(newFile,rank + nameSpace);
        }
        private void OutputTeam()
        {
            string nameSpace = null;
            for (int i = team.Length; i < spaceName; i++)
            {
                nameSpace += " ";
            }
            Console.Write(nameSpace + team + "  ");
            File.AppendAllText(newFile, nameSpace + team + "  ");

        }
        private void OutputItemFromStringList(string s)
        {
            string nameSpace = null;
            for (int i = s.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            Console.Write(nameSpace + s);
            File.AppendAllText(newFile, nameSpace + s);
        }
        public void OutputUnderscore()
        {
            for (int i = 0; i < 8 * space + spaceName + 2; i++)
            {
                underscore += "-";
            }
            Console.WriteLine(underscore);
            File.AppendAllText(newFile, underscore + "\n");
        }
    }
}
