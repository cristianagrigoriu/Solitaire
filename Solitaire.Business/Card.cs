namespace Solitaire.Business
{
    public class Card
    {
        internal Card(CardSuit suit, CardNumber number)
        {
            this.Suit = suit;
            this.Number = number;
        }

        public CardSuit Suit { get; }

        public CardNumber Number { get; }
    }
}
