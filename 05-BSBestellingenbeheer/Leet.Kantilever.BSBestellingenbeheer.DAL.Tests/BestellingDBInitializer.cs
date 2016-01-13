using System;
using System.Data.Entity;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    class BestellingDBInitializer : DropCreateDatabaseAlways<BestellingContext>
    {
        protected override void Seed(BestellingContext context)
        {
            var bestelling = DummyDataDAL.GetBestelling();
            context.Bestellingen.Add(bestelling);
            base.Seed(context);
        }
    }
}