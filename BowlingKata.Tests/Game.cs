using System;

namespace BowlingKata.Tests
{
    public class Game
    {
        private int currentRole = 0;
        private int[] roll = new int[21];

        public void Roll(int pins)
        {
            roll[currentRole++] += pins;
        }

        public int Score()
        {
            int score = 0;
            int firstInFrame = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(firstInFrame))
                {
                    score += NextTwoBallsForStrike(firstInFrame);
                    firstInFrame++;
                }
                else if (IsSpare(firstInFrame))
                {
                    score += 10 + NextBallForSpare(firstInFrame);
                    firstInFrame += 2;
                }
                else
                {
                    score += TwoBallsInFrame(firstInFrame);
                    firstInFrame += 2;
                }
            }
            return score;
        }

        private int TwoBallsInFrame(int firstInFrame)
        {
            return roll[firstInFrame] + roll[firstInFrame + 1];
        }

        private int NextBallForSpare(int firstInFrame)
        {
            return roll[firstInFrame + 2];
        }

        private int NextTwoBallsForStrike(int firstInFrame)
        {
            return 10 + roll[firstInFrame + 1] + roll[firstInFrame + 2];
        }

        private bool IsStrike(int firstInFrame)
        {
            return roll[firstInFrame] == 10;
        }

        private bool IsSpare(int i)
        {
            return (roll[i] + roll[i + 1]) == 10;
        }
    }
}