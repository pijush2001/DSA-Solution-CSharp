using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Models
{
    public class Board
    {
        public int Size { get; }
        private readonly Dictionary<int, Snake> snakes; //key is position of head of the snake
        private readonly Dictionary<int, Ladder> ladders; //key is starting position of the ladder
        /*private readonly List<Snake> snakes;
        private readonly List<Ladder> ladders;
*/
        public Board(int size)
        {
            Size = size;
            snakes = new Dictionary<int, Snake>();
            ladders = new Dictionary<int, Ladder>();
        }

        public void AddSnake(Snake snake)
        {
            if (snake.Head.Value <= snake.Tail.Value)
                throw new ArgumentException("Head of the snake must be greater than the tail.");
            snakes[snake.Head.Value] = snake;
        }

        public void AddLadder(Ladder ladder)
        {
            if (ladder.Start.Value >= ladder.End.Value)
                throw new ArgumentException("Start of the ladder must be less than the end.");
            ladders[ladder.Start.Value] = ladder;
        }

        public Position GetNewPosition(Position position)
        {
            if (snakes.ContainsKey(position.Value))
                return snakes[position.Value].Tail; //return Tail of the snake when it touch the head
            if (ladders.ContainsKey(position.Value))
                return ladders[position.Value].End; //return End of ladder when touch Start
            return position;
        }
    }

}
