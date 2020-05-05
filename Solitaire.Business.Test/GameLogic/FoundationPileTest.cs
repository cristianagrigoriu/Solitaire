namespace Solitaire.Business.Test
{
    using FluentAssertions;
    using NUnit.Framework;
    using Solitaire.Business;
    using System;

    public class FoundationPileTest
    {
        private FoundationPile foundationPile;

        [SetUp]
        public void Setup()
        {
            this.foundationPile = new FoundationPile(CardSuit.Clubs);
        }

        [Test]
        public void When_pile_is_empty_Can_add_only_ace_of_right_suit()
        {
            var aceOfClubs = new Card(CardSuit.Clubs, CardNumber.Ace);
            var aceOfHearts = new Card(CardSuit.Hearts, CardNumber.Ace);
            var twoOfClubs = new Card(CardSuit.Clubs, CardNumber.Two);

            this.foundationPile.CanAdd(aceOfClubs).Should().BeTrue();
            this.foundationPile.CanAdd(aceOfHearts).Should().BeFalse();
            this.foundationPile.CanAdd(twoOfClubs).Should().BeFalse();
        }

        [Test]
        public void When_pile_is_empty_and_ace_is_added_Pile_count_increases()
        {
            var aceOfClubs = new Card(CardSuit.Clubs, CardNumber.Ace);

            this.foundationPile.Add(aceOfClubs);
            this.foundationPile.Count.Should().Be(1);
        }

        [Test]
        public void When_pile_is_full_Cannot_add_anymore_cards()
        {
            var numbers = Enum.GetValues(typeof(CardNumber));
            foreach (CardNumber number in numbers)
            {
                this.foundationPile.Add(new Card(CardSuit.Clubs, number));
            }

            var kingOfHearts = new Card(CardSuit.Hearts, CardNumber.King);

            this.foundationPile.CanAdd(kingOfHearts).Should().BeFalse();
        }

        [Test]
        public void Cannot_add_same_card_twice()
        {
            var aceOfClubs = new Card(CardSuit.Clubs, CardNumber.Ace);

            this.foundationPile.Add(aceOfClubs);
            this.foundationPile.CanAdd(aceOfClubs).Should().BeFalse();
        }
    }
}
