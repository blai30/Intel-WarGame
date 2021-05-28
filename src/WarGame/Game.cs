using System;
using System.Collections.Generic;

namespace WarGame
{
    public class Game
    {
        public bool IsRunning => _player1.Deck.Count > 0 && _player2.Deck.Count > 0;

        private Player _player1;
        private Player _player2;
        private Dealer _dealer;
        private int _currentTurn = 1;

        /// <summary>
        ///     Create a new game.
        /// </summary>
        /// <param name="random">Random object.</param>
        public Game(Random random, string name1, string name2)
        {
            _player1 = new Player(name1);
            _player2 = new Player(name2);
            _dealer = new Dealer(random);
        }

        /// <summary>
        ///     Start the game and run the game loop.
        /// </summary>
        public void Start()
        {
            Console.WriteLine($"Starting game of war between players {_player1.Name} and {_player2.Name}.");

            _dealer.Initialize();

            for (int i = 0; i < _dealer.Cards.Count / 2; i++)
            {
                _player1.Deck.Enqueue(_dealer.Cards.Dequeue());
                _player2.Deck.Enqueue(_dealer.Cards.Dequeue());
            }
        }

        public void StepTurn()
        {
            Console.WriteLine($"Turn {_currentTurn.ToString()}.");
            Queue<Card> board = new Queue<Card>();

            Card card1 = _player1.Deck.Dequeue();
            Card card2 = _player2.Deck.Dequeue();

            board.Enqueue(card1);
            board.Enqueue(card2);

            Console.WriteLine($"{_player1.Name} plays {card1}.");
            Console.WriteLine($"{_player2.Name} plays {card2}.");

            // TODO: Implement war mechanic.

            if (card1.Rank > card2.Rank)
            {
                Console.WriteLine($"{_player1.Name} collects {board.Count.ToString()} cards this turn.");
                while (board.Count > 0)
                {
                    Card card = board.Dequeue();
                    _player1.Deck.Enqueue(card);
                }
            }
            else if (card1.Rank < card2.Rank)
            {
                Console.WriteLine($"{_player2.Name} collects {board.Count.ToString()} cards this turn.");
                while (board.Count > 0)
                {
                    Card card = board.Dequeue();
                    _player2.Deck.Enqueue(card);
                }
            }

            Console.WriteLine($"{_player1.Name} has {_player1.Deck.Count.ToString()} card(s) left.");
            Console.WriteLine($"{_player2.Name} has {_player2.Deck.Count.ToString()} card(s) left.");
            Console.WriteLine();
            _currentTurn++;
        }
    }
}
