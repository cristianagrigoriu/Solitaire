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

        public static Card JokerCard => new Card(0,0);
        
        public override string ToString()
        {
            return $"{this.Number} of {this.Suit}";
        }
    }
}
