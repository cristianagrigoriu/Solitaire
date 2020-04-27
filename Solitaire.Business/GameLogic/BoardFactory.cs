namespace Solitaire.Business.GameLogic
{
    internal static class BoardFactory
    {
        public static Board GetSetupBoard()
        {
            return new BoardBuilder()
                .WithPackOfCards()
                .WithFoundationPiles()
                .WithTableauPiles()
                .WithStock()
                .Build();
        }
    }
}
