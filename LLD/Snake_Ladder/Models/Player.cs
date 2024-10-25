using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Player
    {
        public string Name { get; }
        public Position Position { get; set; }

        public Player(string name)
        {
            Name = name;
            Position = new Position(0);
        }
    }
}
