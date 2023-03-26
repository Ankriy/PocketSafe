using System;

namespace PocketSafe.Logic.Models.Tasks
{
    public class TaskEditDTO
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
