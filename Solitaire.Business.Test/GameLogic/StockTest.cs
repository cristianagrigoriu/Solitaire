using FluentAssertions;
using NUnit.Framework;
using System;

namespace Solitaire.Business.Test
{
    public class StockTest
    {
        private int numberOfCardsInOriginalPackOfCards;
        private Stock stock;

        [SetUp]
        public void Setup()
        {
            var packOfCards = new PackOfCards();
            this.numberOfCardsInOriginalPackOfCards = packOfCards.GetNumberOfAvailableCards();
            this.stock = new Stock(packOfCards);
        }

        [Test]
        public void When_stock_is_newly_created_Should_have_same_number_of_cards_as_the_given_pack_of_cards()
        {
            this.numberOfCardsInOriginalPackOfCards.Should().Be(this.stock.NumberOfFaceDownCards);
        }

        [Test]
        public void When_no_revealed_cards_Top_card_should_be_empty_card()
        {
            this.stock.TopCard.Should().Be(Card.EmptyCard);
        }

        [Test]
        public void When_no_revealed_cards_Cannot_remove_top_card()
        {
            Action act = () => this.stock.RemoveTopCard();
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
