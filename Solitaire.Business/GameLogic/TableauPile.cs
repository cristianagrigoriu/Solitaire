using System.Collections.Generic;

namespace Solitaire.Business
{
    using Solitaire.Business.GameLogic;
    using System;
    using System.Linq;

    internal class TableauPile
    {
        private TableauPileFaceUpCards faceUpCards = new TableauPileFaceUpCards();

        public TableauPile(IEnumerable<Card> cards)
        {
            this.FaceDownCards = new Stack<Card>(cards);
            this.RevealTopCard();
        }

        internal TableauPile() { }

        public Stack<Card> FaceDownCards { get; set; } = new Stack<Card>();

        public Card TopCard => this.FaceDownCards.Count == 0
            ? Card.EmptyCard
            : this.FaceDownCards.Peek();

        public void RemoveTopCard()
        {
            if (Equals(this.TopCard, Card.EmptyCard))
            {
                return;
            }

            this.faceUpCards.RemoveTopCard();

            if (!this.faceUpCards.IsEmpty() && this.FaceDownCards.Any())
            {
                this.RevealTopCard();
            }
        }

        public void RevealTopCard()
        {
            //check if any face down cards
            this.faceUpCards.Add(this.FaceDownCards.Pop());
        }

        public int Count => this.FaceDownCards.Count + this.faceUpCards.Count;

        public void ReceiveCardsFrom(TableauPile fromPile, int numberOfCards)
        {
            fromPile.faceUpCards.ReceiveCardsFrom(fromPile.faceUpCards, numberOfCards);
        }
    }
}
