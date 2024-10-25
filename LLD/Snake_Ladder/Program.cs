using Snake_Ladder.Models;
using Snake_Ladder.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Configuring the Board!!");
        var board = new Board(100);
        var dice = new Dice();
        Console.WriteLine("Initiating the Game with board and Dice!!");
        var game = new Game(board, dice);

        // Add Snakes
        board.AddSnake(new Snake(new Position(16), new Position(6)));
        board.AddSnake(new Snake(new Position(47), new Position(26)));
        board.AddSnake(new Snake(new Position(49), new Position(11)));
        board.AddSnake(new Snake(new Position(56), new Position(53)));
        board.AddSnake(new Snake(new Position(62), new Position(19)));
        board.AddSnake(new Snake(new Position(64), new Position(60)));
        board.AddSnake(new Snake(new Position(87), new Position(24)));
        board.AddSnake(new Snake(new Position(93), new Position(73)));
        board.AddSnake(new Snake(new Position(95), new Position(75)));
        board.AddSnake(new Snake(new Position(98), new Position(78)));

        // Add Ladders
        board.AddLadder(new Ladder(new Position(1), new Position(38)));
        board.AddLadder(new Ladder(new Position(4), new Position(14)));
        board.AddLadder(new Ladder(new Position(9), new Position(31)));
        board.AddLadder(new Ladder(new Position(21), new Position(42)));
        board.AddLadder(new Ladder(new Position(28), new Position(84)));
        board.AddLadder(new Ladder(new Position(36), new Position(44)));
        board.AddLadder(new Ladder(new Position(51), new Position(67)));
        board.AddLadder(new Ladder(new Position(71), new Position(91)));
        board.AddLadder(new Ladder(new Position(80), new Position(100)));

        // Add Players
        Console.WriteLine("Enter the number of players:");
        int numPlayers = int.Parse(Console.ReadLine());

        //let's register the player into the system

        for (int i = 0; i < numPlayers; i++)
        {
            Console.WriteLine($"Enter the name of player {i + 1}:");
            string playerName = Console.ReadLine();
            game.AddPlayer(new Player(playerName));
        }

        // Start the game
        game.StartGame();
    }
}