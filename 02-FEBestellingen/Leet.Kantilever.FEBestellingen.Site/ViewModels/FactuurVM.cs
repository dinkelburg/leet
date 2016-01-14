using minorcase3bsklantbeheer.v1.schema;
using minorcase3pcsbestellen.v1.schema;

namespace Leet.Kantilever.FEBestellingen.Site.ViewModels
{
    public class FactuurVM
    {
        public BestellingVM Bestelling { get; set; }
        public Klant Klant { get; set; }
    }
}