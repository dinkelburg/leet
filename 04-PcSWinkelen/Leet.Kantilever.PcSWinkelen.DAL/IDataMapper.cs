using Leet.Kantilever.PcSWinkelen.DAL.Entities;
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
        T FindWinkelmandByClientId(string id);
        void AddProductToWinkelmand(Product product, string clientID);
        IEnumerable<T> FindAll();
    }
}
