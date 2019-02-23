using Assessment.ReviewP2.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Assessment.ReviewP2.DAL
{
    public class InventoryDBInitializer : CreateDatabaseIfNotExists<InventoryDBContext>
    {
        protected override void Seed(InventoryDBContext context)
        {
            var inventories = new List<Inventory>
            {
                new Inventory {Quantity = 100},
                new Inventory {Quantity = 200},
                new Inventory {Quantity = 300}
            };

            context.Inventories.AddRange(inventories);
            context.SaveChanges();
        }
    }
}