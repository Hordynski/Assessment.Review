using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessment.Review.Models;

namespace Assessment.Review.Services
{
    public interface IProductServices : IDisposable
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(int id);
        Task UpdateInventory(Inventory inventory);
    }
}