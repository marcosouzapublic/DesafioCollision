using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCollision.Tests.Infra.Queries.Mocks
{
    public class MockCategoryQueries : ICategoryQueries
    {
        private IEnumerable<Category> _categories;
        private IEnumerable<CategoryProduct> _categorieProducts;

        public MockCategoryQueries()
        {
            _categories = new List<Category>()
            {
                new Category("Smartphone"),
                new Category("Vide Game Console"),
                new Category("Eletronics"),
            };

            _categorieProducts = new List<CategoryProduct>()
            {
                new CategoryProduct(new Product("A", "B", 1, 1), _categories.ElementAt(0)),
                new CategoryProduct(new Product("A", "B", 1, 1), _categories.ElementAt(1)),
                new CategoryProduct(new Product("A", "B", 1, 1), _categories.ElementAt(2))
            };
        }

        public IEnumerable<Category> GetAll()
        {
            return _categories;
        }

        public Category GetById(Guid id)
        {
            return _categories.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Category> GetByName(string name)
        {
            return _categories.Where(c => c.Name == name);
        }

        public ICollection<CategoryProduct> GetCategoriesFromGuidList(IEnumerable<Guid> guidList)
        {
            var categories = new List<CategoryProduct>();

            foreach(var guid in guidList)
            {
                var category = _categorieProducts.FirstOrDefault(c => c.Category.Id == guid);

                if (category != null)
                    categories.Add(category);
            }

            return categories;
        }

        public bool InUse(Category category)
        {
            return  _categorieProducts.FirstOrDefault(c => c.Category.Id == category.Id) != null;
        }
    }
}
