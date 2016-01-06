using System;
using System.Collections.Generic;
using Leet.Kantilever.FEBestellingen.Site.Controllers;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;

namespace Leet.Kantilever.FEBestellingen.Site.Managers
{
    public class OrderManager : IOrderManager
    {
        private static IEnumerable<OrderRegelVM> _placeholder = new List<OrderRegelVM> {
                new OrderRegelVM
                {
                    Naam = "HL Road Frame - Black, 58",
                    Aantal = 5,
                    Leverancier = "Kaga Miyata",
                    Leverancierscode = 8
                },
                new OrderRegelVM
                {
                    Naam = "HL Road Frame - Red, 58",
                    Aantal = 1,
                    Leverancier = "Eddy Merckx",
                    Leverancierscode = 9
                },
                new OrderRegelVM
                {
                    Naam = "Sport-100 Helmet, Red",
                    Aantal = 3,
                    Leverancier = "Batavus",
                    Leverancierscode = 2
                },
                new OrderRegelVM
                {
                    Naam = "Mountain Bike Socks, M",
                    Aantal = 9,
                    Leverancier = "Bikkel",
                    Leverancierscode = 6
                },
            };

        public IEnumerable<OrderRegelVM> GetOrderRegelsForOrder(int id)
        {
            return _placeholder;
        }
    }
}