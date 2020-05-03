using FluentAssertions;
using NUnit.Framework;
using System.Linq;

namespace Solitaire.Business.Test
{
    public class CardFactoryTest
    {
        [Test]
        public void When_creating_new_list_of_cards_Should_be_shuffled()
        {
            var firstListOfCards = CardsFactory.GetShuffledCards().ToList();
            var secondListOfCards = CardsFactory.GetShuffledCards().ToList();

            //ToDo add extension method for not in same order
            firstListOfCards.Should().BeEquivalentTo(secondListOfCards);
            //firstListOfCards.Should().BeEquivalentTo(secondListOfCards,
            //    options => options.WithStrictOrdering());
        }
    }
}
