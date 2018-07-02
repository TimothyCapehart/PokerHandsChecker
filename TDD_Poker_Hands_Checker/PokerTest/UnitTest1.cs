using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Poker;

namespace PokerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CardToStringTest()
        {
            var testCard = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.AreEqual("Face: Ace Suit: Spades", testCard.ToString());
        }

        [TestMethod]
        public void CardEqualsTestReturnsTrue()
        {
            var testCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            var testCard2 = new Card(CardFace.Ace, CardSuit.Spades);
            Assert.IsTrue(testCard1.Equals(testCard2));
        }

        [TestMethod]
        public void CardEqualsTestReturnsFalseSuit()
        {
            var testCard1 = new Card(CardFace.Ace, CardSuit.Spades);
            var testCard2 = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(testCard1.Equals(testCard2));
        }

        [TestMethod]
        public void CardEqualsTestReturnsFalseFace()
        {
            var testCard1 = new Card(CardFace.King, CardSuit.Hearts);
            var testCard2 = new Card(CardFace.Ace, CardSuit.Hearts);
            Assert.IsFalse(testCard1.Equals(testCard2));
        }

        [TestMethod]
        public void HandToStringTest()
        {
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.AreEqual(testHand.ToString(), "Face: Ace Suit: Spades Face: King Suit: Hearts Face: Queen Suit: Diamonds Face: Jack Suit: Clubs Face: Ten Suit: Spades ");
        }

        [TestMethod]
        public void HandEqualsTestReturnsTrue()
        {
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };
            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.IsTrue(testHand1.Equals(testHand2));
        }

        public void HandEqualsTestReturnsFalse()
        {
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };
            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.IsFalse(testHand1.Equals(testHand2));
        }

        [TestMethod]
        public void CheckerValidHandReturnsTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsValidHand(testHand));
        }

        [TestMethod]
        public void CheckerValidHandReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsValidHand(testHand));
        }

        [TestMethod]
        public void CheckerValidHandReturnsFalseTooFew()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsValidHand(testHand));
        }

        [TestMethod]
        public void CheckerValidHandReturnsFalseTooMany()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsValidHand(testHand));
        }

        [TestMethod]
        public void CheckerIsHighCardInvalidReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsHighCard(testHand));
        }

        [TestMethod]
        public void CheckerIsHighCardValidReturnsTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsHighCard(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairInvalidHand()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairValidHandReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairTwoPairTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairSetTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairFullHouseTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsOnePairFourKindTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsOnePair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairInvaldHandReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairValidPairReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairValidNoPairReturnFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairValidReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairValidFullHouseReturnTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsTwoPairValidFourKindReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsTwoPair(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindInvalidHandReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindValidSetReturnsTrue()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindValidFullHouseTest()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindValidFourOfAKindTest()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindValidPairReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsThreeOfAKindValidHighCardReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsThreeOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindInvalidHand()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindValidFourOfAKind()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindValidSetReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindValidPairReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindValidFullHouseReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFourOfAKindValidTwoPairReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFourOfAKind(testHand));
        }

        [TestMethod]
        public void CheckerIsFullHouseInvalidHand()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFullHouse(testHand));
        }

        [TestMethod]
        public void CheckerIsFullHouseValidTwoPairReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFullHouse(testHand));
        }

        [TestMethod]
        public void CheckerIsFullHouseValidSetReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFullHouse(testHand));
        }

        [TestMethod]
        public void CheckerIsFullHouseValidFourKindReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFullHouse(testHand));
        }

        [TestMethod]
        public void CheckerIsFlushInvalidHand()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts)

            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsFlushValidFlush()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsFlushValidOneOffReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsFlushValidTwoOffReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightInvalidHand()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightValidStraightHigh()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),           
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightValidStraightMid()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightValidStraightLow()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightValidOneOffAReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightValidOneOffBReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraight(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushInvalid()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraightFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushValidStraightFlushMid()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraightFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushValidRoyalFlush()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraightFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushValidLow()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand = new Hand(testCards);

            Assert.IsTrue(checker.IsStraightFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushValidOneOffFaceReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraightFlush(testHand));
        }

        [TestMethod]
        public void CheckerIsStraightFlushValidOneOffSuitReturnsFalse()
        {
            var checker = new PokerHandsChecker();
            var testCards = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand = new Hand(testCards);

            Assert.IsFalse(checker.IsStraightFlush(testHand));
        }

        //invalid hand1
        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void CheckerCompareHandsInvalidFirst()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            checker.CompareHands(testHand1, testHand2);
        }
        //invalid hand2
        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void CheckerCompareHandsInvalidSecond()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            checker.CompareHands(testHand1, testHand2);
        }
        //equal hands
        [TestMethod]
        public void CheckerCompareHandsEqualHands()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(0, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats SF face
        [TestMethod]
        public void CheckerCompareHandsSFBeatsSFFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats SF suit
        [TestMethod]
        public void CheckerCompareHandsSFBeatsSFSuit()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testCards2 = new List<ICard>
            {
               new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats 4k
        [TestMethod]
        public void CheckerCompareHandsSFBeats4Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats Boat
        [TestMethod]
        public void CheckerCompareHandsSFBeatsFullHouse()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats Flush
        [TestMethod]
        public void CheckerCompareHandsSFBeatsFlush()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats S
        [TestMethod]
        public void CheckerCompareHandsSFBeatsStraight()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats Set
        [TestMethod]
        public void CheckerCompareHandsSFBeats3Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats 2p
        [TestMethod]
        public void CheckerCompareHandsSFBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats P
        [TestMethod]
        public void CheckerCompareHandsSFBeatsPair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //SF beats HC
        [TestMethod]
        public void CheckerCompareHandsSFBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats 4k face
        [TestMethod]
        public void CheckerCompareHands4KindBeats4KFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats 4k Other
        [TestMethod]
        public void CheckerCompareHands4KindBeats4KKicker()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats FH
        [TestMethod]
        public void CheckerCompareHands4KindBeatsFullHouse()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats Flush
        [TestMethod]
        public void CheckerCompareHands4KindBeatsFlush()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats S
        [TestMethod]
        public void CheckerCompareHands4KindBeatsStraight()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats Set
        [TestMethod]
        public void CheckerCompareHands4KindBeats3Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats 2p
        [TestMethod]
        public void CheckerCompareHands4KindBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats P
        [TestMethod]
        public void CheckerCompareHands4KindBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //4k beats HC
        [TestMethod]
        public void CheckerCompareHands4KindBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats FH rank1
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeatsFullHouseRank1()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats FH rank2
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeatsFullHouseRank2()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats Flush
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeatsFlush()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats S
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeatsStraight()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats Set
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeats3Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats 2p
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats P
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //FH beats HC
        [TestMethod]
        public void CheckerCompareHandsFullHouseBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats Flush Face
        [TestMethod]
        public void CheckerCompareHandsFlushBeatsFlushFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats Flush suit
        [TestMethod]
        public void CheckerCompareHandsFlushBeatsFlushSuit()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats S
        [TestMethod]
        public void CheckerCompareHandsFlushBeatsStraight()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats Set
        [TestMethod]
        public void CheckerCompareHandsFlushBeats3Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats 2p
        [TestMethod]
        public void CheckerCompareHandsFlushBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats P
        [TestMethod]
        public void CheckerCompareHandsFlushBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Flush beats HC
        [TestMethod]
        public void CheckerCompareHandsFlushBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {

                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //S beats S face
        [TestMethod]
        public void CheckerCompareHandsStraightBeatsStraightFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //S beats Set
        [TestMethod]
        public void CheckerCompareHandsStraightBeats3Kind()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //S beats 2p
        [TestMethod]
        public void CheckerCompareHandsStraightBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //S beats P
        [TestMethod]
        public void CheckerCompareHandsStraightBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //S beats HC
        [TestMethod]
        public void CheckerCompareHandsStraightBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats Set face
        [TestMethod]
        public void CheckerCompareHands3KindBeats3KindFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats Set Kicker1
        [TestMethod]
        public void CheckerCompareHands3KindBeats3KindKicker1()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats Set Kicker2
        [TestMethod]
        public void CheckerCompareHands3KindBeats3KindKicker2()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats 2p
        [TestMethod]
        public void CheckerCompareHands3KindBeats2Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats P
        [TestMethod]
        public void CheckerCompareHands3KindBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //Set beats HC
        [TestMethod]
        public void CheckerCompareHands3KindBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //2p beats 2p face1
        [TestMethod]
        public void CheckerCompareHands2PairBeats2PairFace1()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Six, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //2p beats 2p face2
        [TestMethod]
        public void CheckerCompareHands2PairBeats2PairFace2()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //2p beats 2p other
        [TestMethod]
        public void CheckerCompareHands2PairBeats2PairKicker()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //2p beats P
        [TestMethod]
        public void CheckerCompareHands2PairBeats1Pair()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //2p beats HC
        [TestMethod]
        public void CheckerCompareHands2PairBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //P beats P face
        [TestMethod]
        public void CheckerCompareHands1PairBeats1PairFace()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //P beats P other1
        [TestMethod]
        public void CheckerCompareHands1PairBeats1PairNext1()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //P beats P other2
        [TestMethod]
        public void CheckerCompareHands1PairBeats1PairNext2()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //P beats P other3
        [TestMethod]
        public void CheckerCompareHands1PairBeats1PairNext3()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //P beats HC
        [TestMethod]
        public void CheckerCompareHands1PairBeatsHighCard()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //HC beats HC other1
        [TestMethod]
        public void CheckerCompareHands1HighCardBeatsHighCard1()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //HC beats HC other2
        [TestMethod]
        public void CheckerCompareHands1HighCardBeatsHighCard2()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //HC beats HC other3
        [TestMethod]
        public void CheckerCompareHands1HighCardBeatsHighCard3()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }
        //HC beats HC other4
        [TestMethod]
        public void CheckerCompareHands1HighCardBeatsHighCard4()
        {
            var checker = new PokerHandsChecker();
            var testCards1 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testCards2 = new List<ICard>
            {
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts)
            };

            var testHand1 = new Hand(testCards1);
            var testHand2 = new Hand(testCards2);

            Assert.AreEqual(1, checker.CompareHands(testHand1, testHand2));
        }

    }
}
