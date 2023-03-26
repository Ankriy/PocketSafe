using PocketSafe.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
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

            var count = _userRepository.Count();
            result.TotalCount = count;

            if (skip > count)
            {
                result.Users = new List<UserDTO>();
                return result;
            }

            result.Users = _userRepository
                .Get("", skip, take)
                .Select(x => new UserDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    SurName = x.Surname,
                    Email = x.Email
                }).ToList();


            return result;
        }
    }
}
