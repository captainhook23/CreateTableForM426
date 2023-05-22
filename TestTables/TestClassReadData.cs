using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestClassOutput;

namespace TestClassReadData
{
    [TestFixture]
    public class TestClassReadData
    {
        [Test]
        public void AddClubNameLeftSideToList_AddsClubToList()
        {
            // Arrange
            string[] lines = { "TeamA 1:0 TeamB", "TeamC 2:1 TeamA" };
            ReadData readData = new ReadData();
            string clubName = "TeamA";

            // Act
            readData.GetResultsAndNames(lines);
            readData.AddClubNameLeftSideToList(clubName);

            // Assert
            Assert.IsTrue(readData.Clubs.Any(c => c.Name == clubName));
        }

        [Test]
        public void AddClubNameRightSideToList_AddsClubToList()
        {
            // Arrange
            string[] lines = { "TeamA 1:0 TeamB", "TeamC 2:1 TeamA" };
            ReadData readData = new ReadData();
            string clubName = "TeamB";

            // Act
            readData.GetResultsAndNames(lines);
            readData.AddClubNameRightSideToList(clubName);

            // Assert
            Assert.IsTrue(readData.Clubs.Any(c => c.Name == clubName));
        }


        [Test]
        public void ResultClubLeftSide_SetsClubLeftSideResult()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Match = new ReadData.MatchTeams();
            string resultString = "ClubA 5";

            // Act
            readData.ResultClubLeftSide(resultString);

            // Assert
            Assert.AreEqual('5', readData.Match.ClubLeftSideResult);
        }

        [Test]
        public void ResultClubRightSide_SetsClubRightSideResult()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Match = new ReadData.MatchTeams();
            string resultString = "3 ClubA";

            // Act
            readData.ResultClubRightSide(resultString);

            // Assert
            Assert.AreEqual('3', readData.Match.ClubRightSideResult);
        }


        [Test]
        public void AddStats_IncrementsWinsAndLosses_WhenLeftSideClubWins()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Clubs = new List<Club>();
            string clubLeftSide = "Club A";
            string clubRightSide = "Club B";
            readData.Clubs.Add(new Club(clubLeftSide));
            readData.Clubs.Add(new Club(clubRightSide));
            readData.Match = new ReadData.MatchTeams
            {
                ClubLeftSide = clubLeftSide,
                ClubRightSide = clubRightSide,
                ClubLeftSideResult = '2',
                ClubRightSideResult = '1'
            };

            // Act
            readData.AddStats();

            // Assert
            Club leftSideClub = readData.Clubs.Find(c => c.Name == clubLeftSide);
            Club rightSideClub = readData.Clubs.Find(c => c.Name == clubRightSide);

            Assert.AreEqual(1, leftSideClub.Wins);
            Assert.AreEqual(0, leftSideClub.Loss);
            Assert.AreEqual(0, leftSideClub.Ties);

            Assert.AreEqual(0, rightSideClub.Wins);
            Assert.AreEqual(1, rightSideClub.Loss);
            Assert.AreEqual(0, rightSideClub.Ties);
        }

        [Test]
        public void AddStats_IncrementsWinsAndLosses_WhenRightSideClubWins()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Clubs = new List<Club>();
            string clubLeftSide = "Club A";
            string clubRightSide = "Club B";
            readData.Clubs.Add(new Club(clubLeftSide));
            readData.Clubs.Add(new Club(clubRightSide));
            readData.Match = new ReadData.MatchTeams
            {
                ClubLeftSide = clubLeftSide,
                ClubRightSide = clubRightSide,
                ClubLeftSideResult = '1',
                ClubRightSideResult = '2'
            };

            // Act
            readData.AddStats();

            // Assert
            Club leftSideClub = readData.Clubs.Find(c => c.Name == clubLeftSide);
            Club rightSideClub = readData.Clubs.Find(c => c.Name == clubRightSide);

            Assert.AreEqual(0, leftSideClub.Wins);
            Assert.AreEqual(1, leftSideClub.Loss);
            Assert.AreEqual(0, leftSideClub.Ties);

            Assert.AreEqual(1, rightSideClub.Wins);
            Assert.AreEqual(0, rightSideClub.Loss);
            Assert.AreEqual(0, rightSideClub.Ties);
        }

        [Test]
        public void AddStats_IncrementsTies_WhenMatchIsTie()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Clubs = new List<Club>();
            string clubLeftSide = "Club A";
            string clubRightSide = "Club B";
            readData.Clubs.Add(new Club(clubLeftSide));
            readData.Clubs.Add(new Club(clubRightSide));
            readData.Match = new ReadData.MatchTeams
            {
                ClubLeftSide = clubLeftSide,
                ClubRightSide = clubRightSide,
                ClubLeftSideResult = '1',
                ClubRightSideResult = '1'
            };

            // Act
            readData.AddStats();

            // Assert
            Club leftSideClub = readData.Clubs.Find(c => c.Name == clubLeftSide);
            Club rightSideClub = readData.Clubs.Find(c => c.Name == clubRightSide);

            Assert.AreEqual(0, leftSideClub.Wins);
            Assert.AreEqual(0, leftSideClub.Loss);
            Assert.AreEqual(1, leftSideClub.Ties);

            Assert.AreEqual(0, rightSideClub.Wins);
            Assert.AreEqual(0, rightSideClub.Loss);
            Assert.AreEqual(1, rightSideClub.Ties);
        }

        [Test]
        public void GetGoalDifference_CalculatesGoalDifferenceForEachClub()
        {
            // Arrange
            ReadData readData = new ReadData();
            readData.Clubs = new List<Club>();
            string clubA = "Club A";
            string clubB = "Club B";
            readData.Clubs.Add(new Club(clubA));
            readData.Clubs.Add(new Club(clubB));
            readData.Clubs[0].AddWin(3, 1);
            readData.Clubs[1].AddLoss(1, 3);

            // Act
            readData.GetGoalDifference();

            // Assert
            Assert.AreEqual(2, readData.Clubs[0].GoalsDifference);
            Assert.AreEqual(-2, readData.Clubs[1].GoalsDifference);
        }
    }
}
