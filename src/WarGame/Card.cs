namespace WarGame
{
    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades,
    }

    public enum Rank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14,
    }

    /// <summary>
    ///     A single card entity identified by suit and rank.
    /// </summary>
    /// <param name="Suit"></param>
    /// <param name="Rank"></param>
    public record Card(Suit Suit, Rank Rank)
    {
        public override string ToString()
        {
            return $"{Rank.ToString()} of {Suit.ToString()}";
        }
    }
}
