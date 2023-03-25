using PocketSafe.DAL.Repositories.Abstact;
using System.Collections.Generic;

namespace PocketSafe.DAL.Repositories.Abstact
{
    public interface ITaskRepository : IRepository<Task>
    {
        ICollection<Task> Get(string search, int skip, int take);
        ICollection<Task> Get(string search, int skip, int take, int userid);
    }
}
