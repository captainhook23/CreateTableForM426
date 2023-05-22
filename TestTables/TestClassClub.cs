using TestClassOutput;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassClub
{
    [TestFixture]
    public class TestClassClub
    {
        Club c;

        [SetUp] 
        public void SetUp() 
        {
           c = new Club("Hertha BSC");
        }
        [Test]
        public void TestClubName()
        {
            //Arrange
            SetUp();
            //Act
            string result = c.Name;
            //Assert
            Assert.AreEqual(result, "Hertha BSC");
        }
        [Test]
        public void TestClubWins()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.Wins;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubTies()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.Ties;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubLoss()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.Loss;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubGoalsPositive()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.GoalsPositive;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubGoalsNegative()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.GoalsNegative;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubGoalsDiffernce()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.GoalsDifference;
            //Assert
            Assert.AreEqual(result, 0);
        }
        [Test]
        public void TestClubPoints()
        {
            //Arrange
            SetUp();
            //Act
            int result = c.Points;
            //Assert
            Assert.AreEqual(result, 0);
        }
    }
}
