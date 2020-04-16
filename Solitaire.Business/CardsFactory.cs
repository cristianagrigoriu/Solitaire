namespace Solitaire.Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class CardsFactory
    {

        public static IEnumerable<Card> GetShuffledCards()
        {
            return CreateAllAvailableCards().Shuffle();
        }

        private static IEnumerable<Card> CreateAllAvailableCards()
        {
            var suits = Enum.GetValues(typeof(CardSuit));
            var numbers = Enum.GetValues(typeof(CardNumber));

            foreach (CardSuit suit in suits)
            {
                foreach (CardNumber number in numbers)
                {
                    yield return new Card(suit, number);
                }
            }
        }

        private static IEnumerable<Card> Shuffle(this IEnumerable<Card> cards)
        {
            var availableCards = cards.ToList();

            while (availableCards.Any())
            {
                //ToDo random -> count - 1?
                var randomCardPosition = new Random().Next(availableCards.Count + 1);

                yield return availableCards[randomCardPosition];
                availableCards.RemoveAt(randomCardPosition);
            }
        }

        private static List<Card> Shuffle2(this List<Card> availableCards)
        {
            int numberOfUnshuffledCards = availableCards.Count;

            while (numberOfUnshuffledCards > 1)
            {
                numberOfUnshuffledCards--;

                int randomPosition = new Random().Next(numberOfUnshuffledCards + 1);
                SwapCardsBetween(numberOfUnshuffledCards, randomPosition, availableCards);
            }

            return availableCards;
        }

        private static void SwapCardsBetween(int initialPosition, int randomPosition, List<Card> availableCards)
        {
            var initialCard = availableCards[randomPosition];
            availableCards[randomPosition] = availableCards[initialPosition];
            availableCards[initialPosition] = initialCard;
        }
    }
}