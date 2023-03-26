using Microsoft.EntityFrameworkCore;
using PocketSafe.Domain.Models;
using T = PocketSafe.Domain.Models;

namespace PocketSafe.DAL.EF
{
    public class PostgreeContext : DbContext
    {
        public PostgreeContext(DbContextOptions<PostgreeContext> options)
            : base(options)
        {
        }


        public DbSet<User> User => Set<User>();
        public DbSet<T.Task> Task => Set<T.Task>();
    }
}