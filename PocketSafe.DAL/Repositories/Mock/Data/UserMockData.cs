using System.Collections.Generic;
using T = PocketSafe.Domain.Models;
namespace PocketSafe.DAL.Repositories.Mock.Data
{
    public class UserMockData
    {
        private List<T.User> _users;

        public UserMockData()
        {
            _users = new List<T.User>();
            for (int i = 1; i < 23; i++)
            {
                _users.Add(new T.User() { Id = i, Name = $"Name {i}", Surname = $"SurName {i}", Email = $"Name{i}SurName{i}@mail.ru" });
            }

        }

        public List<T.User> Users => _users;

    }
}
