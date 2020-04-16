using Solitaire.Business;
using System;

namespace Solitaire
{
    class Program
    {
        static void Main(string[] args)
        {
            var packOfCards = new PackOfCards();
            //PackOfCards.CreatePackOfCards();
            //packOfCards.Shuffle();

            Card randomCard;
            for (int i = 0; i < 53; i++)
            {
                randomCard = packOfCards.DrawRandomCard();
                if (randomCard.IsJoker())
                {
                    Console.WriteLine("No cards available");
                }
                else
                {
                    Console.WriteLine(randomCard);
                }
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    packOfCards.Shuffle();
            //    Console.WriteLine(packOfCards);
            //}

                Console.ReadLine();
        }
    }
}
