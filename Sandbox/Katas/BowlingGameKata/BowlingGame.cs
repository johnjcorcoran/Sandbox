using System.Collections.Generic;
 
namespace Katas.BowlingGameKata
{
    public class BowlingGame
    {
        private readonly List<int> _rolls = new List<int>();
 
        public void Roll(int pins) {
            _rolls.Add(pins);
        }
 
        public int Score()
        {
            int score = 0;
            int rollIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex)) {
                    score += 10 + StrikeBonus(rollIndex);
                    rollIndex++;
                }
                else if (IsSpare(rollIndex)) {
                    score += 10 + SpareBonus(rollIndex);
                    rollIndex += 2;
                }
                else {
                    score += NoMarkFrameScore(rollIndex);
                    rollIndex += 2;
                }
            }
            return score;
        }
 
        private bool IsStrike(int frameIndex) {
            return _rolls[frameIndex] == 10;
        }
 
        private bool IsSpare(int frameIndex) {
            return _rolls[frameIndex] + _rolls[frameIndex + 1] == 10;
        }
 
        private int StrikeBonus(int frameIndex) {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }
 
        private int SpareBonus(int frameIndex) {
            return _rolls[frameIndex + 2];
        }
 
        private int NoMarkFrameScore(int frameIndex) {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }
    }
}