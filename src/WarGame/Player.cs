using System.Collections.Generic;

namespace WarGame
{
    public class Player
    {
        public string Name { get; }
        public Queue<Card> Deck = new();

        public Player(string name)
        {
            Name = name;
        }
    }
}
