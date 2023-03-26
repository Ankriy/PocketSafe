using Microsoft.AspNetCore.Mvc;
using PocketSafe.Logic.Models.Tasks;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class TaskShortViewModel
    {
        
        [FromRoute(Name = "id")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationDate { get; set; }


        public TaskShortViewModel() { }

        public TaskShortViewModel(TaskDTO task)
        {
            Id = task.Id;
            UserId = task.UserId;
            Subject = task.Subject;
            Description = task.Description;
            Deadline = task.Deadline;
            CreationDate = task.CreationDate;
        }

    }
}
