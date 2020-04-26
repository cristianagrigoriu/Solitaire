using System.Collections.Generic;

namespace Solitaire.Business
{
    internal class FoundationPile
    {
        public FoundationPile(CardSuit cardSuit)
        {
            this.Suit = cardSuit;
            this.Cards = new List<Card>();
        }

        public CardSuit Suit { get; }

        public List<Card> Cards { get; }
    }
}
