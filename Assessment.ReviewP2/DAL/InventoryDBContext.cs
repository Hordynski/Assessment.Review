using Assessment.ReviewP2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assessment.ReviewP2.DAL
{
    public class InventoryDBContext : DbContext
    {
        public InventoryDBContext(): base("InventoryContext")
        {
            Database.SetInitializer(new InventoryDBInitializer());
        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}