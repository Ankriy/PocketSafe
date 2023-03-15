using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStorageOfPeople.Logic.Models;
using TaskStorageOfPeople.Logic.Models.Users;
using T = PocketSafe.DAL.Repositories.Abstact;

namespace TaskStorageOfPeople.Logic
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDTO> GetTestUsersList()
        {
            var users = _userRepository.Get(x => true);
            var list = users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName,
                Email = x.Email
            }).ToList();
            return list;
        }
        
        public int AddUser(UserCreateDTO user)
        {
            var newUser = new PocketSafe.DAL.User()
            {
                Id = user.Id,
                Name = user.Name,
                SurName = user.SurName,
                Email = user.Email
            };
            var task = _userRepository.Save(newUser);
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
        public object EditUser(UserEditDTO userUpdate)
        {
            var listUsers = new PocketSafe.DAL.User() {
                Id = userUpdate.Id,
                Name = userUpdate.Name,
                SurName = userUpdate.SurName,
                Email = userUpdate.Email
            };
            var user = _userRepository.Save(listUsers);
            return user.Id;
        }
    }
}
