using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL
{
    public interface IDataMapper<T, U>
    {
        IEnumerable<T> FindByClientId(string id);
        void Insert(T item);
        IEnumerable<T> FindAll();
    }
}
