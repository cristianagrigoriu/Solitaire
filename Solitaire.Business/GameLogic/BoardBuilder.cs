namespace Solitaire.Business.GameLogic
{
    internal class BoardBuilder
    {
        private PackOfCards packOfCards;
        private FoundationPile[] foundationPiles;
        private TableauPile[] tableauPiles;
        private Stock stock;

        private const int numberOfTableauPiles = 7;

        public BoardBuilder WithPackOfCards()
        {
            this.packOfCards = new PackOfCards();
            return this;
        }

        public BoardBuilder WithFoundationPiles()
        {
            this.foundationPiles = new[]
            {
                new FoundationPile(CardSuit.Diamonds),
                new FoundationPile(CardSuit.Hearts),
                new FoundationPile(CardSuit.Spades),
                new FoundationPile(CardSuit.Clubs)
            };

            return this;
        }

        public BoardBuilder WithTableauPiles()
        {
            this.tableauPiles = new TableauPile[numberOfTableauPiles];

            for (int i = 0; i < numberOfTableauPiles; i++)
            {
                this.tableauPiles[i] = new TableauPileBuilder()
                    .WithPack(this.packOfCards)
                    .WithCards(i + 1)
                    .Build();
            }
            return this;
        }

        public BoardBuilder WithStock()
        {
            this.stock = new Stock(this.packOfCards);
            return this;
        }

        public Board Build()
        {
            return new Board
            {
                FoundationPiles = this.foundationPiles,
                TableauPiles = this.tableauPiles,
                Stock = this.stock
            };
        }
    }
}
