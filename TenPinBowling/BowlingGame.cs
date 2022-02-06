using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    public class BowlingGame
    {
        private Dictionary<int, Frame> _scorePerFrame;

        private const int TEN = 10;

        public BowlingGame()
        {
            _scorePerFrame = new Dictionary<int, Frame>();

            Initialize();
        }

        private void Initialize()
        {
            for (int frameIndex = 1; frameIndex <= TEN; frameIndex++)
            {
                _scorePerFrame.Add(frameIndex, new Frame { Rolls = new List<Roll>() });
            }
        }

        public void Start()
        {
            for (int frameIndex = 1; frameIndex <= TEN; frameIndex++)
            {                
                Console.WriteLine("Please enter your score for Frame {0}", frameIndex);

                Console.WriteLine("Bowl 1 :");

                Roll(frameIndex, int.Parse(Console.ReadLine()));

                if (_scorePerFrame[frameIndex].IsStrike())
                    continue;

                Console.WriteLine("Bowl 2 :");

                Roll(frameIndex, int.Parse(Console.ReadLine()));

                if(frameIndex == TEN && (_scorePerFrame[frameIndex].IsStrike() || _scorePerFrame[frameIndex].IsSpare()))
                {
                    Console.WriteLine("Bowl Extra :");
                    Roll(frameIndex, int.Parse(Console.ReadLine()));
                }
            }
        }


        public void Roll(int frameIndex, int pins)
        {
            _scorePerFrame[frameIndex].Rolls.Add(new Roll(pins));
        }

        public int CalculateScore()
        {
            var finalScore = 0;

            foreach (var frame in _scorePerFrame.Keys)
            {
                finalScore += _scorePerFrame[frame].FrameScore;

                //current frame score is strike
                if (_scorePerFrame[frame].IsStrike())
                {
                    //and next frame scroe is also strike then we need to consider 2 next bowls
                    if(_scorePerFrame[frame + 1].IsStrike())
                    {
                        finalScore += _scorePerFrame[frame + 1].FrameScore + 
                            (_scorePerFrame[frame + 2].IsStrike() ? _scorePerFrame[frame + 2].FrameScore : _scorePerFrame[frame + 2].FirstRollScoreOfFrame);
                    }  
                    else
                    {
                        finalScore += _scorePerFrame[frame + 1].FrameScore;
                    }
                }
                    
                else if (_scorePerFrame[frame].IsSpare())
                    finalScore += _scorePerFrame[frame + 1].FirstRollScoreOfFrame;              
            }

            return finalScore;
        }
    }
}
