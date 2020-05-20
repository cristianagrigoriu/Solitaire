namespace Solitaire.Business.Test.GameLogic
{
    using System.Collections.Generic;

    using FluentAssertions;

    using NUnit.Framework;

    public class TableauPileTest
    {
        private TableauPile tableauPile;

        //check order of cards when revealed
        [SetUp]
        public void Setup()
        {
            //this.tableauPile = new Tab 
        }

        [Test]
        public void Should_reveal_cards_in_correct_order_When_removing_cards_from_it()
        {
            var twoOfSpades = new Card(CardSuit.Spades, CardNumber.Two);
            var threeOfDiamonds = new Card(CardSuit.Diamonds, CardNumber.Three);
            var fourOfClubs = new Card(CardSuit.Clubs, CardNumber.Four);

            var cards = new List<Card> {twoOfSpades, threeOfDiamonds, fourOfClubs};

            this.tableauPile = new TableauPile(cards);

            var firstCardRevealed = this.tableauPile.TopFaceDownCard; //last card is revealed in ctor
            //var secondCardRevealed = this.tableauPile.TopFaceDownCard;
            //var thirdCardRevealed = this.tableauPile.TopFaceDownCard;

            firstCardRevealed.Should().Be(fourOfClubs);

        }

        //ToDo edge cases - pile is empty, want to move king, no more face up cards, no more face down cards
        //ToDo check one card is revealed
    }
}
