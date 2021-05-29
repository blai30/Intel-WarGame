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

        /// <summary>
        ///     Populate the dealer's cards with standard 52 cards.
        /// </summary>
        public void Initialize()
        {
            Cards = new Queue<Card>();

            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Card card = new Card(suit, rank);
                    Cards.Enqueue(card);
                }
            }
        }

        /// <summary>
        ///     Shuffles the collection of cards.
        /// </summary>
        public void Shuffle()
        {
            IList<Card> list = new List<Card>(Cards);

            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = _random.Next(0, i + 1);
                Card temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }

            // This will throw away the old queue for garbage collection.
            Cards = new Queue<Card>(list);
        }
    }
}
