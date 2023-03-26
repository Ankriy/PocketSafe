
using PocketSafe.DAL.Repositories.Mock.Data;
using PocketSafe.Domain.Models;
using PocketSafe.Domain.Repository;

namespace PocketSafe.DAL.Repositories.Mock
{
    public class UserMockRepository : IUserRepository, IRepository<User>
    {
        private UserMockData _testUserData;

        public UserMockRepository(UserMockData testUserData)
        {
            _testUserData = testUserData;
        }

        public User Create(User item)
        {
            item.Id = _testUserData.Users.Last().Id + 1;
            _testUserData.Users.Add(item);
            return item;
        }

        public void Delete(int id)
        {
            var user = _testUserData.Users.FirstOrDefault(x => x.Id == id);
            _testUserData.Users.Remove(user);
        }

        public User Get(int id)
        {
            return _testUserData
                .Users
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<User> Get(Func<User, bool> where)
        {
            return _testUserData
                .Users
                .Where(where)
                .ToList();
        }

        public ICollection<User> Get(Func<User, bool> where, int skip, int take)
        {
            return _testUserData
                .Users
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public ICollection<User> Get(string search, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _testUserData
                .Users
                .Count();
        }

        public void Update(User item)
        {
            var user = _testUserData.Users.SingleOrDefault(x => x.Id == item.Id);
            user.Name = item.Name;
            user.Surname = item.Surname;
            user.Email = item.Email;
        }

        public int Count(int userid)
        {
            throw new NotImplementedException();
        }
    }
}
