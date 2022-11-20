using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesafioCollision.Domain.Queries
{
    public interface IQuery<T> where T : Notifiable<Notification>
    {
        public IEnumerable<T> GetAll();
        public T GetById(Guid id);
        public IEnumerable<T> GetByName(string name);
    }
}
