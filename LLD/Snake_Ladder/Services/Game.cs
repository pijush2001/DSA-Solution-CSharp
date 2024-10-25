using Snake_Ladder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Ladder.Services
{
    public class Game
    {
        private readonly Board board;
        private readonly Dice dice;
        private readonly List<Player> players;
        private int currentPlayerIndex;

        public Game(Board board, Dice dice)
        {
            this.board = board;
            this.dice = dice;
            players = new List<Player>();
            currentPlayerIndex = 0;
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void PlayTurn()
        {
            Player currentPlayer = players[currentPlayerIndex];

            Console.WriteLine($"{currentPlayer.Name}, press Enter to roll the dice.");
            Console.ReadLine();

            int diceRoll = dice.Roll();

            Console.WriteLine($"{currentPlayer.Name} rolled a {diceRoll}");

            int newPositionValue = currentPlayer.Position.Value + diceRoll;
            if (newPositionValue > board.Size)
            {
                Console.WriteLine($"{currentPlayer.Name} rolled too high and stays at position {currentPlayer.Position.Value}");
            }
            else
            {
                Position newPosition = new Position(newPositionValue);
                newPosition = board.GetNewPosition(newPosition);
                currentPlayer.Position = newPosition;
                Console.WriteLine($"{currentPlayer.Name} moved to position {currentPlayer.Position.Value}");

                if (newPosition.Value == board.Size)
                {
                    Console.WriteLine($"{currentPlayer.Name} wins!");
                    Environment.Exit(0);
                }
            }

            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        }

        public void StartGame()
        {
            while (true)
            { 
                PlayTurn();
            }
        }
    }

}
