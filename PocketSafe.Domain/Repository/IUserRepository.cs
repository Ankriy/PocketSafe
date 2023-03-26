using PocketSafe.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace PocketSafe.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        ICollection<User> Get(string search, int skip, int take);
    }
}
