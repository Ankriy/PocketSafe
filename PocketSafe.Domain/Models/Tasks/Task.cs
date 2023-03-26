using System;

namespace PocketSafe.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
