using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leet.Kantilever.FEBestellingen.Site.ViewModels;
using System.Collections.Generic;

namespace Leet.Kantilever.FEBestellingen.Site.Tests.ViewModels
{
    [TestClass]
    public class FactuurVMTests
    {
        [TestMethod]
        public void TotaalprijsInclusiefBtw_TeltTotaalOpMetCorrecteInvoerTest()
        {
            var factuur = new FactuurVM
            {
                Bestelling = new BestellingVM()
            };
            factuur.Bestelling.Bestellingsregels.AddRange(
            #region bestellingsRegels
                new List<BestellingsregelVM>
            {
                new BestellingsregelVM
                {
                    Aantal = 1,
                    Prijs = 5
                },
                new BestellingsregelVM
                {
                    Aantal = 2,
                    Prijs = 6
                },
                new BestellingsregelVM
                {
                    Aantal = 4,
                    Prijs = 7.8m
                },
            });
            #endregion

            Assert.AreEqual(string.Format("{0:C}", 58.32m), factuur.Bestelling.TotaalprijsInclusiefBtw);
        }

        [TestMethod]
        public void TotaalprijsInclusiefBtw_TeltTotaalOpMetPaarNullWaardenInvoerTest()
        {
            var factuur = new FactuurVM
            {
                Bestelling = new BestellingVM()
            };
            factuur.Bestelling.Bestellingsregels.AddRange(
            #region bestellingsRegels
                new List<BestellingsregelVM>
            {
                new BestellingsregelVM
                {
                    Aantal = 1,
                    Prijs = 5
                },
                new BestellingsregelVM
                {
                    Aantal = 2,
                    Prijs = null
                },
                new BestellingsregelVM
                {
                    Aantal = 4,
                    Prijs = 7.8m
                },
            });
            #endregion

            Assert.AreEqual(string.Format("{0:C}", 43.80m), factuur.Bestelling.TotaalprijsInclusiefBtw);
        }

        [TestMethod]
        public void TotaalprijsInclusiefBtw_Geef0AlsErGeenPrijzenZijnTest()
        {
            var factuur = new FactuurVM
            {
                Bestelling = new BestellingVM()
            };
            factuur.Bestelling.Bestellingsregels.AddRange(
            #region bestellingsRegels
                new List<BestellingsregelVM>
            {
                new BestellingsregelVM
                {
                    Aantal = 1,
                    Prijs = null
                },
                new BestellingsregelVM
                {
                    Aantal = 2,
                    Prijs = null
                },
                new BestellingsregelVM
                {
                    Aantal = 4,
                    Prijs = null
                },
            });
            #endregion

            Assert.AreEqual(string.Format("{0:C}", 0m), factuur.Bestelling.TotaalprijsInclusiefBtw);
        }
    }
}
