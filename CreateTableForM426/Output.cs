using System;
using System.Collections.Generic;
using System.IO;

namespace TestClassOutput
{
    public class Output
    {
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

        public string OutputTable(Club c, int index)
        {
            string outputData = OutputIndex(index);
            outputData += OutputClubName(c);
            outputData += OutputStats(c);
            return outputData;
        }

        public string OutputIndex(int index)
        {
            string nameSpace = null;
            for (int i = index.ToString().Length; i < space - 1; i++)
            {
                nameSpace += " ";
            }
            return index + "." + nameSpace;
        }

        public string OutputClubName(Club c)
        {
            string nameSpace = null;
            for (int i = c.Name.Length; i < spaceName; i++)
            {
                nameSpace += " ";
            }
            return nameSpace + c.Name + "  ";
        }

        public string OutputStats(Club c)
        {
            List<int> Stats = new List<int>() { c.Wins, c.Ties, c.Loss, c.GoalsPositive, c.GoalsNegative, c.GoalsDifference, c.Points };
            string statsOutput = "";

            foreach (int result in Stats)
            {
                string input = result.ToString();
                statsOutput += OutputItemFromIntList(input);
            }
            return statsOutput + "\n";
        }

        public string OutputItemFromIntList(string s)
        {
            string nameSpace = null;
            for (int i = s.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            return nameSpace + s;
        }

        public string OutputTableDesign()
        {
            List<string> Header = new List<string>() { w, t, l, plus, minus, equal, p };
            string tableDesign = "";

            tableDesign += OutputRank();
            tableDesign += OutputTeam();
            foreach (string s in Header)
            {
                tableDesign += OutputItemFromStringList(s);
            }
            return tableDesign + "\n" + OutputUnderscore();
        }

        public string OutputRank()
        {
            string nameSpace = null;
            for (int i = rank.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            return rank + nameSpace;
        }

        public string OutputTeam()
        {
            string nameSpace = null;
            for (int i = team.Length; i < spaceName; i++)
            {
                nameSpace += " ";
            }
            return nameSpace + team + "  ";
        }

        public string OutputItemFromStringList(string s)
        {
            string nameSpace = null;
            for (int i = s.Length; i < space; i++)
            {
                nameSpace += " ";
            }
            return nameSpace + s;
        }

        public string OutputUnderscore()
        {
            string underscore = "";

            for (int i = 0; i < 8 * space + spaceName + 2; i++)
            {
                underscore += "-";
            }
            return underscore + "\n";
        }
    }
}