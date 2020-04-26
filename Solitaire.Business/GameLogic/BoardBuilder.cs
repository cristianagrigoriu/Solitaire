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
            this.foundationPiles = SetupFoundationPiles();
            return this;
        }

        public BoardBuilder WithTableauPiles()
        {
            this.tableauPiles = SetupTableauPiles();
            return this;
        }

        public BoardBuilder WithStock()
        {
            this.stock = SetupStock();
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

        private FoundationPile[] SetupFoundationPiles()
        {
            return new[]
            {
                new FoundationPile(CardSuit.Diamonds),
                new FoundationPile(CardSuit.Hearts),
                new FoundationPile(CardSuit.Spades),
                new FoundationPile(CardSuit.Clubs)
            };
        }

        private TableauPile[] SetupTableauPiles()
        {
            var setupTableauPiles = new TableauPile[numberOfTableauPiles];

            for (int i = 0; i < numberOfTableauPiles; i++)
            {
                setupTableauPiles[i] = new TableauPileBuilder()
                    .WithPack(this.packOfCards)
                    .WithCards(i + 1)
                    .Build();
            }

            return setupTableauPiles;
        }

        private Stock SetupStock()
        {
            return new Stock(this.packOfCards);
        }
    }
}
