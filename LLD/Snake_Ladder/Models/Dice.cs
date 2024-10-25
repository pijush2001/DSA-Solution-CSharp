using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Dice
    {
        private static readonly Random Random = new Random();

        public int Roll()
        {
            return Random.Next(1, 7);
        }
    }
}
