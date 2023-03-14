using PocketSafe.DAL.Repositories.Abstact;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStorageOfPeople.Logic.Models;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskStorageOfPeople.Logic
{
    public class UserListService
    {
        private IUserRepository _userRepository;
        public UserListService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserListDTO Get(int skip, int take)
        {
            var result = new UserListDTO
            {
                Skip = skip,
                Take = take
            };

            var count = _userRepository.GetCount(x => true);
            result.TotalCount = count;

            if (skip > count)
            {
                result.Users = new List<UserDTO>();
                return result;
            }

            result.Users = _userRepository
                .Get(x => true, skip, take)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    SurName = x.SurName,
                    Email = x.Email
                }).ToList();

            return result;
        }
    }
}
