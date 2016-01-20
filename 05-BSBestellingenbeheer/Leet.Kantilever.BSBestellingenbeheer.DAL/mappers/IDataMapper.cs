using Leet.Kantilever.BSBestellingenbeheer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.BSBestellingenbeheer.DAL.mappers
{
    public interface IDatamapper<T>
    {
        T FindByID(int id);
        void Insert(T bestelling);
        IEnumerable<T> FindAll();
        T FindNext();
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Update(T bestelling);
    }
}
