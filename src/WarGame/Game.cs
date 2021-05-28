using System;
using System.Collections.Generic;

namespace WarGame
{
    public class Game
    {
        private List<Player> _players;

        /// <summary>
        ///     Create a new game and define the number of players.
        /// </summary>
        /// <param name="playerCount">Number of players participating.</param>
        public Game(int playerCount = 2)
        {
            _players = new List<Player>(playerCount);
            for (int i = 0; i < playerCount; i++)
            {
                var player = new Player();
                _players.Add(player);
            }
        }

        public void Start(Random random)
        {
            Console.WriteLine("Starting game");

            Dealer dealer = new Dealer(random);
            dealer.Initialize();

            int initialDeckSize = 52 / _players.Count;
            foreach (Player player in _players)
            {
                for (int i = 0; i < initialDeckSize; i++)
                {
                    player.Deck.Enqueue(dealer.Cards.Dequeue());
                }
            }

            Console.WriteLine("Dealt");
        }
    }
}
