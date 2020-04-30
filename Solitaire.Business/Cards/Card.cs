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

        public static Card EmptyCard => new Card(0,0);

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Card))
            {
                return false;
            }

            var cardToCompare = (Card)obj;

            return cardToCompare.Number == this.Number
                && cardToCompare.Suit == this.Suit;
        }

        public override string ToString()
        {
            return $"{this.Number} of {this.Suit}";
        }

        public bool IsAfter(Card possibleNextCard)
        {
            if (this.Suit != possibleNextCard.Suit)
            {
                return false;
            }

            return this.Number == possibleNextCard.Number + 1;
        }
    }
}
