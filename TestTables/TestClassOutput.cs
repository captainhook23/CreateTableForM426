using NUnit.Framework;

namespace TestClassOutput
{
    [TestFixture]
    public class TestClassOutput
    {
        private Output output;

        [SetUp]
        public void SetUp()
        {
            output = new Output();
        }

        [Test]
        public void OutputTable_ShouldReturnCorrectOutput()
        {
            var club = new Club("Club A");
            club.AddWin(3, 1);
            club.CalculateGoalDifference();

            string expectedOutput = "1.                           Club A           1         0         0         3         1         2         3\n";
            string actualOutput = output.OutputTable(club, 1);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputIndex_ShouldReturnCorrectOutput()
        {
            int index = 10;
            string expectedOutput = "10.       ";

            string actualOutput = output.OutputIndex(index);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputClubName_ShouldReturnCorrectOutput()
        {
            var club = new Club("Club A");
            string expectedOutput = "                   Club A  ";

            string actualOutput = output.OutputClubName(club);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputStats_AddWin_ShouldReturnCorrectOutput()
        {
            var club = new Club("Club A");
            club.AddWin(3, 1);
            club.CalculateGoalDifference();

            string expectedOutput = "         1         0         0         3         1         2         3\n";
            string actualOutput = output.OutputStats(club);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputStats_AddLoss_ShouldReturnCorrectOutput()
        {
            var club = new Club("Club A");
            club.AddLoss(1, 3);
            club.CalculateGoalDifference();

            string expectedOutput = "         0         0         1         1         3        -2         0\n";
            string actualOutput = output.OutputStats(club);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputStats_AddTie_ShouldReturnCorrectOutput()
        {
            var club = new Club("Club A");
            club.AddTie(1, 1);
            club.CalculateGoalDifference();

            string expectedOutput = "         0         1         0         1         1         0         1\n";
            string actualOutput = output.OutputStats(club);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputItemFromIntList_ShouldReturnCorrectOutput()
        {
            string input = "10";
            string expectedOutput = "        10";

            string actualOutput = output.OutputItemFromIntList(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputTableDesign_ShouldReturnCorrectOutput()
        {
            string expectedOutput = "Rank                           Team           W         T         L         +         -         =         P\n" +
                                   "-----------------------------------------------------------------------------------------------------------\n";

            string actualOutput = output.OutputTableDesign();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputRank_ShouldReturnCorrectOutput()
        {
            string expectedOutput = "Rank      ";

            string actualOutput = output.OutputRank();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputTeam_ShouldReturnCorrectOutput()
        {
            string expectedOutput = "                     Team  ";

            string actualOutput = output.OutputTeam();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputItemFromStringList_ShouldReturnCorrectOutput()
        {
            string input = "+";
            string expectedOutput = "         +";

            string actualOutput = output.OutputItemFromStringList(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void OutputUnderscore_ShouldReturnCorrectOutput()
        {
            string expectedOutput = "-----------------------------------------------------------------------------------------------------------\n";

            string actualOutput = output.OutputUnderscore();

            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
