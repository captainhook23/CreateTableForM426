using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestClassOutput
{
    public class ReadData
    {
        public MatchTeams Match { get; set; }
        public Club Club { get; set; }
        public List<Club> Clubs { get; set; }
        private List<Club> ClubsByPoints { get; set; }

        private int index = 1;

        public ReadData()
        {
            Clubs = new List<Club>();
        }

        public void SetData(string[] lines, string fileName)
        {
            GetResultsAndNames(lines);
            ClubsByPoints = new List<Club>();
            ClubsByPoints = Clubs.OrderByDescending(club => club.Points).ThenByDescending(club => club.GoalsDifference).ToList();
            OutputData(fileName);
        }

        private void OutputData(string fileName)
        {
            Output output = new Output();
            string data = "";
            data += output.OutputTableDesign();

            foreach (Club c in ClubsByPoints)
            {
                data += output.OutputTable(c, index);
                index++;
            }

            data += output.OutputUnderscore();
            Console.Write(data);
            string newFile = "Tables/" + fileName;
            File.WriteAllText(newFile, data);
            Console.WriteLine("\n");
        }

        public void GetResultsAndNames(string[] lines)
        {
            foreach (string line in lines)
            {
                string[] s = line.Split(':');

                Match = new MatchTeams();

                AddClubNameLeftSideToList(s[0]);
                ResultClubLeftSide(s[0]);

                AddClubNameRightSideToList(s[1]);
                ResultClubRightSide(s[1]);

                AddStats();
            }
            GetGoalDifference();
        }

        public void GetGoalDifference()
        {
            foreach (Club club in Clubs)
            {
                club.CalculateGoalDifference();
            }
        }

        public void ResultClubLeftSide(string s)
        {
            Match.ClubLeftSideResult = s.Last();
        }

        public void ResultClubRightSide(string s)
        {
            Match.ClubRightSideResult = s.First();
        }

        public void AddClubNameLeftSideToList(string s)
        {
            Match.ClubLeftSide = s.Remove(s.Length - 2, 2);
            Club = new Club(Match.ClubLeftSide);

            if (!Clubs.Any(b => b.Name == Match.ClubLeftSide))
            {
                Clubs.Add(Club);
            }
        }

        public void AddClubNameRightSideToList(string s)
        {
            Match.ClubRightSide = s.Remove(0, 2);
            Club = new Club(Match.ClubRightSide);

            if (!Clubs.Any(b => b.Name == Match.ClubRightSide))
            {
                Clubs.Add(Club);
            }
        }

        public void AddStats()
        {
            if (Match.ClubLeftSideResult > Match.ClubRightSideResult)
            {
                Clubs.Find(c => c.Name == Match.ClubLeftSide).AddWin(
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult),
                    (int)Char.GetNumericValue(Match.ClubRightSideResult)
                );
                Clubs.Find(c => c.Name == Match.ClubRightSide).AddLoss(
                    (int)Char.GetNumericValue(Match.ClubRightSideResult),
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult)
                );
            }
            else if (Match.ClubLeftSideResult < Match.ClubRightSideResult)
            {
                Clubs.Find(c => c.Name == Match.ClubRightSide).AddWin(
                    (int)Char.GetNumericValue(Match.ClubRightSideResult),
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult)
                );
                Clubs.Find(c => c.Name == Match.ClubLeftSide).AddLoss(
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult),
                    (int)Char.GetNumericValue(Match.ClubRightSideResult)
                );
            }
            else if (Match.ClubLeftSideResult == Match.ClubRightSideResult)
            {
                Clubs.Find(c => c.Name == Match.ClubRightSide).AddTie(
                    (int)Char.GetNumericValue(Match.ClubRightSideResult),
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult)
                );
                Clubs.Find(c => c.Name == Match.ClubLeftSide).AddTie(
                    (int)Char.GetNumericValue(Match.ClubLeftSideResult),
                    (int)Char.GetNumericValue(Match.ClubRightSideResult)
                );
            }
        }

        public class MatchTeams
        {
            public string ClubLeftSide { get; set; }
            public char ClubLeftSideResult { get; set; }
            public string ClubRightSide { get; set; }
            public char ClubRightSideResult { get; set; }
        }
    }
}
