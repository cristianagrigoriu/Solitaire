using System.Collections.Generic;

namespace Solitaire.Business
{
    internal class FoundationPile
    {
        public FoundationPile(CardSuit cardSuit)
        {
            this.Suit = cardSuit;
            this.Cards = new Stack<Card>();
        }

        public bool CanAdd(Card card)
        {
            if (!this.Cards.TryPeek(out var topCard))
            {
                return card.Suit == this.Suit
                       && card.Number == CardNumber.Ace;
            }

            return card.IsAfter(topCard);
        }

        public CardSuit Suit { get; }

        public Stack<Card> Cards { get; }

        public void Add(Card card)
        {
            this.Cards.Push(card);
        }

        public int Count => this.Cards.Count;
    }
}
