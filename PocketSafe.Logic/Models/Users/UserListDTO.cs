using System.Collections.Generic;

namespace TaskStorageOfPeople.Logic.Models.Users
{
    public class UserListDTO
    {
        public List<UserDTO> Users { get; set; }

        public int TotalCount { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
