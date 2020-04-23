using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
            var drawnCards = new SortedList<Card, int>();

            Action act = () =>
            {
                for (int i = 0; i < 52; i++)
                {
                    drawnCards.Add(this.packOfCards.DrawNextCard(), i);
                }
            };

            act.Should().NotThrow<ArgumentException>();
        }
            

        [Test]
        public void When_drawing_card_from_empty_pack_Should_return_empty_card()
        {
            for (int i = 0; i < 52; i++)
            {
                this.packOfCards.DrawNextCard();
            }

            var sut = this.packOfCards.DrawNextCard();

            sut.Should().Be(Card.EmptyCard);
        }

        [Test]
        public void When_drawing_cards_Cards_should_be_random()
        {
            var secondPackOfCards = new PackOfCards();

            var drawnCardsFromFirstPack = new List<Card>();
            for (int i = 0; i < 3; i++)
            {
                drawnCardsFromFirstPack.Add(packOfCards.DrawNextCard());
            }

            var drawnCardsFromSecondPack = new List<Card>();
            for (int i = 0; i < 3; i++)
            {
                drawnCardsFromSecondPack.Add(secondPackOfCards.DrawNextCard());
            }

            drawnCardsFromFirstPack.Should().NotIntersectWith(drawnCardsFromSecondPack);
        }
    }
}