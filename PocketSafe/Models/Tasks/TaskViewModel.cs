using PocketSafe.Logic.Models.Tasks;
using TaskStorageOfPeople.Logic.Models.Users;

namespace StorageOfPeople.Models.Storage
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        static public int TotalCount { get; set; }
        static public int Skip { get; set; }
        static public int Take { get; set; }

        public TaskViewModel() { }

        public TaskViewModel(TaskDTO user)
        {
            Id = user.Id;
            Subject = user.Subject;
            Description = user.Description;
            UserId = user.UserId;
        }
    }
}
