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

        public void MoveTopCardFromTableauPileToFoundationPile(int tableauPileNumber)
        {
            var tableauPile = this.TableauPiles[tableauPileNumber];
            var card = tableauPile.TopCard;

            var possibleFoundationPile = this.FoundationPiles.First(x => x.Suit == card.Suit);
            if (possibleFoundationPile.CanAdd(card))
            {
                tableauPile.RemoveTopCard();
                possibleFoundationPile.Add(card);
            }
        }

        public void MoveCardFromTableauPileToAnotherTableauPile(
            int numberOfCards, 
            int sourcePileNumber, 
            int destinationPileNumber)
        {
            var sourcePile = this.TableauPiles[sourcePileNumber];
            var destinationPile = this.TableauPiles[destinationPileNumber];

            destinationPile.ReceiveCardsFrom(sourcePile, numberOfCards);
        }
    }
}
