using System;
using WarGame;

Console.WriteLine(DateTime.UtcNow.ToString("R"));
Console.WriteLine(Environment.ProcessId);

// Initialize random object with seed generated from GUID.
Random random = new Random(Guid.NewGuid().GetHashCode());

Console.Write("Enter name for player 1: ");
string name1 = Console.ReadLine() ?? "Player 1";

Console.Write("Enter name for player 2: ");
string name2 = Console.ReadLine() ?? "Player 2";

Game game = new Game(random, name1, name2);
game.Start();
game.DetermineWinner();

Console.WriteLine("Game will now end.");
