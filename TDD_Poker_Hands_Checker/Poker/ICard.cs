namespace Poker
{
    public interface ICard
    {
        CardFace Face { get; set; }
        CardSuit Suit { get; }
    }
}
