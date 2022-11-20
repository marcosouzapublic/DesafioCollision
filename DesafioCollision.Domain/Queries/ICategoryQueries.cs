using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Domain.Queries
{
    public interface ICategoryQueries : IQuery<Category>
    {
        bool InUse(Category category);
        ICollection<CategoryProduct> GetCategoriesFromGuidList(IEnumerable<Guid> guidList);
    }
}
