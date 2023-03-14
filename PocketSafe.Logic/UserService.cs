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
        public int AddUser(UserCreateDTO user)
        {
            //TestData.Users.Add(user);
            var newUser = new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email
            };
            AddTestUsersList(newUser);
            return newUser.Id;
        }
        public UserDTO GetUser(int id)
        {
            var users = GetTestUsersList();
            var user = users.Where(u => u.Id == id).First();
            return new UserDTO(){
                Id = id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email
            }; ;
        }
        public void EditUser(UserEditDTO user)
        {
            var listUsers = GetTestUsersList();
            for (int i = 0; i < listUsers.Count; i++)
            {
                if (listUsers[i].Id == user.Id)
                {
                    listUsers[i].Name = user.Name;
                    listUsers[i].SurName = user.SurName;
                    listUsers[i].Email = user.Email;
                }
            }
            SetTestUsersList(listUsers);
        }
    }
}
