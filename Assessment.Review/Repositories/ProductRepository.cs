using Assessment.Review.DAL;
using Assessment.Review.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Assessment.Review.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ProductDBContext db = new ProductDBContext();

        public async Task<Product> Get(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await db.Products.ToListAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}