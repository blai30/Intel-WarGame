using System;
using NUnit.Framework;
using WarGame;

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
        public void ShouldHave52Cards_WhenInitialized()
        {
            _dealer.Initialize();
            Assert.That(_dealer.Cards.Count, Is.EqualTo(52));
        }
    }
}
