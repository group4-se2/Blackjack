using Common.Lib.Models;

namespace Common.Lib.Interfaces
{
    public interface ICard
    {
        CardType CardType { get; set; }
        Suit Suit { get; set; }
        int Value { get; set; }
    }
}