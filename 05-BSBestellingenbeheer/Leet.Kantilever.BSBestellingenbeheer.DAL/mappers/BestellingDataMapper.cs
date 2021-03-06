﻿using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
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
            if (bestelling == null)
            {
                throw new ArgumentNullException(paramName:"bestelling");
            }

            using (var context = new BestellingContext())
            {
                context.Bestellingen.Add(bestelling);
                context.SaveChanges();

                bestelling.Bestelnummer = bestelling.ID;
                context.SaveChanges();
            }
        }
        
        public IEnumerable<Bestelling> Find(Func<Bestelling,bool> predicate)
        {
            using (var context = new BestellingContext())
            {
                return context.Bestellingen.Include(b => b.Bestellingsregels)
                                            .Where(predicate).ToList();
            }
        }

        public void Update(Bestelling bestelling)
        {
            using (var context = new BestellingContext())
            {
                bestelling.ID = context.Bestellingen.Single(b => b.Bestelnummer == bestelling.Bestelnummer).ID;
                var existing = context.Bestellingen.Single(b => bestelling.Bestelnummer == b.Bestelnummer);
                context.Entry(existing).CurrentValues.SetValues(bestelling);
                context.Entry(existing).State = EntityState.Modified;
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
                var bestelling = context.Bestellingen.Include(b =>b.Bestellingsregels).OrderBy(b => b.Besteldatum)
                                                                  .FirstOrDefault(b => b.Ingepakt == false);
                if(bestelling == null)
                {
                    throw new ArgumentException("Er zijn geen bestellingen meer die moeten worden ingepakt");
                }

                return bestelling;
            }
        }
    }
}
