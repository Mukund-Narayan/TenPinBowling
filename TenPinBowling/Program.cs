using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BowlingGame();

            game.Start();

            Console.WriteLine("Final Score ---- " +game.CalculateScore());

            Console.ReadLine();
        }
    }
}
