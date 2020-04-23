using Solitaire.Business;
using System;

namespace Solitaire
{
    class Program
    {
        static void Main()
        {
            var packOfCards = new PackOfCards();

            Card randomCard;
            for (int i = 0; i < 53; i++)
            {
                randomCard = packOfCards.DrawNextCard();
                if (randomCard.IsEmptyCard())
                {
                    Console.WriteLine("No cards available");
                }
                else
                {
                    Console.WriteLine(randomCard);
                }
            }

            Console.ReadLine();
        }
    }
}
