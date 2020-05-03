using System.Collections.Generic;

namespace Solitaire.Business
{
    using System.Linq;

    internal class TableauPile
    {
        private Stack<Card> revealedCards = new Stack<Card>();

        public Stack<Card> Cards { get; set; } = new Stack<Card>();

        public Card TopCard => this.Cards.Count == 0
            ? Card.EmptyCard
            : this.Cards.Peek();

        public void RemoveTopCard()
        {
            if (Equals(this.TopCard, Card.EmptyCard))
            {
                return;
            }

            this.revealedCards.Pop();

            if (!this.revealedCards.Any() && this.Cards.Any())
            {
                this.RevealTopCard();
            }
        }

        public void RevealTopCard()
        {
            this.revealedCards.Push(this.Cards.Pop());
        }
    }
}
