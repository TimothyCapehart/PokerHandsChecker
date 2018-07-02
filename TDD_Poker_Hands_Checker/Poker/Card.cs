using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get;  set; }
        public CardSuit Suit { get;  set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Face: " + Face);
            builder.Append(" Suit: " + Suit);
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            return (Face == card.Face && Suit == card.Suit);
        }

        public override int GetHashCode()
        {
            var hashCode = -907917060;
            hashCode = hashCode * -1521134295 + Face.GetHashCode();
            hashCode = hashCode * -1521134295 + Suit.GetHashCode();
            return hashCode;
        }

    }
}
