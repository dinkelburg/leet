using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mappers
{
    public class BestellingDataMapper : IBestellingMapper<Bestelling>
    {
        public void AddBestelling(Bestelling bestelling)
        {
            using (var context = new BestellingContext())
            {
                context.Bestellingen.Add(bestelling);
                context.SaveChanges();
            }
        }

        public void Update(Bestelling bestelling)
        {
            using (var context = new BestellingContext())
            {
                var existing = context.Bestellingen.Find(bestelling.ID);
                context.Entry(existing).CurrentValues.SetValues(bestelling);
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

        public Bestelling FindVolgendeOpenBestelling()
        {
            using (var context = new BestellingContext())
            {
                return context.Bestellingen.Include(b =>b.Bestellingsregels).OrderBy(bestelling => bestelling.Besteldatum)
                                                                  .FirstOrDefault(bestelling => bestelling.Ingepakt == false);
            }
        }
    }
}
