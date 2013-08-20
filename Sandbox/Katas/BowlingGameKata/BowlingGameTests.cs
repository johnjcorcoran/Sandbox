using NUnit.Framework;
 
namespace Katas.BowlingGameKata
{
    [TestFixture]
    public class BowlingGameTests
    {
        private BowlingGame _game;
 
        [SetUp]
        public void SetUp() {
            _game = new BowlingGame();
        }
 
        [Test]
        public void RollingAllZeroesScoresZero() {
            RollMany(0, 20);
            Assert.That(_game.Score(), Is.EqualTo(0));
        }
 
        [Test]
        public void RollingAllOnesScoresTwenty() {
            RollMany(1, 20);
            Assert.That(_game.Score(), Is.EqualTo(20));
        }
 
        [Test]
        public void RollingOneSpareDoublesValueOfSubsequentRoll() {
            RollSpare();
            _game.Roll(4);
            RollMany(0, 17);
            Assert.That(_game.Score(), Is.EqualTo(18));
        }
 
        [Test]
        public void RollingOneStrikeDoublesValueOfTwoSubsequentRolls() {
            RollStrike();
            _game.Roll(3);
            _game.Roll(2);
            RollMany(0, 16);
            Assert.That(_game.Score(), Is.EqualTo(20));
        }
 
        [Test]
        public void RollingAllStrikesScores300() {
            RollMany(10, 12);
            Assert.That(_game.Score(), Is.EqualTo(300));
        }
 
        private void RollStrike() {
            _game.Roll(10);
        }
 
        private void RollSpare() {
            _game.Roll(5);
            _game.Roll(5);
        }
 
        private void RollMany(int pinsPerRoll, int numberOfRolls) {
            for (int i = 0; i < numberOfRolls; i++)
                _game.Roll(pinsPerRoll);
        }
    }
}
