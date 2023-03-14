using Microsoft.AspNetCore.Mvc;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class UserShortViewModel
    {
        
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }


        public UserShortViewModel() { }

        public UserShortViewModel(UserDTO task)
        {
            Id = task.Id;
            Name = task.Name;
            SurName = task.SurName;
            Email = task.Email;

        }

    }
}
