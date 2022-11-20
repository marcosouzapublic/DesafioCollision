using System;

namespace DesafioCollision.Domain.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(string name)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Name = name;
        }

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime? UpdatedAt { get; private set; }
    }
}


