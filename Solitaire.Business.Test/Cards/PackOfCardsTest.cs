using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace Solitaire.Business.Test
{
    public class PackOfCardsTests
    {
        private PackOfCards packOfCards;

        [SetUp]
        public void Setup()
        {
            packOfCards = new PackOfCards();
        }

        [Test]
        public void When_drawing_cards_Should_draw_52_different_cards()
        {
            Action act = () => this.packOfCards.DrawAllCards().ToDictionary(k => k.ToString());

            act.Should().NotThrow<ArgumentException>();
        }
            

        [Test]
        public void When_drawing_card_from_empty_pack_Should_return_empty_card()
        {
            this.packOfCards.DrawAllCards().ToList();

            var sut = this.packOfCards.DrawNextCard();

            sut.Should().Be(Card.EmptyCard);
        }

        [Test]
        public void When_drawing_cards_Cards_should_be_random()
        {
            var drawnCardsFromFirstPack = this.packOfCards.DrawNextCards(3);

            var secondPackOfCards = new PackOfCards();
            var drawnCardsFromSecondPack = secondPackOfCards.DrawNextCards(3);

            drawnCardsFromFirstPack.Should().NotIntersectWith(drawnCardsFromSecondPack);
        }
    }
}