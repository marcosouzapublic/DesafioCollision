using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Infra.Queries.Mocks
{
    public class MockProductQueries : IProductQueries
    {
        private readonly List<Product> _products;

        public MockProductQueries()
        {
            _products = new List<Product>()
            {
                new Product("iPhone 3G", "iphone", 1, 1),
                new Product("iPhone 3GS", "iphone", 2, 2),
                new Product("iPhone 4", "iphone", 3, 3)
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _products.Where(p => p.Name == name);
        }
    }
}
