using Leet.Kantilever.BSBestellingenbeheer.DAL.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mappers
{
    interface IBestellingMapper<T>
    {
            T FindBestellingByID(int id);
            void AddBestelling(Bestelling bestelling);
            IEnumerable<T> FindAll();
    }
}
