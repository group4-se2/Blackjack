namespace Interfaces
{
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Club
    }
    public enum CardType
    {
        Face,
        Pip,
        Ace
    }
    public interface ICard
    {
        CardType CardType { get; set; }
        Suit Suit { get; set; }
        int Value { get; set; }
    }
}