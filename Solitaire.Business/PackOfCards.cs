using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Business
{
    public class PackOfCards
    {
        private List<Card> availableCards;
        private List<Card> drawnCards = new List<Card>();
        private static Random randomNumber = new Random();

        public PackOfCards()
        {
            availableCards = CardsFactory.GetShuffledCards().ToList();
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

        public override string ToString()
        {
            return //string.Join("\n", this.availableCards)
            this.availableCards?
                .Select((card, index) => $"{index + 1} {card}")
                .Aggregate((a, b) => $"{a}\n{b}");
        }
    }
}
