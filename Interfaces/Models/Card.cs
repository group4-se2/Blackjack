using System;
using Common.Lib.Interfaces;


namespace Common.Lib.Models
{
    public class Card : ICard
    {
        public Card(Suit suit, int numericValue)
        {
            Suit = suit;
            NumericValue = numericValue;
        }
        public Suit Suit { get; set; }

        public string Description
        {
            get
            { return this.FaceValue + " " + Suit; }
        }

        public int NumericValue { get; set; }

        public FaceValue FaceValue
        {
            get
            { return (FaceValue)NumericValue; }
        }

        public bool IsFaceCard
        {
            get
            { return NumericValue > 10 && NumericValue < 14; }
        }
        public bool IsAce
        {
            get
            { return NumericValue == 14; }
        }

        public bool IsFaceDown { get; set; }
    }
}
