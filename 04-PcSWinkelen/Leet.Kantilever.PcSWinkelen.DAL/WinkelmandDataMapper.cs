using System;
using System.Collections.Generic;
using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System.Linq;
using System.Data.Entity;

namespace Leet.Kantilever.PcSWinkelen.DAL
{
    public class WinkelmandDataMapper : IDataMapper<Winkelmand>
    {
        /// <summary>
        /// Insert a product into the database and add the product to the winkelmand.
        /// Creates a winkelmand if not exists.
        /// If product is already present in the database with the same client id, then only the aantal is updated        
        /// /// </summary>
        /// <param name="product">Product to persist to the database</param>
        /// <param name="clientID">ClientID of the winkelmand</param>
        public void AddProductToWinkelmand(Product product, string clientID)
        {
            using (var context = new WinkelenContext())
            {

                var existingProduct = context.Products.SingleOrDefault(p => p.CatalogusProductID == product.CatalogusProductID && p.Winkelmand.ClientID == clientID);
                if (existingProduct != null)
                {
                    existingProduct.Aantal += product.Aantal;
                    context.Products.Attach(existingProduct);
                    context.Entry(existingProduct).Property(e => e.Aantal).IsModified = true;
                }
                else
                {
                    var winkelmand = context.Winkelmanden.Include(w => w.Products).SingleOrDefault(w => w.ClientID == clientID);
                    if (winkelmand != null)
                    {
                        winkelmand.Products.Add(product);
                        context.Winkelmanden.Attach(winkelmand);
                    }
                    else
                    {
                        context.Winkelmanden.Add(new Winkelmand
                        {
                            ClientID = clientID,
                            Products = new List<Product>() { product },
                        });
                    }
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Get All Winkelmanden out of the database
        /// </summary>
        /// <returns>List of Winkelmanden</returns>
        public IEnumerable<Winkelmand> FindAll()
        {
            using(var context = new WinkelenContext())
            {
                return context.Winkelmanden
                    .Include(Winkelmand => Winkelmand.Products).ToList();
            }
        }

        /// <summary>
        /// Gets the Winkelmand with a specific clientID
        /// </summary>
        /// <param name="clientID">ClientID to search Winkelmand</param>
        /// <returns>Winkelmand that matches the clientID</returns>
        public Winkelmand FindWinkelmandByClientId(string clientID)
        {
            using (var context = new WinkelenContext())
            {
                return context.Winkelmanden
                    .Include(Winkelmand => Winkelmand.Products)
                    .SingleOrDefault(winkelmand => winkelmand.ClientID == clientID);
            }
        }
    }
}