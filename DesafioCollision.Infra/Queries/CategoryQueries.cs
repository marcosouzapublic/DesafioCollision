using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioCollision.Infra.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly EFContext.EFContext _context;

        public CategoryQueries(EFContext.EFContext context)
        {
            _context = context; 
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.OrderBy(c => c.CreatedAt);
        }

        public Category GetById(Guid id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetByName(string name)
        {
            return _context.Categories.Where(c => c.Name.Contains(name)).OrderBy(c => c.CreatedAt);
        }

        public ICollection<CategoryProduct> GetCategoriesFromGuidList(IEnumerable<Guid> guidList)
        {
            var categories = new List<CategoryProduct>();

            foreach (var guid in guidList)
                categories.Add(GetCategoryProductByCategoryId(guid));

            return categories;
        }

        public bool InUse(Category category)
        {
            return _context.CategoriesProducts.FirstOrDefault(c => c.Category.Id == category.Id) != null;
        }

        private CategoryProduct GetCategoryProductByCategoryId(Guid id)
        {
            return _context.CategoriesProducts.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
