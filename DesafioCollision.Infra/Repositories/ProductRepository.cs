using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioCollision.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFContext.EFContext _context;

        public ProductRepository(EFContext.EFContext context)
        {
            _context = context;
        }

        public void Add(Product item)
        {
            _context.Products.Add(item);
        }

        public void Put(Product item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Remove(Product item)
        {
            _context.Products.Remove(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
