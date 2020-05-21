namespace Solitaire.Business.Test.GameLogic
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    using NUnit.Framework;
    using Solitaire.Business;

    public class TableauPileTest
    {
        private TableauPile tableauPile;
        private Card twoOfSpades;
        private Card threeOfDiamonds;
        private Card fourOfClubs;
        private List<Card> cards;

        [SetUp]
        public void Setup()
        {
            this.twoOfSpades = new Card(CardSuit.Spades, CardNumber.Two);
            this.threeOfDiamonds = new Card(CardSuit.Diamonds, CardNumber.Three);
            this.fourOfClubs = new Card(CardSuit.Clubs, CardNumber.Four);

            this.cards = new List<Card> { twoOfSpades, threeOfDiamonds, fourOfClubs };
        }

        [Test]
        public void Should_have_card_face_up_When_creating_pile_of_one()
        {
            this.tableauPile = this.GetCustomPileOf(1);

            this.tableauPile.TopFaceUpCard.Should().Be(twoOfSpades);
            this.tableauPile.Count.Should().Be(1);
        }

        [Test]
        public void Should_reveal_cards_in_correct_order_When_removing_cards_from_it()
        {
            this.tableauPile = this.GetCustomPileOf(3);

            var firstCardRevealed = this.tableauPile.TopFaceUpCard;
            this.tableauPile.RemoveTopCard();

            var secondCardRevealed = this.tableauPile.TopFaceUpCard;
            this.tableauPile.RemoveTopCard();

            var thirdCardRevealed = this.tableauPile.TopFaceUpCard;
            this.tableauPile.RemoveTopCard();

            firstCardRevealed.Should().Be(this.fourOfClubs);
            secondCardRevealed.Should().Be(this.threeOfDiamonds);
            thirdCardRevealed.Should().Be(this.twoOfSpades);
        }

        [Test]
        public void Should_receive_empty_card_When_pack_is_empty()
        {
            this.tableauPile = this.GetCustomPileOf(2);

            this.tableauPile.RemoveTopCard();
            this.tableauPile.RemoveTopCard();

            this.tableauPile.TopFaceUpCard.Should().Be(Card.EmptyCard);
        }

        [Test]
        public void Should_remove_exactly_one_card_When_removing_top_card()
        {
            this.tableauPile = this.GetCustomPileOf(3);

            var sizeBeforeReveal = this.tableauPile.Count;

            this.tableauPile.RemoveTopCard();

            var sizeAfterReveal = this.tableauPile.Count;

            sizeBeforeReveal.Should().Be(sizeAfterReveal + 1);
        }

        #region Receiving cards

        [Test]
        public void Should_be_able_to_add_only_correct_card_When_trying_to_add()
        {
            var tenOfSpades = new Card(CardSuit.Spades, CardNumber.Ten);
            this.tableauPile = new TableauPile(new List<Card> { tenOfSpades });

            var nineOfHearts = new Card(CardSuit.Hearts, CardNumber.Nine);
            var nineOfDiamonds = new Card(CardSuit.Diamonds, CardNumber.Nine);
            var nineOfSpades = new Card(CardSuit.Spades, CardNumber.Nine);
            var nineOfClubs = new Card(CardSuit.Clubs, CardNumber.Nine);

            this.tableauPile.CanAddPileOfCards(new List<Card> { nineOfHearts }).Should().BeTrue();
            this.tableauPile.CanAddPileOfCards(new List<Card> { nineOfDiamonds }).Should().BeTrue();
            this.tableauPile.CanAddPileOfCards(new List<Card> { nineOfSpades }).Should().BeFalse();
            this.tableauPile.CanAddPileOfCards(new List<Card> { nineOfClubs }).Should().BeFalse();
        }

        #endregion

        private TableauPile GetCustomPileOf(int numberOfCards)
        {
            if (numberOfCards > this.cards.Count || numberOfCards <= 0)
            {
                return null;
            }

            return new TableauPile(this.cards.Take(numberOfCards));
        }
    }
}
