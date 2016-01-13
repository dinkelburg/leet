//using System;
//using System.Collections.Generic;
//using Leet.Kantilever.FEBestellingen.Site.Controllers;
//using Leet.Kantilever.FEBestellingen.Site.ViewModels;

//namespace Leet.Kantilever.FEBestellingen.Site.Managers
//{
//    public class BestellingManager : IOrderManager
//    {
//        private static IEnumerable<BestellingsRegelVM> _placeholder = new List<BestellingsRegelVM> {
//                new BestellingsRegelVM
//                {
//                    ProductNaam = "HL Road Frame - Black, 58",
//                    Aantal = 5,
//                    Leverancier = "Kaga Miyata",
//                    Leverancierscode = 8
//                },
//                new BestellingsRegelVM
//                {
//                    ProductNaam = "HL Road Frame - Red, 58",
//                    Aantal = 1,
//                    Leverancier = "Eddy Merckx",
//                    Leverancierscode = 9
//                },
//                new BestellingsRegelVM
//                {
//                    ProductNaam = "Sport-100 Helmet, Red",
//                    Aantal = 3,
//                    Leverancier = "Batavus",
//                    Leverancierscode = 2
//                },
//                new BestellingsRegelVM
//                {
//                    ProductNaam = "Mountain Bike Socks, M",
//                    Aantal = 9,
//                    Leverancier = "Bikkel",
//                    Leverancierscode = 6
//                },
//            };

//        public IEnumerable<BestellingsRegelVM> GetOrderRegelsForOrder(int id)
//        {
//            return _placeholder;
//        }
//    }
//}