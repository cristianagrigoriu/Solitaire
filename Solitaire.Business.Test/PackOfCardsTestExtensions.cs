using System.Collections.Generic;

namespace Solitaire.Business.Test
{
    internal static class PackOfCardsTestExtensions 
    {
        public static IEnumerable<Card> DrawNextCards(this PackOfCards packOfCards, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return packOfCards.DrawNextCard();
            }
        }

        public static IEnumerable<Card> DrawAllCards(this PackOfCards packOfCards)
        {
            return packOfCards.DrawNextCards(52);
        }
    }
}