using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Snake
    {
        public Position Head { get; }
        public Position Tail { get; }

        public Snake(Position head, Position tail)
        {
            if (head.Value <= tail.Value)
                throw new ArgumentException("Head must be greater than tail for a snake.");
            Head = head;
            Tail = tail;
        }
    }
}
