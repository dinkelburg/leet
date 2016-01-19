using System;
using System.Collections.Generic;
using System.Linq;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using Leet.Kantilever.BSKlantbeheer.DAL.Converters;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Data.Entity.Validation;
using Leet.Kantilever.BSKlantbeheer.DAL.Exceptions;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Mappers
{
    public class KlantDataMapper
    {
        public ICollection<Klant> GetAllKlanten()
        {
            using (var context = new KlantenContext())
            {
                List<Klant> result = new List<Klant>();
                var klanten = context.Klanten.ToList().Select(EntityToDTO.ConvertKlant) ;
                result.AddRange(klanten);
                return result;
            }
        }

        public void InsertKlant(Klant klant)
        {
            using (var context = new KlantenContext())
            {
                try
                {
                    var existingKlant = context.Klanten.SingleOrDefault(k => k.Klantnummer == klant.Klantnummer);
                    if(existingKlant == null)
                    {
                        context.Klanten.Add(DTOToEntity.ConvertKlant(klant));
                        context.SaveChanges();
                    }
                }
                catch(DbEntityValidationException e)
                {
                    throw new FunctionalException("De meegegeven gegevens waren niet geldig.");
                }
                catch(DbUpdateException)
                {
                    throw new FunctionalException("De meegegeven gegevens waren niet geldig.");
                }
            }
        }

        public Klant FindKlant(string klantnummer)
        {
            using (var context = new KlantenContext())
            {
                try
                {
                    var entity = context.Klanten.Single(x => x.Klantnummer == klantnummer);
                    return EntityToDTO.ConvertKlant(entity);
                }
                catch (InvalidOperationException)
                {
                    throw new FunctionalException($"Er kon geen klant worden gevonden met klantnummer '{klantnummer}'");
                }                
            }
        }
    }
}
