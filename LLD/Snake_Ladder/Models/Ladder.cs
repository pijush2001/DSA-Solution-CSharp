using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Ladder
    {
        public Position Start { get; }
        public Position End { get; }

        public Ladder(Position start, Position end)
        {
            if (start.Value >= end.Value)
                throw new ArgumentException("Start must be less than end for a ladder.");
            Start = start;
            End = end;
        }
    }
}
