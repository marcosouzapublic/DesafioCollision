using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace DesafioCollision.Domain.Models
{
    public class CategoryProduct : Notifiable<Notification>
    {
        public CategoryProduct()
        {
        }

        public CategoryProduct(Product product, Category category)
        {
            CheckIfDataIsValid(product, category);

            if(IsValid)
            {
                Id = Guid.NewGuid();
                Product = product;
                Category = category;
                ProductId = product.Id;
                CategoryId = category.Id;
            }
        }

        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Guid ProductId { get; private set; }
        public Product Product { get; private set; }

        private void CheckIfDataIsValid(Product product, Category category)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNull(product, "Product", "the product cannot be null")
                .IsNotNull(category, "Category", "the category cannot be null")
                .IsTrue(product.IsValid, "ProductValidation", "The product is not valid")
                .IsTrue(category.IsValid, "CategoryValidation", "The category is not valid")
            );
        }
    }
}
