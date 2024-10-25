using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Position
    {
        public int Value { get; }

        public Position(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Position must be between 0 and 100.");
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is Position other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

}
