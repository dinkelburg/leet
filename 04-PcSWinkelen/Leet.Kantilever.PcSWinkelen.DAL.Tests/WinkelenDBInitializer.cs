using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Leet.Kantilever.PcSWinkelen.DAL.Tests
{
    internal class WinkelenDBInitializer : DropCreateDatabaseAlways<WinkelenContext>
    {
        protected override void Seed(WinkelenContext context)
        {
            var winkelmand = DummyDataDAL.GetWinkelmand();

            context.Winkelmanden.Add(winkelmand);

            base.Seed(context);
        }
    }
}