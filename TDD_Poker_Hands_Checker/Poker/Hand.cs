using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach(var card in Cards)
            {
                builder.Append(card.ToString() + " ");
            }
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            var hand = obj as Hand;
            var sortedByFaceThis = Cards.ToArray().OrderBy(card => card.Suit).ThenBy(c => c.Face).ToArray();
            var sortedByFaceInc = hand.Cards.ToArray().OrderBy(card => card.Suit).ThenBy(c => c.Face).ToArray();
            bool match = true;
            for (int i = 0; i < 5; i++)
                if (!sortedByFaceThis[i].Equals(sortedByFaceInc[i]))
                    match = false;
            return match;
        }

        public override int GetHashCode()
        {
            var sum = 0;
            Cards.ToList().ForEach(card => sum += card.GetHashCode());
            return sum;
        }
    }
}
