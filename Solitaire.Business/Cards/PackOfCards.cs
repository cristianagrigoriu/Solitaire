﻿using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Business
{
    public class PackOfCards
    {
        private readonly List<Card> availableCards;
        private readonly List<Card> drawnCards = new List<Card>();

        public PackOfCards()
        {
            availableCards = CardsFactory.GetShuffledCards().ToList();
        }

        public Card DrawNextCard()
        {
            if (this.availableCards.Count == 0)
            {
                return Card.EmptyCard;
            }

            var drawnCard = availableCards.First();

            availableCards.RemoveAt(0);
            drawnCards.Add(drawnCard);

            return drawnCard;
        }

        public int GetNumberOfAvailableCards()
        {
            return this.availableCards.Count();
        }

        public override string ToString()
        {
            return
            this.availableCards?
                .Select((card, index) => $"{index + 1} {card}")
                .Aggregate((a, b) => $"{a}\n{b}");
        }
    }
}