using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using DesafioCollision.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Infra.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public void Add(Product item)
        {
            _repository.Add(item);
        }

        public void Put(Product item)
        {
            _repository.Put(item);
        }

        public void Remove(Product item)
        {
            _repository.Remove(item);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
