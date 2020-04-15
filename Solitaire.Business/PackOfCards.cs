using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Business
{
    public class PackOfCards
    {
        private List<Card> availableCards = CreatePackOfCards().ToList();
        private List<Card> drawnCards = new List<Card>();
        private static Random randomNumber = new Random();

        public PackOfCards()
        {
            //availableCards = CreatePackOfCards().ToList();
        }

        public void Shuffle()
        {
            if (this.availableCards == null || this.availableCards.Count == 0)
            {
                return;
            }

            int numberOfUnshuffledCards = this.availableCards.Count;

            while (numberOfUnshuffledCards > 1)
            {
                numberOfUnshuffledCards--;

                int randomPosition = randomNumber.Next(numberOfUnshuffledCards + 1);
                this.SwapCardsBetween(numberOfUnshuffledCards, randomPosition);
            }
        }

        public Card DrawRandomCard()
        {
            //ToDo generat random aici sau la nivel de clasa?
            //return empty card when pack is null
            if (this.availableCards == null || this.availableCards.Count == 0)
            {
                return Card.JokerCard;
            }

            int drawnCardPosition = new Random().Next(0, this.availableCards.Count);

            var drawnCard = availableCards[drawnCardPosition];

            availableCards.RemoveAt(drawnCardPosition);
            drawnCards.Add(drawnCard);

            return drawnCard;
        }

        //get new pack -> factory
        public static IEnumerable<Card> CreatePackOfCards()
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

        public void CreateEmptyPackOfCards()
        {
            this.availableCards = new List<Card>();
        }

        private void SwapCardsBetween(int initialPosition, int randomPosition)
        {
            var initialCard = this.availableCards[randomPosition];
            this.availableCards[randomPosition] = this.availableCards[initialPosition];
            this.availableCards[initialPosition] = initialCard;
        }

        public override string ToString()
        {
            return //string.Join("\n", this.availableCards)
            this.availableCards?
                .Select((card, index) => $"{index + 1} {card}")
                .Aggregate((a, b) => $"{a}\n{b}");
        }
    }
}
