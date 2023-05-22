using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace TestClassOutput
{
    public class Club
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Ties { get; set; }
        public int Loss { get; set; }
        public int GoalsPositive { get; set; }
        public int GoalsNegative { get; set; }
        public int GoalsDifference { get; set; }
        public int Points { get; set; }        
        public Club(string clubName)
        {
            Name = clubName;
            Wins = 0;
            Ties = 0;
            Loss = 0;
            GoalsPositive = 0;
            GoalsNegative = 0;
            GoalsDifference = 0;
            Points = 0;    
        }

        public void AddWin(int ownGoals, int opponentGoals)
        {
            Wins += 1;
            Points += 3;
            GoalsPositive += ownGoals;
            GoalsNegative += opponentGoals;
        }

        public void AddLoss(int ownGoals, int opponentGoals)
        {
            Loss += 1;
            GoalsPositive += ownGoals;
            GoalsNegative += opponentGoals;
        }

        public void AddTie(int ownGoals, int opponentGoals)
        {
            Ties += 1;
            Points += 1;
            GoalsPositive += ownGoals;
            GoalsNegative += opponentGoals;
        }

        public void CalculateGoalDifference()
        {
            GoalsDifference = GoalsPositive - GoalsNegative;
        }
    }

}
