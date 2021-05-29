using NUnit.Framework;
using WarGame.Entities;

namespace WarGameTests
{
    public class PlayerTests
    {
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _player = new Player("Brian");
        }

        [Test]
        public void Name_IsNotEmpty_WhenCreated()
        {
            Assert.That(_player.Name, Is.Not.Empty);
        }

        [Test]
        public void Deck_IsNotNull_WhenCreated()
        {
            Assert.That(_player.Deck, Is.Not.Null);
        }

        [Test]
        public void Deck_ContainsNothing_WhenCreated()
        {
            Assert.That(_player.Deck.Count, Is.EqualTo(0));
        }
    }
}
