﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leet.Kantilever.BSKlantbeheer.V1.Schema;
using Leet.Kantilever.BSKlantbeheer.DAL.Converters;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace Leet.Kantilever.BSKlantbeheer.DAL.Mappers
{
    public class KlantDataMapper
    {
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

        public void InsertKlant(Klant klant)
        {
            using (var db = new KlantenContext())
            {
                try
                {
                    db.Klanten.Add(DTOToEntity.ConvertKlant(klant));
                    db.SaveChanges();
                }
                catch(DbUpdateException ex)
                {
                    throw new DataException(ex.Message);
                }
            }
        }

        public Klant FindKlant(string klantnummer)
        {
            using (var db = new KlantenContext())
            {
                var entity = db.Klanten.Single(x => x.Klantnummer == klantnummer);
                return EntityToDTO.ConvertKlant(entity);
            }
        }
    }
}