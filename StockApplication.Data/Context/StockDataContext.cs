using Microsoft.EntityFrameworkCore;
using StockApplication.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockApplication.Data.Context
{
    public class StockDataContext: DbContext
    {
        private readonly DbContextOptions _options;
        public DbSet<StockEntity> Stock { get; set; }

        public StockDataContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }
    }
}
