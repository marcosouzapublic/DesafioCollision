using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EFContext.EFContext _context;

        public CategoryRepository(EFContext.EFContext context)
        {
            _context = context;
        }
        public void Add(Category item)
        {
            _context.Categories.Add(item);
        }

        public void Put(Category item)
        {
            _context.Categories.Update(item);
        }

        public void Remove(Category item)
        {
            _context.Categories.Remove(item);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
