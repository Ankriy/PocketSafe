using Microsoft.EntityFrameworkCore;
using PocketSafe.Domain.Models;
using PocketSafe.Domain.Repository;

namespace PocketSafe.DAL.EF.Repositories
{
    public class UserEFPostgreeRepository : IUserRepository, IRepository<User>
    {

        private readonly PostgreeContext _context;

        public UserEFPostgreeRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.User.Count();
        }

        public int Count(int userid)
        {
            throw new NotImplementedException();
        }

        public User Create(User item)
        {
            _context.User.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> Get(string search, int skip, int take)
        {
            IQueryable<User> query = _context.User;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.StartsWith(search) || x.Surname.StartsWith(search));

            var users = query
                .OrderBy(p => p.Id)
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public User? Get(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User item)
        {
            _context.User.Update(item);
            _context.SaveChanges();
        }
    }
}
