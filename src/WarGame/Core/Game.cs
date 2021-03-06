using System;
using System.Collections.Generic;
using WarGame.Entities;

namespace WarGame.Core
{
    public class Game
    {
        public bool IsRunning => _player1.Deck.Count > 0 && _player2.Deck.Count > 0;

        private readonly Dealer _dealer;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Queue<Card> _board = new();

        private uint _currentTurn = 1;

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
            _dealer.Shuffle();
            int initialDeckSize = _dealer.Cards.Count / 2;

            for (int i = 0; i < initialDeckSize; i++)
            {
                _player1.Deck.Enqueue(_dealer.Cards.Dequeue());
                _player2.Deck.Enqueue(_dealer.Cards.Dequeue());
            }

            while (IsRunning)
            {
                StepTurn();
            }
        }

        /// <summary>
        ///     Check deck count of both players. No winner is selected if both players still have cards.
        ///     The player with remaining cards is selected as the winner.
        /// </summary>
        public void DetermineWinner()
        {
            if (_player1.Deck.Count > 0 && _player2.Deck.Count > 0)
            {
                return;
            }

            if (_player1.Deck.Count > _player2.Deck.Count)
            {
                Console.WriteLine($"{_player1.Name} takes the victory!");
            }
            else if (_player1.Deck.Count < _player2.Deck.Count)
            {
                Console.WriteLine($"{_player2.Name} takes the victory!");
            }
        }

        /// <summary>
        ///     Both players take a turn in the game and play a card then check the cards.
        /// </summary>
        private void StepTurn()
        {
            // Corner case for infinite game where neither player wins.
            if (_currentTurn > 2000)
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

        /// <summary>
        ///     Both players play a card on the board.
        /// </summary>
        /// <param name="card1">Player 1 card.</param>
        /// <param name="card2">Player 2 card.</param>
        private void PlayCards(Card card1, Card card2)
        {
            _board.Enqueue(card1);
            _board.Enqueue(card2);

            Console.WriteLine($"{_player1.Name} plays {card1}.");
            Console.WriteLine($"{_player2.Name} plays {card2}.");
        }

        /// <summary>
        ///     Check the rank of both cards. Declare war if the rank is equal. Otherwise, the higher ranking card wins the turn.
        /// </summary>
        /// <param name="card1">Player 1 card.</param>
        /// <param name="card2">Player 2 card.</param>
        private void CheckCards(Card card1, Card card2)
        {
            // Continue declaring war until both cards are no longer equal or a player no longer has enough cards.
            while (card1.Rank == card2.Rank)
            {
                Console.WriteLine("Declaring war.");

                if (ContinueWar() is false)
                {
                    return;
                }

                Console.WriteLine("Both players place 3 cards face down.");
                _board.Enqueue(_player1.Deck.Dequeue());
                _board.Enqueue(_player2.Deck.Dequeue());
                _board.Enqueue(_player1.Deck.Dequeue());
                _board.Enqueue(_player2.Deck.Dequeue());
                _board.Enqueue(_player1.Deck.Dequeue());
                _board.Enqueue(_player2.Deck.Dequeue());

                // The fourth card is played face up.
                card1 = _player1.Deck.Dequeue();
                card2 = _player2.Deck.Dequeue();
                PlayCards(card1, card2);
            }

            EvaluateCardRank(card1, card2);
        }

        /// <summary>
        ///     Compare the rank of the cards and the player with the higher ranking card takes all cards on the board.
        /// </summary>
        /// <param name="card1">Player 1 card.</param>
        /// <param name="card2">Player 2 card.</param>
        private void EvaluateCardRank(Card card1, Card card2)
        {
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

        /// <summary>
        ///     Check if both players have enough cards to declare war.
        /// </summary>
        /// <returns>Both players have enough cards for war.</returns>
        private bool ContinueWar()
        {
            if (_player1.Deck.Count < 4)
            {
                Console.WriteLine($"{_player1.Name} does not have enough cards!");
                _player1.Deck.Clear();
                return false;
            }

            if (_player2.Deck.Count < 4)
            {
                Console.WriteLine($"{_player2.Name} does not have enough cards!");
                _player2.Deck.Clear();
                return false;
            }

            return true;
        }
    }
}
