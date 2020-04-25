namespace Solitaire.Business
{
    public class Board
    {
        private readonly PackOfCards packOfCards;

        private const int numberOfTableauPiles = 7;

        public Board()
        {
            this.packOfCards = new PackOfCards();

            this.FoundationPiles = SetupFoundationPiles();
            this.TableauPiles = SetupTableauPiles();
            this.Stock = SetupStock();
        }

        public FoundationPile[] FoundationPiles { get; }
        public TableauPile[] TableauPiles { get; }
        public Stock Stock { get; }

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
