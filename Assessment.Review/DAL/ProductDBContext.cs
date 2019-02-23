using Assessment.Review.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assessment.Review.DAL
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext() : base("ProductContext")
        {
            Database.SetInitializer(new ProductDBInitializer());
        }

        public DbSet<Product> Products { get; set; }
    }
}