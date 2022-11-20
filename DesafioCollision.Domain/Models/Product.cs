using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DesafioCollision.Domain.Models
{
    public class Product : Notifiable<Notification>
    {
        public Product()
        {
        }

        public Product(string name, string description, decimal price, decimal amount)
        {
            CheckIfProductIsValid(name, description, price, amount);

            if (IsValid)
            {
                Id = Guid.NewGuid();
                Name = name;
                Description = description;
                Price = price;
                Amount = amount;
                CreatedAt = DateTime.Now;
            }
        }

        [Key]
        public Guid Id { get; private set; }
        
        [Required]
        public string Name { get; private set; }

        [Required]
        public string Description { get; private set; }

        [Required]
        public decimal Price { get; private set; }

        [Required]
        public decimal Amount { get; private set; }

        [Required]
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public virtual ICollection<CategoryProduct> Categories { get; private set; }

        public void Put(string name, string description, decimal price, decimal amount)
        {
            CheckIfProductIsValid(name, description, price, amount);

            if (IsValid)
            {
                Name = name;
                Description = description;
                Price = price;
                Amount = amount;
                UpdatedAt = DateTime.Now;
            }
        }

        private void CheckIfProductIsValid(string name, string description, decimal price, decimal amount)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(name, "Name", "the product name must be filled")
                .IsNotNullOrEmpty(description, "Description", "the product description must be filled")
                .IsLowerOrEqualsThan(price, 0, "Price", "the product price must greater than 0")
                .IsLowerOrEqualsThan(amount, 0, "Amount", "the product amount must greater than 0")
            );
        }
    }
}
