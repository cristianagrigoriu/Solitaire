using System.Collections.Generic;

namespace Solitaire.Business
{
    using System;
    using System.Linq;

    internal class TableauPile
    {
        private Stack<Card> faceUpCards = new Stack<Card>();

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

            this.faceUpCards.Pop();

            if (!this.faceUpCards.Any() && this.FaceDownCards.Any())
            {
                this.RevealTopCard();
            }
        }

        public void RevealTopCard()
        {
            this.faceUpCards.Push(this.FaceDownCards.Pop());
        }

        public int Count => this.FaceDownCards.Count + this.faceUpCards.Count;

        public Stack<Card> GetTopCards(int numberOfCards)
        {
            if (numberOfCards > this.faceUpCards.Count || this.Count == 0)
            {
                var emptyStack = new Stack<Card>();
                emptyStack.Push(Card.EmptyCard);
                return emptyStack;
            }

            var topCards = new Stack<Card>();
            var allFaceUpCards = new Stack<Card>(this.faceUpCards);
            //allFaceUpCards.Aggregate((x, y) => y.IsAfterComplementary(x));

            for (int i = 0; i < numberOfCards; i++)
            {
                if (!topCards.TryPeek(out var formerTopCard))
                {
                    topCards.Push(formerTopCard);
                }

                //check if sequence

                topCards.Push(allFaceUpCards.Pop());

            }

            return new Stack<Card>();
        }
    }
}
