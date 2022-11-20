using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioCollision.Domain.Services
{
    public interface IService<T> where T : Notifiable<Notification>
    {
        public void Add(T item);
        public void Remove(T item);
        public void Put(T item);
        public void SaveChanges();
    }
}
