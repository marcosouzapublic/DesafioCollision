using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioCollision.Infra.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly EFContext.EFContext _context;

        public ProductQueries(EFContext.EFContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.OrderBy(p => p.CreatedAt);
        }

        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return _context.Products.Where(p => p.Name.Contains(name)).OrderBy(p => p.CreatedAt);
        }
    }
}
