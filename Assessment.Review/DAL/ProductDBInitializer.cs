using Assessment.Review.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Assessment.Review.DAL
{
    internal class ProductDBInitializer : CreateDatabaseIfNotExists<ProductDBContext>
    {
        protected override void Seed(ProductDBContext context)
        {
            var products = new List<Product>
            {
                new Product {ItemID = 1, Name = "Dockers", Description = "Whale pants.", Price = 15.00},
                new Product {ItemID = 2, Name = "Phone", Description = "Ring ring", Price = 2000},
                new Product {ItemID = 3, Name = "Banana", Description = "Donkey Kong", Price = 4.50}

            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}