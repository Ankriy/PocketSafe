using Microsoft.AspNetCore.Mvc.RazorPages;
using PocketSafe.Logic.Models.Tasks;
using System.Diagnostics.Contracts;
using System.Drawing;
using TaskStorageOfPeople.Logic.Models.Users;


namespace TaskWebProject.Models.Tasks
{
    public class TaskListViewModel
    {
        public List<TaskShortViewModel> Tasks { get; set; }
        public int Id { get; set; }
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public TaskListViewModel()
        {
            Tasks = new List<TaskShortViewModel>();
        }

        public TaskListViewModel(TaskListDTO list, int page, int size, int id)
        {
            Tasks = new List<TaskShortViewModel>();
            foreach (TaskDTO task in list.Tasks)
            {
                Tasks.Add(new TaskShortViewModel(task));
            }
            Id = id;

            TotalCount = list.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
            CanBack = Page > 0;
            Id = id;
        }

    }
}
