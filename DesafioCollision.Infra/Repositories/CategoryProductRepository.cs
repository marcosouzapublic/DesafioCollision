using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Infra.Repositories
{
    public class CategoryProductRepository : ICategoryProductRepository
    {
        public readonly EFContext.EFContext _context;

        public CategoryProductRepository(EFContext.EFContext context)
        {
            _context = context;
        }

        public void Add(CategoryProduct item)
        {
            _context.CategoriesProducts.Add(item);
        }

        public void Put(CategoryProduct item)
        {
            _context.CategoriesProducts.Update(item);
        }

        public void Remove(CategoryProduct item)
        {
            _context.CategoriesProducts.Remove(item);
        }

        public void RemoveAllByProductId(Guid productId)
        {
            var toRemove = _context.CategoriesProducts.Where(c => c.ProductId == productId);
            _context.CategoriesProducts.RemoveRange(toRemove);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
