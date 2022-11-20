using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Domain.Repositories
{
    public interface ICategoryProductRepository : IRepository<CategoryProduct>
    {
        void RemoveAllByProductId(Guid productId);
    }
}
