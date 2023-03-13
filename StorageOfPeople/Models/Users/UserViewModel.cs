using TaskStorageOfPeople.Logic.Models.Users;

namespace StorageOfPeople.Models.Storage
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        static public int TotalCount { get; set; }
        static public int Skip { get; set; }
        static public int Take { get; set; }
        //public StorageViewModel() { }

        //public StorageViewModel(UserDTO user)
        //{
        //    Id = user.Id;
        //    Name = user.Name;
        //    SurName = user.SurName;
        //    Email = user.Email;
        //}
    }
}
