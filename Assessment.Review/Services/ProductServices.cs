using Assessment.Review.Models;
using Assessment.Review.Repositories;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assessment.Review.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;

        public ProductServices(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Product> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task UpdateInventory(Inventory inventory)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:64934/");
            var response = await client.PutAsJsonAsync($"api/inventories/{inventory.ID}", inventory);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}