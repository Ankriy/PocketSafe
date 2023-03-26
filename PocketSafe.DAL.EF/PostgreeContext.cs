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


        public DbSet<User> Users => Set<User>();
        public DbSet<T.Task> Tasks => Set<T.Task>();
    }
}