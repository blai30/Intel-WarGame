using System;
using System.Collections.Generic;

namespace WarGame
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private Dealer _dealer;

        /// <summary>
        ///     Create a new game.
        /// </summary>
        /// <param name="random">Random object.</param>
        public Game(Random random)
        {
            _player1 = new Player();
            _player2 = new Player();
            _dealer = new Dealer(random);
        }

        /// <summary>
        ///     Start the game and run the game loop.
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Starting game of war.");

            _dealer.Initialize();

            for (int i = 0; i < _dealer.Cards.Count / 2; i++)
            {
                _player1.Deck.Enqueue(_dealer.Cards.Dequeue());
                _player2.Deck.Enqueue(_dealer.Cards.Dequeue());
            }

            StepTurn();
        }

        private void StepTurn()
        {
            Queue<Card> board = new Queue<Card>();

            Card card1 = _player1.Deck.Dequeue();
            Card card2 = _player2.Deck.Dequeue();

            board.Enqueue(card1);
            board.Enqueue(card2);

            Console.WriteLine($"Player 1 plays {card1}.");
            Console.WriteLine($"Player 2 plays {card2}.");
        }
    }
}
