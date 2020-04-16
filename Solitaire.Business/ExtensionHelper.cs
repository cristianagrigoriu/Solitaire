namespace Solitaire.Business
{
    public static class ExtensionHelper
    {
        public static bool IsEmptyCard(this Card card)
        {
            return card.Suit == 0 && card.Number == 0;
        }
    }
}
