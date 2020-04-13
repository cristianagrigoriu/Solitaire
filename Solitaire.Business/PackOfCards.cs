using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Business
{
    public class PackOfCards
    {
        private List<Card> availableCards;
        private List<Card> drawnCards = new List<Card>();


        public PackOfCards()
        {
            availableCards = this.GetPackOfCards().ToList();
        }

        public Card DrawRandomCard()
        {
            //ToDo generat random aici sau la nivel de clasa?
            // check available cards
            //return empty card when pack is null
            int drawnCardPosition = new Random().Next(0, this.availableCards.Count);

            var drawnCard = availableCards[drawnCardPosition];

            availableCards.RemoveAt(drawnCardPosition);
            drawnCards.Add(drawnCard);

            return drawnCard;
        }

        //shuffle
        //get new pack -> factory
        private IEnumerable<Card> GetPackOfCards()
        {
            var suits = Enum.GetValues(typeof(CardSuit));
            var numbers = Enum.GetValues(typeof(CardNumber));

            foreach(CardSuit suit in suits)
            {
                foreach(CardNumber number in numbers)
                {
                    yield return new Card(suit, number);
                }
            }
        }
    }
}
