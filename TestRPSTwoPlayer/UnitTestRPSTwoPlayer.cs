using NUnit.Framework;
using RockPaperScissorsTwoPlayer;

namespace TestRockPaperScissors
{
    public class UnitTests
    {
        private TestConsoleWrapper _testConsoleWrapper;
        [SetUp]
        public void Setup()
        {
            _testConsoleWrapper = new TestConsoleWrapper();
        }

        [Test]
        public void TestHumanPlayer()
        {
            _testConsoleWrapper.PlayerNames = new string[] { "A", "B" };
            _testConsoleWrapper.PlayerChoices = new string[] { "1", "2", "3" };
            _testConsoleWrapper.PlayerCount = 2;
            int input_playerFlag = 0; int expected_playerFlag = 1;
            
            var humanPlayer = new HumanPlayer(_testConsoleWrapper);
            
            humanPlayer.Play(ref input_playerFlag);
            
            Assert.Pass();
            Assert.AreEqual(input_playerFlag, expected_playerFlag, "Equal");
        }

        [Test]
        public void TestComputerPlayer()
        {
            _testConsoleWrapper.PlayerNames = new string[] { "Krans" };
            _testConsoleWrapper.PlayerChoices = new string[] { "1", "2", "3" };            
            int input_playerFlag = 0; int expected_playerFlag = 1;
            
            var computerPlayer = new ComputerPlayer(_testConsoleWrapper);
            
            computerPlayer.Play(ref input_playerFlag);
            
            Assert.Pass();
            Assert.AreEqual(input_playerFlag, expected_playerFlag, "Equal");
        }

        [Test]
        public void TestWinningChoice()
        {
            Assert.AreEqual(Constants.Choice.Paper, Constants.GetWinningChoice(Constants.Choice.Rock, Constants.Choice.Paper), "Equal");
            Assert.AreEqual(Constants.Choice.Scissors, Constants.GetWinningChoice(Constants.Choice.Scissors, Constants.Choice.Paper), "Equal");
            Assert.AreEqual(Constants.Choice.Rock, Constants.GetWinningChoice(Constants.Choice.Rock, Constants.Choice.Scissors), "Equal");
            Assert.AreNotEqual(Constants.Choice.Rock, Constants.GetWinningChoice(Constants.Choice.Rock, Constants.Choice.Paper), "Not Equal");
            Assert.AreNotEqual(Constants.Choice.Paper, Constants.GetWinningChoice(Constants.Choice.Scissors, Constants.Choice.Paper), "Not Equal");
            Assert.AreNotEqual(Constants.Choice.Scissors, Constants.GetWinningChoice(Constants.Choice.Rock, Constants.Choice.Scissors), "Not Equal");
        }
    }
}