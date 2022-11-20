using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioCollision.Domain.Models
{
    public class Category : Notifiable<Notification>
    {
        public Category()
        {
        }

        public Category(string name)
        {
            CheckIfNameIsValid(name);

            if (IsValid)
            {
                Id = Guid.NewGuid();
                CreatedAt = DateTime.Now;
                Name = name;
            }
        }

        [Key]
        public Guid Id { get; private set; }

        [Required]
        public string Name { get; private set; }

        [Required]
        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }

        public virtual ICollection<CategoryProduct> Products { get; private set; }

        public void ChangeName(string name)
        {
            CheckIfNameIsValid(name);

            if (IsValid)
            {
                Name = name;
                UpdatedAt = DateTime.Now;
            }
        }

        private void CheckIfNameIsValid(string name)
        {
            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(name, "Name", "the category's name must be filled")
            );
        }
    }
}


