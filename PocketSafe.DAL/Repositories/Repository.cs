using PocketSafe.DAL.Repositories.Abstact;
using System;
using System.Collections.Generic;

namespace PocketSafe.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Get(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> Get(Func<T, bool> where, int skip, int take)
        {
            throw new NotImplementedException();
        }
        public ICollection<T> Get(Func<T, bool> where, int id, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int GetCount(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }
        public int GetCount(Func<T, bool> where, int id)
        {
            throw new NotImplementedException();
        }

        public T Save(T item)
        {
            throw new NotImplementedException();
        }
    }
}
