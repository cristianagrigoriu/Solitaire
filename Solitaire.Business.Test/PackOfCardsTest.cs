using FluentAssertions;
using NUnit.Framework;

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
        public void When_drawing_card_from_empty_pack_Should_return_joker_card()
        {
            //this.packOfCards.CreateEmptyPackOfCards();
            //var sut = this.packOfCards.DrawNextCard();

            //sut.IsEmptyCard().Should().BeTrue();
        }
    }
}