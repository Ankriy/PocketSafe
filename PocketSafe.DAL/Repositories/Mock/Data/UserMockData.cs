using System.Collections.Generic;

namespace PocketSafe.DAL.Repositories.Mock.Data
{
    public class UserMockData
    {
        private List<User> _users;

        public UserMockData()
        {
            _users = new List<User>();
            for (int i = 1; i < 23; i++)
            {
                _users.Add(new User() { Id = i, Name = $"Name {i}", SurName = $"SurName {i}", Email = $"Name{i}SurName{i}@mail.ru" });
            }

        }

        public List<User> Users => _users;

    }
}
