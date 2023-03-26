using PocketSafe.Domain.Models;
using PocketSafe.Domain.Repository;
using System.Linq.Expressions;
using TaskProject.Domain.Models.Users;
using TaskProject.Domain.Repositories.Abstact;

namespace TaskProject.DAL.EF.Repositories
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
            return _context.Users.Count();
        }

        public User Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> Get(string search, int skip, int take)
        {
            IQueryable<User> query = _context.Users;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Name.StartsWith(search) || x.Surname.StartsWith(search));

            var users = query
                .Skip(skip)
                .Take(take)
                .ToList();

            return users;
        }

        public User? Get(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
