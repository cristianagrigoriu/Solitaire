using System.Collections.Generic;

namespace Solitaire.Business
{
    internal class TableauPileBuilder
    {
        private TableauPile tableauPile;
        private PackOfCards packOfCards;
        private int cardsInPile;

        public TableauPileBuilder WithPack(PackOfCards packOfCards)
        {
            this.packOfCards = packOfCards;
            return this;
        }

        public TableauPileBuilder WithCards(int cardsInPile)
        {
            this.cardsInPile = cardsInPile; 
            return this;
        }

        public TableauPile Build()
        {
            var cardsForPile = new List<Card>();

            for (int i = 0; i < this.cardsInPile; i++)
            {
                cardsForPile.Add(this.packOfCards.DrawNextCard());
            }

            this.tableauPile = new TableauPile(cardsForPile);

            return this.tableauPile;
        }
    }
}