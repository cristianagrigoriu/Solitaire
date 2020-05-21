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

        public int Count => this.faceUpCards.Count;

        public Card TopCard => this.faceUpCards.Last();

        public void Add(Card card)
        {
            //ToDo check if list empty
            this.faceUpCards.Add(card);
        }

        public void RemoveTopCard()
        {
            this.faceUpCards.RemoveAt(this.faceUpCards.Count - 1);
        }

        public bool IsEmpty()
        {
            return this.faceUpCards.Count == 0;
        }

        private IEnumerable<Card> GetCards(int numberOfCards) //test if number of cards bigger than list count
        {
            return this.faceUpCards.TakeLast(numberOfCards);
        }

        public bool CanAddPileOfCards(IEnumerable<Card> pileOfCards)
        {
            if (this.IsEmpty())
            {
                return pileOfCards.First().Number == CardNumber.King;
            }

            var currentTopCard = this.faceUpCards.Last(); //current top card e cartea cea mai de jos din pile
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