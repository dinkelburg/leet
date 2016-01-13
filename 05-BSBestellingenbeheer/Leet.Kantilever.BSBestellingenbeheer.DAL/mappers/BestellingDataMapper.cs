using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mappers
{
    class BestellingDataMapper :IBestellingMapper<Bestelling>
    {
        public void AddBestelling(Bestelling bestelling)
        {
            using (var context = new BestellingContext)
            {
                context.Bestellingen.Add(bestelling);
                context.SaveChanges();
            }
        }

        public IEnumerable<Bestelling> FindAll()
        {
            using (var context = new BestellingContext())
            {
                return context.Bestellingen.ToList();
            }
        }

        public Bestelling FindBestellingByID(int bestellingID)
        {
            using (var context = new BestellingContext())
            {
                return context.Bestellingen
                    .Include(Bestellingen => Bestellingen.Bestellingsregels)
                    .SingleOrDefault(bestelling => bestelling.ID == bestellingID);
            }
        }

    }
}
