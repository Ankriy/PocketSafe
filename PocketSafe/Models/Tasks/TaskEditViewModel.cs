using TaskStorageOfPeople.Logic.Models.Users;

namespace StorageOfPeople.Models.Storage
{
    public class TaskEditViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
