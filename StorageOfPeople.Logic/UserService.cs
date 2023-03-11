using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStorageOfPeople.Logic.Models;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskStorageOfPeople.Logic
{
    public class UserService
    {
        public UserService() { }
        
        public List<UserDTO> GetTestUsersList()
        {
            return TestData.Users;
        }
        public void SetTestUsersList(List<UserDTO> users)
        {
            TestData.Users = users;
        }
        public void AddTestUsersList(UserDTO user)
        {
            TestData.Users.Add(user);
        }
    }
}
