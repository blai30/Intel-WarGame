using System;
using WarGame;

Console.WriteLine(DateTime.UtcNow.ToString("R"));
Console.WriteLine(Environment.ProcessId);

// Initialize random object with seed generated from GUID.
Random random = new Random(new Guid().GetHashCode());

Game game = new Game(2);
game.Start(random);
