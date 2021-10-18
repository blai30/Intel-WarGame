using System;
using WarGame.Core;

// Initialize random object with seed generated from GUID.
Random random = new Random(Guid.NewGuid().GetHashCode());

Console.Write("Enter name for player 1: ");
string name1 = Console.ReadLine();
name1 = string.IsNullOrEmpty(name1) ? "Player 1" : name1;

Console.Write("Enter name for player 2: ");
string name2 = Console.ReadLine();
name2 = string.IsNullOrEmpty(name2) ? "Player 2" : name2;

Game game = new Game(random, name1, name2);
game.Start();
game.DetermineWinner();

Console.WriteLine("Game will now end.");
