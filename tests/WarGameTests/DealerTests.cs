using System;
using NUnit.Framework;
using WarGame.Core;
using WarGame.Entities;

namespace WarGameTests
{
    public class DealerTests
    {
        private Dealer _dealer;

        [SetUp]
        public void Setup()
        {
            Random random = new Random(new Guid().GetHashCode());
            _dealer = new Dealer(random);
        }

        [Test]
        public void Cards_IsNull_WhenCreated()
        {
            Assert.That(_dealer.Cards, Is.Null);
        }

        [Test]
        public void CardsCount_Is52_WhenInitialized()
        {
            _dealer.Initialize();
            Assert.That(_dealer.Cards.Count, Is.EqualTo(52));
        }

        [Test]
        public void CardsCount_Is52_WhenShuffled()
        {
            _dealer.Initialize();
            _dealer.Shuffle();
            Assert.That(_dealer.Cards.Count, Is.EqualTo(52));
        }

        [Test]
        public void FirstCard_IsTwoOfClubs_WhenInitialized()
        {
            _dealer.Initialize();
            Card card;

            card = _dealer.Cards.Dequeue();
            Assert.That(card.Suit, Is.EqualTo(Suit.Clubs));
            Assert.That(card.Rank, Is.EqualTo(Rank.Two));
        }

        [Test]
        public void LastCard_IsAceOfSpades_WhenInitialized()
        {
            _dealer.Initialize();
            Card card = null;

            while (_dealer.Cards.Count > 0)
            {
                card = _dealer.Cards.Dequeue();
            }

            Assert.That(card, Is.Not.Null);
            Assert.That(card.Suit, Is.EqualTo(Suit.Spades));
            Assert.That(card.Rank, Is.EqualTo(Rank.Ace));
        }
    }
}
