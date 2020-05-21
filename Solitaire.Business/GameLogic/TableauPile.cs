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
            this.TurnCardFaceUp();
        }

        internal TableauPile() { }

        public Stack<Card> FaceDownCards { get; set; } = new Stack<Card>();

        //should not be possible to have empty face up card and still some face down cards
        public Card TopFaceUpCard => 
            this.faceUpCards.Count == 0 
            ? Card.EmptyCard
            : this.faceUpCards.TopCard;

        public bool CanAddPileOfCards(IEnumerable<Card> pileOfCards)
            => this.faceUpCards.CanAddPileOfCards(pileOfCards);

        //ToDo these are not top cards, they are the accessible cards, the ones you can touch

        //ToDO should return removed card?
        public void RemoveTopCard()
        {
            if (Equals(this.TopFaceUpCard, Card.EmptyCard))
            {
                return;
            }

            this.faceUpCards.RemoveTopCard();

            if (this.faceUpCards.IsEmpty() && this.FaceDownCards.Any())
            {
                this.TurnCardFaceUp();
            }
        }

        public int Count => this.FaceDownCards.Count + this.faceUpCards.Count;

        public void ReceiveCardsFrom(TableauPile fromPile, int numberOfCards)
        {
            fromPile.faceUpCards.ReceiveCardsFrom(fromPile.faceUpCards, numberOfCards);
        }

        private void TurnCardFaceUp()
        {
            if (this.FaceDownCards.Any())
            {
                this.faceUpCards.Add(this.FaceDownCards.Pop());
            }
        }
    }
}
