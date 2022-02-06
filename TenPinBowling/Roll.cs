using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenPinBowling
{
    public class Roll
    {
        
        private readonly int _pins;
        public int Pins { get { return _pins; } }

        public Roll(int pins)
        {
            _pins = pins;
        }

        
    }
}
