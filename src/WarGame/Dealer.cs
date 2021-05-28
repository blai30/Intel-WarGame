using System;
using System.Collections.Generic;

namespace WarGame
{
    /// <summary>
    ///     Represents a collection of cards with the ability to shuffle.
    /// </summary>
    public class Dealer
    {
        private readonly Random _random;

        public Queue<Card> Cards { get; private set; }

        public Dealer(Random random)
        {
            _random = random;
        }

        // TODO: Create list first then shuffle it since we cannot shuffle queue.

        /// <summary>
        ///     Populate the dealer's cards with standard 52 cards.
        /// </summary>
        public void Initialize()
        {
            List<Card> cards = new List<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Card card = new Card(suit, rank);
                    cards.Add(card);
                }
            }

            Cards = Shuffle(cards);
        }

        /// <summary>
        ///     Shuffles a list of cards.
        /// </summary>
        /// <param name="list">List of cards.</param>
        /// <returns>Shuffled cards.</returns>
        private Queue<Card> Shuffle(IList<Card> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = _random.Next(0, i + 1);
                Card temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            Queue<Card> shuffled = new Queue<Card>(list);
            return shuffled;
        }
    }
}
