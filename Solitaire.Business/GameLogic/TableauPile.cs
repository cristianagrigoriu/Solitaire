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

        public Card TopFaceDownCard => this.FaceDownCards.Count == 0 //ToDo maybe should reconsider name
            ? Card.EmptyCard
            : this.FaceDownCards.Peek();

        //ToDo these are not top cards, they are the accessible cards, the ones you can touch

        public void RemoveTopCard()
        {
            if (Equals(this.TopFaceDownCard, Card.EmptyCard))
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
