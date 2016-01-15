using System;
using System.Data.Entity;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.Tests
{
    class BestellingDBInitializer : DropCreateDatabaseAlways<BestellingContext>
    {
        protected override void Seed(BestellingContext context)
        {
            var bestelling = DummyDataDAL.GetBestelling();
            var bestellingen = DummyDataDAL.GetDummyBestellingen();

            context.Bestellingen.Add(bestelling);
            context.Bestellingen.AddRange(bestellingen);

            base.Seed(context);
        }
    }
}