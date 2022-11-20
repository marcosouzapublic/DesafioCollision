using DesafioCollision.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Domain.Services
{
    public interface ICategoryProductService : IService<CategoryProduct>
    {
        void AddRange(ICollection<CategoryProduct> items);
        void RemoveAllByProductId(Guid productId);
    }
}
