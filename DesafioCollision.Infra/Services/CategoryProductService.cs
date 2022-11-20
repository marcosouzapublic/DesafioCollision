using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using DesafioCollision.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Infra.Services
{
    public class CategoryProductService : ICategoryProductService
    {
        private readonly ICategoryProductRepository _repository;

        public CategoryProductService(ICategoryProductRepository repository)
        {
            _repository = repository;
        }

        public void Add(CategoryProduct item)
        {
            _repository.Add(item);
        }

        public void AddRange(ICollection<CategoryProduct> items)
        {
            foreach(var relationship in items)
                Add(relationship);
        }

        public void Put(CategoryProduct item)
        {
            _repository.Put(item);
        }

        public void Remove(CategoryProduct item)
        {
            _repository.Remove(item);
        }

        public void RemoveAllByProductId(Guid productId)
        {
            _repository.RemoveAllByProductId(productId);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
