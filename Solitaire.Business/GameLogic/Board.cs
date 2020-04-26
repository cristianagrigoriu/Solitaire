using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Solitaire.Business.Test")]
namespace Solitaire.Business
{
    internal class Board
    {
        public FoundationPile[] FoundationPiles { get; set; }
        public TableauPile[] TableauPiles { get; set; }
        public Stock Stock { get; set; }
    }
}
