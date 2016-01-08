using System;
using System.Collections.Generic;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System.Linq;

namespace Leet.Kantilever.PcSWinkelen.DAL
{
    public class ProductDataMapper : IDataMapper<Product, long>
    {
        public ProductDataMapper()
        {

        }

        public IEnumerable<Product> FindAll()
        {
            using (var context = new WinkelenContext())
            {
                return context.Products.ToList();
            }
        }

        public IEnumerable<Product> FindByClientId(string clientId)
        {
            using (var context = new WinkelenContext())
            {
                return context.Products.Where(product => product.ClientId == clientId).ToList();
            }
        }

        public void Insert(Product item)
        {
            using (var context = new WinkelenContext())
            {
                context.Products.Add(item);
                context.SaveChanges();
            }
        }
    }
}