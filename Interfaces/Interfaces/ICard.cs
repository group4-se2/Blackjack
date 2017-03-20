using System;

namespace Common.Lib.Interfaces
{
    public interface ICard
    {
        Suit Suit { get; }

        string Description { get; }

        int NumericValue { get; }

        FaceValue FaceValue { get; }

        bool IsFaceCard { get; }

        bool IsAce { get; }
    }
    public enum Suit
    {
        Hearts,
        Clubs,
        Diamonds,
        Spades
    }
    public enum FaceValue
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack, // 11
        Queen,
        King,
        Ace, // 14
    }
}
