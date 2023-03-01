using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CreateTableForM426
{
    public class ReadData
    {
        private MatchTeams match { get; set; }
        private Club club { get; set; }
        private List<Club> Clubs { get; set; }
        private List<Club> ClubsByPoints { get; set; }
        private Output output { get; set; }
        private int index = 1;
        private string FileName { get; set; }

        public ReadData(string path)
        {
            ReadScoreFiles(path);
        }
        private void ReadScoreFiles(string path)
        {
            FileName = Path.GetFileName(path);
            Clubs = new List<Club>();
            GetResultsAndNames(path);
            ClubsByPoints = new List<Club>();
            ClubsByPoints = Clubs.OrderByDescending(club => club.Points).ThenByDescending(club => club.GoalsDifference).ToList();
            Output();
        }
        private void GetResultsAndNames(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] s = line.Split(':');

                match = new MatchTeams();

                AddClubNameLeftSideToList(s[0]);
                ResultClubLeftSide(s[0]);

                AddClubNameRightSideToList(s[1]);
                ResultClubRightSide(s[1]);

                AddStats();
            }
            GetGoalDifference();
        }
        private void Output()
        {
            output = new Output(FileName);
            foreach (Club c in ClubsByPoints)
            {
                output = new Output(c, index, FileName);
                index++;
            }
            output.OutputUnderscore();
            Console.WriteLine("\n");
        }
        private void GetGoalDifference()
        {
            foreach (Club club in Clubs)
            {
                club.GoalsDifference = club.GoalsPositive - club.GoalsNegative;
            }
        }
        private void ResultClubLeftSide(string s)
        {
            match.ClubLeftSideResult = s.Last();

        }
        private void ResultClubRightSide(string s)
        {
            match.ClubRightSideResult = s.First();
        }
        private void AddClubNameLeftSideToList(string s)
        {
            match.ClubLeftSide = s.Remove(s.Length - 2, 2);
            club = new Club(match.ClubLeftSide);

            if (!Clubs.Any(b => b.Name == match.ClubLeftSide))
            {
                Clubs.Add(club);
            }
        }
        private void AddClubNameRightSideToList(string s)
        {
            match.ClubRightSide = s.Remove(0, 2);
            club = new Club(match.ClubRightSide);

            if (!Clubs.Any(b => b.Name == match.ClubRightSide))
            {
                Clubs.Add(club);
            }
        }
        private void AddStats()
        {
            if (match.ClubLeftSideResult > match.ClubRightSideResult)
            {
                AddLeftSideWins();
            }
            else if (match.ClubLeftSideResult < match.ClubRightSideResult)
            {
                AddRightSideWins();
            }
            else if (match.ClubLeftSideResult == match.ClubRightSideResult)
            {
                AddTies();
            }
        }
        private void AddLeftSideWins()
        {
            Clubs.Find(b => b.Name == match.ClubLeftSide).Wins += 1;
            Clubs.Find(b => b.Name == match.ClubLeftSide).Points += 3;
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubLeftSideResult);
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubRightSideResult);

            Clubs.Find(b => b.Name == match.ClubRightSide).Loss += 1;
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubRightSideResult);
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubLeftSideResult);
        }
        private void AddRightSideWins()
        {
            Clubs.Find(b => b.Name == match.ClubRightSide).Wins += 1;
            Clubs.Find(b => b.Name == match.ClubRightSide).Points += 3;
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubRightSideResult);
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubLeftSideResult);

            Clubs.Find(b => b.Name == match.ClubLeftSide).Loss += 1;
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubLeftSideResult);
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubRightSideResult);
        }
        private void AddTies()
        {
            Clubs.Find(b => b.Name == match.ClubRightSide).Ties += 1;
            Clubs.Find(b => b.Name == match.ClubRightSide).Points += 1;
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubRightSideResult);
            Clubs.Find(b => b.Name == match.ClubRightSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubLeftSideResult);

            Clubs.Find(b => b.Name == match.ClubLeftSide).Ties += 1;
            Clubs.Find(b => b.Name == match.ClubLeftSide).Points += 1;
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsPositive += (int)Char.GetNumericValue(match.ClubLeftSideResult);
            Clubs.Find(b => b.Name == match.ClubLeftSide).GoalsNegative += (int)Char.GetNumericValue(match.ClubRightSideResult);
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
