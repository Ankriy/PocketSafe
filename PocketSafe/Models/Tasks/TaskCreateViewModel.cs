namespace StorageOfPeople.Models.Storage
{
    public class TaskCreateViewModel
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
