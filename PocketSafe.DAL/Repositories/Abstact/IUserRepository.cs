using PocketSafe.DAL.Repositories.Abstact;
using System.Collections;
using System.Collections.Generic;

namespace PocketSafe.DAL.Repositories.Abstact
{
    public interface IUserRepository : IRepository<User>
    {
        ICollection<User> Get(string search, int skip, int take);
    }
}
