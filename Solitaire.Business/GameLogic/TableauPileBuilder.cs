﻿namespace Solitaire.Business
{
    internal class TableauPileBuilder
    {
        private TableauPile tableauPile;
        private PackOfCards packOfCards;
        private int cardsInPile;

        public TableauPileBuilder()
        {
            this.tableauPile = new TableauPile();
        }

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
            for (int i = 0; i < this.cardsInPile; i++)
            {
                this.tableauPile.Cards.Add(this.packOfCards.DrawNextCard());
            }

            return this.tableauPile;
        }
    }
}