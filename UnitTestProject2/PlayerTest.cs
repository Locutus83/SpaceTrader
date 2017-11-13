using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceTraderWPF;

namespace UnitTestProject2
{
    [TestClass]
    public class PlayerTest
    {
        Player _testPlayer;

        [TestInitialize]
        public void SetupForTests()
        {
            _testPlayer = new Player("Player Name");
        }

        [TestMethod]
        public void TestPlayerName()
        {
            Assert.AreEqual("Player Name", _testPlayer.Name);

            _testPlayer.Name = "New Name";
            Assert.AreEqual("New Name", _testPlayer.Name);
        }
    }
}
