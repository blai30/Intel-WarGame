using NUnit.Framework;
using WarGame.Entities;

namespace WarGameTests
{
    public class CardTests
    {
        private Card _card;

        [SetUp]
        public void Setup()
        {
            _card = new Card(Suit.Spades, Rank.Ace);
        }

        [Test]
        public void ToString_PrintsCardInfo()
        {
            Assert.That(_card.ToString(), Is.EqualTo("Ace of Spades"));
        }
    }
}
