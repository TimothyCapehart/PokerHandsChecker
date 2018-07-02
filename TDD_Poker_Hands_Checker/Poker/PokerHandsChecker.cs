using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var distinctCards = hand.Cards.ToList().Distinct().ToList();
            return distinctCards.Count == 5 && hand.Cards.Count == 5;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            if (IsStraight(hand) && IsFlush(hand))
                return true;
            return false;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            var count = 0;
            foreach (var card in hand.Cards)
            {
                foreach (var c in hand.Cards)
                {
                    if (card.Face.Equals(c.Face))
                        count++;
                    if (count > 3)
                        return true;
                }
                count = 0;
            }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!IsThreeOfAKind(hand))
                return false;
            CardFace setFace = CardFace.Joker;
            var count = 0;
            foreach (var card in hand.Cards)
            {
                foreach (var c in hand.Cards)
                {
                    if (card.Face.Equals(c.Face))
                        count++;
                    if (count > 2)
                        setFace = card.Face;
                }
                count = 0;
            }
            foreach (var card in hand.Cards)
                foreach (var c in hand.Cards)
                    if (!card.Face.Equals(setFace) && !card.Equals(c) && card.Face.Equals(c.Face))
                        return true;
            return false;
        }

        public bool IsFlush(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            var handArray = hand.Cards.ToArray();
            var suit = handArray[0].Suit;
            foreach (var card in handArray)
                if (!card.Suit.Equals(suit))
                    return false;
            return true;
        }

        public bool IsStraight(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            var handArray = hand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            if (handArray[0].Face.Equals(CardFace.Two) && handArray[4].Face.Equals(CardFace.Ace))
                handArray[4].Face = CardFace.AltAce;
            handArray = handArray.OrderBy(card => card.Face).ToArray();
            for (int i = 0; i < 4; i++)
                if (!handArray[i].Face.Equals((handArray[i + 1].Face) - 1))
                {
                    foreach (var card in handArray)
                        if (card.Face.Equals(CardFace.AltAce))
                            card.Face = CardFace.Ace;
                    return false;
                }
            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            var count = 0;
            foreach (var card in hand.Cards)
            {
                foreach (var c in hand.Cards)
                {
                    if (card.Face.Equals(c.Face))
                        count++;
                    if (count > 2)
                        return true;
                }
                count = 0;
            }
            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            CardFace firstPair = CardFace.Joker;
            if (!IsOnePair(hand))
                return false;
            foreach (var card in hand.Cards)
                foreach (var c in hand.Cards)
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        firstPair = card.Face;
            foreach (var card in hand.Cards)
                foreach (var c in hand.Cards)
                    if (!card.Face.Equals(firstPair) && !card.Equals(c) && card.Face.Equals(c.Face))
                        return true;
            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!IsValidHand(hand))
                return false;
            foreach (var card in hand.Cards)
            {
                foreach (var c in hand.Cards)
                {
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        return true;
                }
                   
            }
            
            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            if (IsValidHand(hand))
                return true;
            return false; 
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            // highcard, pair, twopair, set, straight, flush, fullhouse, four of a kind, straight flush
            // 1         2     3        4    5         6      7          8               9

            if (!IsValidHand(firstHand) || !IsValidHand(secondHand))
                throw new System.InvalidOperationException("Invalid hand.");

            if (firstHand.Equals(secondHand))
                return 0;
           
            var firstRank = 0;
            var secondRank = 0;

            //firstHand
            if (IsStraightFlush(firstHand)) firstRank = 9;
            else if (IsFourOfAKind(firstHand)) firstRank = 8;
            else if (IsFullHouse(firstHand)) firstRank = 7;
            else if (IsFlush(firstHand)) firstRank = 6;
            else if (IsStraight(firstHand)) firstRank = 5;
            else if (IsThreeOfAKind(firstHand)) firstRank = 4;
            else if (IsTwoPair(firstHand)) firstRank = 3;
            else if (IsOnePair(firstHand)) firstRank = 2;
            else if (IsHighCard(firstHand)) firstRank = 1;
            //secondHand
            if (IsStraightFlush(secondHand)) secondRank = 9;
            else if (IsFourOfAKind(secondHand)) secondRank = 8;
            else if (IsFullHouse(secondHand)) secondRank = 7;
            else if (IsFlush(secondHand)) secondRank = 6;
            else if (IsStraight(secondHand)) secondRank = 5;
            else if (IsThreeOfAKind(secondHand)) secondRank = 4;
            else if (IsTwoPair(secondHand)) secondRank = 3;
            else if (IsOnePair(secondHand)) secondRank = 2;
            else if (IsHighCard(secondHand)) secondRank = 1;

            if (firstRank > secondRank)
                return -1;
            if (firstRank < secondRank)
                return 1;
            if (firstRank == secondRank) // same ranked hands
            {
                switch (firstRank)
                {

                    case 1: return BothHighCard(firstHand, secondHand, 4);
                    case 2: return BothOnePair(firstHand, secondHand);
                    case 3: return BothTwoPair(firstHand, secondHand);
                    case 4: return BothThreeOfAKind(firstHand, secondHand);
                    case 5: return BothStraight(firstHand, secondHand);
                    case 6: return BothFlush(firstHand, secondHand);
                    case 7: return BothFullHouse(firstHand, secondHand);
                    case 8: return BothFourOfAKind(firstHand, secondHand);
                    case 9: return BothStraightFlush(firstHand, secondHand);
                }
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothHighCard(IHand firstHand, IHand secondHand, int index)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            if (index == 0)
            {
                if (firstSorted[0].Face > secondSorted[0].Face)
                    return -1;
                else if (firstSorted[0].Face < secondSorted[0].Face)
                    return 1;
                else if (firstSorted[0].Face == secondSorted[0].Face)
                    return 0;
            }
            
            if (firstSorted[index].Face > secondSorted[index].Face)
                return -1;
            else if (firstSorted[index].Face < secondSorted[index].Face)
                return 1;
            else if (firstSorted[index].Face == secondSorted[index].Face)
                return BothHighCard(firstHand, secondHand, index - 1);

            throw new System.InvalidOperationException("Error");
        }

        public int BothOnePair(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            var firstPair = CardFace.Joker;
            var secondPair = CardFace.Joker;

            foreach (var card in firstHand.Cards)
                foreach (var c in firstHand.Cards)
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        firstPair = card.Face;
            foreach (var card in secondHand.Cards)
                foreach (var c in secondHand.Cards)
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        secondPair = card.Face;

            if (firstPair > secondPair)
                return -1;
            else if (firstPair < secondPair)
                return 1;
            else if (firstPair == secondPair)
            {
                var firstNonPair = new List<ICard>();
                var secondNonPair = new List<ICard>();

                foreach (var card in firstSorted)
                    if (!card.Face.Equals(firstPair))
                        firstNonPair.Add(card);
                foreach (var card in secondSorted)
                    if (!card.Face.Equals(secondPair))
                        secondNonPair.Add(card);
                var firstNonHand = new Hand(firstNonPair);
                var secondNonHand = new Hand(secondNonPair);

                return BothHighCard(firstNonHand, secondNonHand, 2);
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothTwoPair(IHand firstHand, IHand secondHand)
        {
            var first1Pair = CardFace.Joker;
            var first2Pair = CardFace.Joker;
            var second1Pair = CardFace.Joker;
            var second2Pair = CardFace.Joker;
            var firstTop = CardFace.Joker;
            var first2nd = CardFace.Joker;
            var secondTop = CardFace.Joker;
            var second2nd = CardFace.Joker;

            foreach (var card in firstHand.Cards)
                foreach (var c in firstHand.Cards)
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        first1Pair = card.Face;
            foreach (var card in firstHand.Cards)
                foreach (var c in firstHand.Cards)
                    if (!card.Face.Equals(first1Pair) && !card.Equals(c) && card.Face.Equals(c.Face))
                        first2Pair = card.Face;
            foreach (var card in secondHand.Cards)
                foreach (var c in secondHand.Cards)
                    if (!card.Equals(c) && card.Face.Equals(c.Face))
                        second1Pair = card.Face;
            foreach (var card in secondHand.Cards)
                foreach (var c in secondHand.Cards)
                    if (!card.Face.Equals(second1Pair) && !card.Equals(c) && card.Face.Equals(c.Face))
                        second2Pair = card.Face;

            if (first1Pair > first2Pair)
            {
                firstTop = first1Pair;
                first2nd = first2Pair;
            }
            else
            {
                firstTop = first2Pair;
                first2nd = first1Pair;
            }
            if (second1Pair > second2Pair)
            {
                secondTop = second1Pair;
                second2nd = second2Pair;
            }
            else
            {
                secondTop = second2Pair;
                second2nd = second1Pair;
            }

            if (firstTop > secondTop)
                return -1;
            else if (firstTop < secondTop)
                return 1;
            else if (firstTop == secondTop)
            {
                if (first2nd > second2nd)
                    return -1;
                else if (first2nd < second2nd)
                    return 1;
                else if (first2nd == second2nd)
                {
                    var firstOther = CardFace.Joker;
                    var secondOther = CardFace.Joker;

                    foreach (var card in firstHand.Cards)
                        if (!card.Face.Equals(firstTop) && !card.Face.Equals(first2nd))
                            firstOther = card.Face;
                    foreach (var card in secondHand.Cards)
                        if (!card.Face.Equals(firstTop) && !card.Face.Equals(first2nd))
                            secondOther = card.Face;
                    if (firstOther > secondOther)
                        return -1;
                    else if (firstOther < secondOther)
                        return 1;
                    else
                        return 0;
                }
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothThreeOfAKind(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            var firstSet = CardFace.Joker;
            var secondSet = CardFace.Joker;

            if (firstSorted[1].Face == firstSorted[2].Face)
                firstSet = firstSorted[1].Face;
            else firstSet = firstSorted[4].Face;

            if (secondSorted[1].Face == secondSorted[2].Face)
                secondSet = secondSorted[1].Face;
            else secondSet = secondSorted[4].Face;

            if (firstSet > secondSet)
                return -1;
            else if (firstSet < secondSet)
                return 1;
            else if (firstSet == secondSet)
            {
                var firstNonSet = new List<ICard>();
                var secondNonSet = new List<ICard>();
                foreach (var card in firstSorted)
                    if (card.Face != firstSet)
                        firstNonSet.Add(card);
                foreach (var card in secondSorted)
                    if (card.Face != firstSet)
                        secondNonSet.Add(card);

                var firstOtherSorted = firstNonSet.OrderBy(card => card.Face).ToArray();
                var secondOtherSorted = secondNonSet.OrderBy(card => card.Face).ToArray();

                if (firstOtherSorted[0].Face > secondOtherSorted[0].Face)
                    return -1;
                else if (firstOtherSorted[0].Face < secondOtherSorted[0].Face)
                    return 1;
                else if (firstOtherSorted[0].Face == secondOtherSorted[0].Face)
                {
                    if (firstOtherSorted[1].Face > secondOtherSorted[1].Face)
                        return -1;
                    else if (firstOtherSorted[1].Face < secondOtherSorted[1].Face)
                        return 1;
                    else
                        return 0;
                }
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothStraight(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            if (firstSorted[4].Face > secondSorted[4].Face)
                return -1;
            else if (firstSorted[4].Face < secondSorted[4].Face)
                return 1;
            else if (firstSorted[4].Face == secondSorted[4].Face)
                return 0;
            else
                throw new System.InvalidOperationException("Error");
        }

        public int BothFlush(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            if (firstSorted[4].Face > secondSorted[4].Face)
                return -1;
            else if (firstSorted[4].Face < secondSorted[4].Face)
                return 1;
            else if (firstSorted[4].Face == secondSorted[4].Face)
            {
                if (firstSorted[0].Suit > secondSorted[0].Suit)
                    return -1;
                else if (firstSorted[0].Suit < secondSorted[0].Suit)
                    return 1;
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothFullHouse(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            var first3 = CardFace.Joker;
            var second3 = CardFace.Joker;
            var first2 = CardFace.Joker;
            var second2 = CardFace.Joker;
            var firstCount = 0;
            var secondCount = 0;

            foreach (var card in firstHand.Cards)
            {
                foreach (var c in firstHand.Cards)
                {
                    if (card.Face.Equals(c.Face))
                        firstCount++;
                    if (firstCount > 2)
                        first3 = card.Face;
                }
                firstCount = 0;
            }
            foreach (var card in secondHand.Cards)
            {
                foreach (var c in secondHand.Cards)
                {
                    if (card.Face.Equals(c.Face))
                        secondCount++;
                    if (secondCount > 2)
                        second3 = card.Face;
                }
                secondCount = 0;
            }

            if (first3 > second3)
                return -1;
            else if (first3 < second3)
                return 1;
            else if (first3 == second3)
            {
                if (firstSorted[4].Face == first3)
                    first2 = firstSorted[0].Face;
                else
                    first2 = firstSorted[4].Face;

                if (secondSorted[4].Face == second3)
                    second2 = secondSorted[0].Face;
                else
                    second2 = secondSorted[4].Face;

                if (first2 > second2)
                    return -1;
                else if (first2 < second2)
                    return 1;
                else if (first2 == second2)
                    return 0;
            }
            throw new System.InvalidOperationException("Error");
        }

        public int BothFourOfAKind(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            if (firstSorted[2].Face > secondSorted[2].Face)
                return -1;
            else if (firstSorted[2].Face < secondSorted[2].Face)
                return 1;
            else
            {
                var firstOther = CardFace.Joker;
                var secondOther = CardFace.Joker;
                foreach (var card in firstSorted)
                    if (!card.Face.Equals(firstSorted[2].Face))
                        firstOther = card.Face;
                foreach (var card in secondSorted)
                    if (!card.Face.Equals(secondSorted[2].Face))
                        secondOther = card.Face;
                if (firstOther > secondOther)
                    return -1;
                else if (firstOther < secondOther)
                    return 1;
                else return 0;
            }
        }

        public int BothStraightFlush(IHand firstHand, IHand secondHand)
        {
            var firstSorted = firstHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();
            var secondSorted = secondHand.Cards.ToArray().OrderBy(card => card.Face).ToArray();

            if (firstSorted[4].Face > secondSorted[4].Face)
                return -1;
            else if (firstSorted[4].Face < secondSorted[4].Face)
                return 1;
            else if (firstSorted[4].Face == secondSorted[4].Face)
                if (firstSorted[0].Suit > secondSorted[0].Suit)
                    return -1;
                else if (firstSorted[0].Suit < secondSorted[0].Suit)
                    return 1;
                else return 0;

            throw new System.InvalidOperationException("Error");
        }
    }
}
