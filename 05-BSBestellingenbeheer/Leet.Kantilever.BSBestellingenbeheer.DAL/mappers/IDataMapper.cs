using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mappers
{
    public interface IBestellingMapper<T>
    {
            T FindBestellingByID(int id);
            void AddBestelling(Bestelling bestelling);
            IEnumerable<T> FindAll();
             T FindVolgendeOpenBestelling();

    }
}
