using FluentAssertions;

namespace Solitaire.Business.Test
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    public class BoardTest
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            board = new Board();
        }

        [Test]
        public void When_starting_game_Foundation_piles_should_be_empty()
        {
            board.FoundationPiles.Should().HaveCount(4);

            foreach (var foundationPile in board.FoundationPiles)
            {
                foundationPile.Should().NotBeNull();
            }
        }

        [Test]
        public void When_starting_game_Foundation_piles_should_have_4_different_suits()
        {
            var allPossibleSuits = Enum.GetValues(typeof(CardSuit));

            board.FoundationPiles[0].Suit.Should().Be(allPossibleSuits);
        }
    }
}
