using FluentAssertions;

namespace Solitaire.Business.Test
{
    using NUnit.Framework;
    using Solitaire.Business.GameLogic;

    public class BoardTest
    {
        private Board board;

        [SetUp]
        public void Setup()
        {
            this.board = new BoardBuilder()
                .WithPackOfCards()
                .WithFoundationPiles()
                .WithTableauPiles()
                .WithStock()
                .Build();
        }

        [Test]
        public void When_starting_game_Foundation_piles_should_be_empty()
        {
            board.FoundationPiles.Should().HaveCount(4);

            foreach (var foundationPile in board.FoundationPiles)
            {
                foundationPile.Should().NotBeNull();
                foundationPile.Cards.Should().BeEmpty();
            }
        }

        [Test]
        public void When_starting_game_Foundation_piles_should_have_4_different_suits()
        {
            board.FoundationPiles[0].Suit.Should().Be(CardSuit.Diamonds);
            board.FoundationPiles[1].Suit.Should().Be(CardSuit.Hearts);
            board.FoundationPiles[2].Suit.Should().Be(CardSuit.Spades);
            board.FoundationPiles[3].Suit.Should().Be(CardSuit.Clubs);
        }

        [Test]
        public void When_starting_game_Tableau_piles_should_have_correct_number_of_dealt_cards()
        {
            board.TableauPiles.Should().HaveCount(7);

            board.TableauPiles[0].Cards.Should().HaveCount(1);
            board.TableauPiles[1].Cards.Should().HaveCount(2);
            board.TableauPiles[2].Cards.Should().HaveCount(3);
            board.TableauPiles[3].Cards.Should().HaveCount(4);
            board.TableauPiles[4].Cards.Should().HaveCount(5);
            board.TableauPiles[5].Cards.Should().HaveCount(6);
            board.TableauPiles[6].Cards.Should().HaveCount(7);
        }

        [Test]
        public void When_starting_game_Stock_should_have_24_cards()
        {
            board.Stock.GetNumberOfFaceDownCards().Should().Be(24);
        }
    }
}
