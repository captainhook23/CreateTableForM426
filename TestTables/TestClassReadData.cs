using NUnit;
using CreateTableForM426;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.RegularExpressions;
using static CreateTableForM426.ReadData;

namespace TestTables
{
    [TestFixture]
    internal class TestClassReadData
    {
        private ReadData r;
        private MatchTeams m { get; set; }

        [SetUp]
        public void SetUp()
        {
             r = new ReadData("RawData/bundesliga.txt");
             m = new MatchTeams();
        }

        [Test]
        public void TestReadData()
        {
            //Arrange
            SetUp();
            //
            
            string result = m.ClubLeftSide;
            //Assert
            Assert.AreEqual(result,"blub");
        }
    }
}
