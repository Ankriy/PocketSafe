
using PocketSafe.Domain.Models;
using System.Collections.Generic;

namespace PocketSafe.Domain.Repository
{
    public interface ITaskRepository : IRepository<Task>
    {
        ICollection<Task> Get(string search, int skip, int take);
        ICollection<Task> Get(string search, int skip, int take, int userid);
    }
}
