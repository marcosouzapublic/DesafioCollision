using DesafioCollision.Domain.Models;
using DesafioCollision.Domain.Repositories;
using DesafioCollision.Domain.Services;

namespace DesafioCollision.Infra.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public void Add(Category item)
        {
            _repository.Add(item);
        }

        public void Put(Category item)
        {
            _repository.Put(item);
        }

        public void Remove(Category item)
        {
            _repository.Remove(item);
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
