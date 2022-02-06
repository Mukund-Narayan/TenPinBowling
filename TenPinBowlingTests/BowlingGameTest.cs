using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenPinBowling;

namespace TenPinBowlingTest
{
    [TestFixture]
    public class BowlingGameTest
    {
        private BowlingGame game;

        [SetUp]
        public void Setup()
        {
            game = new BowlingGame();
        }

        private void RollMany(int pins)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    game.Roll(i, pins);
                }
                
            }
        }



        [Test]
        public void TestBowlingGameClass()
        {
            Assert.That(game, Is.TypeOf<BowlingGame>());
        }

        [Test]
        public void TestGutterGame()
        {
            RollMany(0);
            Assert.That(0, Is.EqualTo(game.CalculateScore()));
        }

        [Test]
        public void TestAllOnes()
        {
            RollMany(1);
            Assert.That(20, Is.EqualTo(game.CalculateScore()));
        }

        [Test]
        public void TestOneSpare()
        {
            game.Roll(1, 4);
            game.Roll(1, 6);

            game.Roll(2, 4);
            game.Roll(2, 0);

            Assert.That(18, Is.EqualTo(game.CalculateScore()));
        }

        [Test]
        public void TestOneStrike()
        {
            game.Roll(1, 10);

            game.Roll(2, 4);
            game.Roll(2, 3);

            Assert.That(24, Is.EqualTo(game.CalculateScore()));
        }

        [Test]

        public void TestFullGame()
        {
            game.Roll(1, 10);//30
            game.Roll(2, 10);
            game.Roll(3, 10);
            game.Roll(4, 10);
            game.Roll(5, 10);
            game.Roll(6, 10);
            game.Roll(7, 10);
            game.Roll(8, 10);
            game.Roll(9, 10);
            game.Roll(10, 10);
            game.Roll(10, 10);

            Assert.That(290, Is.EqualTo(game.CalculateScore()));
        }

        [Test]
        public void TestRandomGameNoExtraRoll()
        {
            game.Roll(1, 1);
            game.Roll(1, 3);

            game.Roll(2, 7);
            game.Roll(2, 3);

            game.Roll(3, 10);

            game.Roll(4, 1);
            game.Roll(4, 7);

            game.Roll(5, 5);
            game.Roll(5, 2);

            game.Roll(6, 5);
            game.Roll(6, 3);

            game.Roll(7, 8);
            game.Roll(7, 2);

            game.Roll(8, 8);
            game.Roll(8, 2);

            game.Roll(9, 10);

            game.Roll(10, 9);
            game.Roll(10, 0);

            Assert.That(131, Is.EqualTo(game.CalculateScore()));

        }
    }
}
