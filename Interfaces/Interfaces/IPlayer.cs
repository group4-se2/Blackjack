namespace Common.Lib.Interfaces
{
    public interface IPlayer
    {
        int Bank { get; set; }
        IHand Hand { get; set; }
        string Name { get; set; }
        int Wager { get; set; }
    }
}