using System;
using WarGame;

Console.WriteLine(DateTime.UtcNow.ToString("R"));
Console.WriteLine(Environment.ProcessId);

// Initialize random object with seed generated from GUID.
Random random = new Random(Guid.NewGuid().GetHashCode());

Game game = new Game(random, "Brian", "Rodney");
game.Start();

// Prevent auto-close window on program end, wait for key press instead.
Console.ReadKey();
