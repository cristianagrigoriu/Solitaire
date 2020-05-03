namespace Solitaire.Business
{
    using System.Collections.Generic;

    internal class Stock
    {
        private Stack<Card> faceDownCards;
        private Stack<Card> faceUpCards = new Stack<Card>();

        public Stock(PackOfCards packOfCards)
        {
            this.faceDownCards = new Stack<Card>(packOfCards.DrawAllRemainingCards());
        }

        //ToDo stack/heap of cards
        public void RevealTopCard()
        {
            var topCard = this.faceDownCards.Pop();
            this.faceUpCards.Push(topCard);
        }

        public Card TopCard => 
                    this.faceUpCards.Count == 0
                        ? Card.EmptyCard
                        : this.faceUpCards.Peek();

        public void RemoveTopCard()
        {
            this.faceUpCards.Pop();
        }

        public int GetNumberOfFaceDownCards() => this.faceDownCards.Count;
    }
}
