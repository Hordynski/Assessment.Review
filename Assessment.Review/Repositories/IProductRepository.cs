using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Review.Models;

namespace Assessment.Review.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
    }
}