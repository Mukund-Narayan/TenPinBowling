using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    public class Frame
    {
        private const int PERFECT_SCORE = 10;
        public List<Roll> Rolls { get; set; }

        public int FrameScore { get { return CalculateFrameScore(); } }

        public int FirstRollScoreOfFrame { get { return FirstRollScore(); } }


        public bool IsStrike()
        {
            if(Rolls.Any() && Rolls.Count() == 1)
            {
                var pins = Rolls.FirstOrDefault().Pins;

                return pins == PERFECT_SCORE;
            }

            return false;
        }

        public bool IsSpare()
        {
            if (Rolls.Any() && Rolls.Count() > 1)
            {
                var pins = Rolls.Sum(r => r.Pins);

                return pins == PERFECT_SCORE;
            }

            return false;
        }

        private int CalculateFrameScore()
        {
            if(Rolls.Any())
            {
                return Rolls.Sum(r => r.Pins);
            }

            return 0;
        }

        private int FirstRollScore()
        {
            if (Rolls.Any())
            {
                return Rolls.FirstOrDefault().Pins;
            }

            return 0;
        }
    }
}
