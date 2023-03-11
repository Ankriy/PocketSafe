

using StorageOfPeople.Models.Storage;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class StorageNewViewModel
    {

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public List<StorageViewModel> People { get; set; }


        public StorageNewViewModel(List<UserDTO> people)
        {
            People = new List<StorageViewModel>();
            foreach (var ppl in people)
            {
                People.Add(new StorageViewModel()
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
