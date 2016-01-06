
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.Controllers
{
    public interface IOrderManager
    {
        IEnumerable<OrderRegelVM> GetOrderRegelsForOrder(int id);
    }
}