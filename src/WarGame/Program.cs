using System;
using WarGame;

Console.WriteLine(DateTime.UtcNow.ToString("R"));
Console.WriteLine(Environment.ProcessId);

// Initialize random object with seed generated from GUID.
Random random = new Random(Guid.NewGuid().GetHashCode());

Game game = new Game(random, "Brian", "Rodney");
game.Start();
