using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PocketSafe.Domain.Repository
{
    public interface IRepository<T>
    {
        public T Get(int id);
        public T Create(T item);
        public void Update(T item);
        public void Delete(int id);
        int Count();
        int Count(int userid);
        //public T Get(int id);
        //public ICollection<T> Get(Func<T, bool> where);
        //public int GetCount(Func<T, bool> where);
        //public int GetCount(Func<T, bool> where, int id);

        //public ICollection<T> Get(Func<T, bool> where, int skip, int take);

        //public ICollection<T> Get(Func<T, bool> where, int id, int skip, int take);

        //public T Save(T item);
        //public void Delete(int id);
    }
}
