namespace Solitaire.Business
{
    internal class Stock
    {
        public Stock(PackOfCards packOfCards)
        {
            this.PackOfCards = packOfCards;
        }

        public PackOfCards PackOfCards { get; }
    }
}
