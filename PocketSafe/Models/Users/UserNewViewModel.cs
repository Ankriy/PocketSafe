

using StorageOfPeople.Models.Storage;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class UserNewViewModel
    {

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public List<UserViewModel> People { get; set; }


        public UserNewViewModel(List<UserDTO> people)
        {
            People = new List<UserViewModel>();
            foreach (var ppl in people)
            {
                People.Add(new UserViewModel()
                {
                    Id = ppl.Id,
                    Name = ppl.Name,
                    SurName = ppl.SurName,
                    Email = ppl.Email
                });
            }
        }
    }
}
