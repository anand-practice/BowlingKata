using NUnit.Framework;

namespace BowlingKata.Tests
{
    public class BowlingTest
    {
        Game _game;
        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
                _game.Roll(pins);
        }

        [Test]
        public void gutter_game()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score());
        }

        [Test]
        public void all_ones_game()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void one_spare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _game.Score());
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        [Test]
        public void roll_strike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [Test]
        public void perfect_game()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _game.Score());
        }



    }
}