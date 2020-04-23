using System.Collections.Generic;

namespace Solitaire.Business
{
    public class Board
    {
        public FoundationPile[] FoundationPiles { get; }

        public Board()
        {
            this.FoundationPiles = new[]
            {
                new FoundationPile(), 
                new FoundationPile(), 
                new FoundationPile(), 
                new FoundationPile() 
            };
        }
    }
}
