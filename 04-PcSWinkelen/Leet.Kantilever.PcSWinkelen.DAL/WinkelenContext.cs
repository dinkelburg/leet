﻿using Leet.Kantilever.PcSWinkelen.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leet.Kantilever.PcSWinkelen.DAL
{
    public class WinkelenContext : DbContext
    {
        public WinkelenContext() : base("WinkelenContext") { }
        public DbSet<Product> Products { get; set; }
    }
}