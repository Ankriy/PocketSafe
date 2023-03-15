using System;

namespace PocketSafe.DAL
{
    public class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
