using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Solitaire.Business.Test")]
namespace Solitaire.Business
{
    using System.Linq;

    internal class Board
    {
        public FoundationPile[] FoundationPiles { get; internal set; }
        public TableauPile[] TableauPiles { get; internal set; }
        public Stock Stock { get; internal set; }

        public void MoveCardFromStockToFoundationPile()
        {
            var cardFromStock = this.Stock.TopCard;
            var possibleFoundationPile = this.FoundationPiles.First(x => x.Suit == cardFromStock.Suit);

            if (possibleFoundationPile.CanAdd(cardFromStock))
            {
                this.Stock.RemoveTopCard();
                possibleFoundationPile.Add(cardFromStock);
            }
        }

        public void MoveSelectedCardToFoundationPile(Card selectedCard)
        {

        }

        public void MoveFromTableauPileToAnotherTableauPile(
            List<Card> selectedCards, 
            TableauPile sourcePile, 
            TableauPile destinationPile)
        {

        }
    }
}
