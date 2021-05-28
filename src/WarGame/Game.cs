using System;
using System.Collections.Generic;

namespace WarGame
{
    public class Game
    {
        public bool IsRunning => _player1.Deck.Count > 0 && _player2.Deck.Count > 0;

        private Dealer _dealer;
        private Player _player1;
        private Player _player2;
        private uint _currentTurn = 1;
        private Queue<Card> _board = new();

        /// <summary>
        ///     Create a new game.
        /// </summary>
        /// <param name="random">Random object.</param>
        /// <param name="name1">Name of player 1.</param>
        /// <param name="name2">Name of player 2.</param>
        public Game(Random random, string name1, string name2)
        {
            _dealer = new Dealer(random);
            _player1 = new Player(name1);
            _player2 = new Player(name2);
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

            while (IsRunning)
            {
                StepTurn();
            }

            DetermineWinner();
            Console.WriteLine("Game will now end.");
        }

        private void DetermineWinner()
        {
            if (_player1.Deck.Count > 0 && _player2.Deck.Count <= 0)
            {
                Console.WriteLine($"{_player1.Name} takes the victory!");
            }
            else if (_player1.Deck.Count <= 0 && _player2.Deck.Count > 0)
            {
                Console.WriteLine($"{_player2.Name} takes the victory!");
            }
        }

        private void StepTurn()
        {
            if (_currentTurn >= 2000)
            {
                Console.WriteLine("Infinite game detected, ending...");
                _player1.Deck.Clear();
                _player2.Deck.Clear();
                return;
            }

            Console.WriteLine($"Turn {_currentTurn.ToString()}.");

            Card card1 = _player1.Deck.Dequeue();
            Card card2 = _player2.Deck.Dequeue();

            PlayCards(card1, card2);
            CheckCards(card1, card2);

            Console.WriteLine($"{_player1.Name} has {_player1.Deck.Count.ToString()} card(s) left.");
            Console.WriteLine($"{_player2.Name} has {_player2.Deck.Count.ToString()} card(s) left.");
            Console.WriteLine();
            _currentTurn++;
        }

        private void PlayCards(Card card1, Card card2)
        {
            _board.Enqueue(card1);
            _board.Enqueue(card2);

            Console.WriteLine($"{_player1.Name} plays {card1}.");
            Console.WriteLine($"{_player2.Name} plays {card2}.");
        }

        private void CheckCards(Card card1, Card card2)
        {
            while (card1.Rank == card2.Rank)
            {
                Console.WriteLine("Declaring war.");

                if (_player1.Deck.Count < 4)
                {
                    Console.WriteLine($"{_player1.Name} does not have enough cards!");
                    _player1.Deck.Clear();
                    return;
                }

                if (_player2.Deck.Count < 4)
                {
                    Console.WriteLine($"{_player2.Name} does not have enough cards!");
                    _player2.Deck.Clear();
                    return;
                }

                Console.WriteLine("Both players place 3 cards face down.");
                for (int i = 0; i < 3; i++)
                {
                    _board.Enqueue(_player1.Deck.Dequeue());
                    _board.Enqueue(_player2.Deck.Dequeue());
                }

                card1 = _player1.Deck.Dequeue();
                card2 = _player2.Deck.Dequeue();

                PlayCards(card1, card2);
            }

            if (card1.Rank > card2.Rank)
            {
                // Player 1 card ranks higher and takes the board.
                Console.WriteLine($"{_player1.Name} collects {_board.Count.ToString()} cards this turn.");
                while (_board.Count > 0)
                {
                    Card card = _board.Dequeue();
                    _player1.Deck.Enqueue(card);
                }
            }
            else if (card1.Rank < card2.Rank)
            {
                // Player 2 card ranks higher and takes the board.
                Console.WriteLine($"{_player2.Name} collects {_board.Count.ToString()} cards this turn.");
                while (_board.Count > 0)
                {
                    Card card = _board.Dequeue();
                    _player2.Deck.Enqueue(card);
                }
            }
        }
    }
}
