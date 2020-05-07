using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitaire.Business.GameLogic
{
    public class TableauPileFaceUpCards
    {
        private List<Card> faceUpCards = new List<Card>();

        public void ReceiveCardsFrom(TableauPileFaceUpCards fromPile, int numberOfCards)
        {
            var cardsToBeMoved = fromPile.GetCards(numberOfCards);
            if (this.CanAddPileOfCards(cardsToBeMoved))
            {
                this.AddPileOfCards(cardsToBeMoved);
                fromPile.RemovePileOfCards(numberOfCards);
            }
        }

        public void Add(Card card)
        {
            //ToDo check if list empty
            this.faceUpCards.Add(card);
        }

        private IEnumerable<Card> GetCards(int numberOfCards) //test if number of cards bigger than list count
        {
            return this.faceUpCards.TakeLast(numberOfCards);
        }

        private bool CanAddPileOfCards(IEnumerable<Card> pileOfCards)
        {
            //ToDo if destination pile empty, check if King
            var currentTopCard = this.faceUpCards.Last();
            return currentTopCard.IsAfterComplementary(pileOfCards.First());
        }

        private void AddPileOfCards(IEnumerable<Card> pileOfCards)
        {
            this.faceUpCards.AddRange(pileOfCards);
        }

        private void RemovePileOfCards(int numberOfCards)
        {
            this.faceUpCards.RemoveRange(this.faceUpCards.Count - numberOfCards, numberOfCards);
        }
    }
}