using PocketSafe.Domain.Models;
using PocketSafe.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskStorageOfPeople.Logic
{
    public class UserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public int GetAllCount()
        {
            return _userRepository.Count();
        }
        public List<UserDTO> GetTestUsersList()
        {
            var users = _userRepository.Get("", 0, 20000000);
            var list = users.Select(x => new UserDTO()
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.Surname,
                Email = x.Email
            }).ToList();
            return list;
        }
        
        public int AddUser(UserCreateDTO user)
        {
            var newUser = new User()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.SurName,
                Email = user.Email
            };
            _userRepository.Create(newUser);
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
            var listUsers = new User() {
                Id = userUpdate.Id,
                Name = userUpdate.Name,
                Surname = userUpdate.SurName,
                Email = userUpdate.Email
            };
            _userRepository.Update(listUsers);
            return userUpdate.Id;
        }
    }
}
