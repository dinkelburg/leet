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
        /// <summary>
        /// Returns all Klanten in de database as a list of DTO's.
        /// </summary>
        /// <returns></returns>
        public ICollection<Klant> GetAllKlanten()
        {
            using (var db = new KlantenContext())
            {
                List<Klant> result = new List<Klant>();
                var klanten = db.Klanten.ToList().Select(EntityToDTO.ConvertKlant) ;
                result.AddRange(klanten);
                return result;
            }
        }

        /// <summary>
        /// Inserts a klant into the database.
        /// </summary>
        /// <param name="klant">The klant to insert.</param>
        public void InsertKlant(Klant klant)
        {
            using (var db = new KlantenContext())
            {
                try
                {
                    db.Klanten.Add(DTOToEntity.ConvertKlant(klant));
                    db.SaveChanges();
                }
                catch(DbEntityValidationException)
                {
                    throw new FunctionalException("De meegegeven gegevens waren niet geldig.");
                }
                catch(DbUpdateException)
                {
                    throw new FunctionalException("De meegegeven gegevens waren niet geldig.");
                }
            }
        }

        /// <summary>
        /// Returns a klant based on his klantnummer.
        /// </summary>
        /// <param name="klantnummer"></param>
        /// <returns></returns>
        public Klant FindKlant(string klantnummer)
        {
            using (var db = new KlantenContext())
            {
                try
                {
                    var entity = db.Klanten.Single(x => x.Klantnummer == klantnummer);
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
