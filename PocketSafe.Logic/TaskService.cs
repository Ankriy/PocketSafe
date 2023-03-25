using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using PocketSafe.Logic.Models.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStorageOfPeople.Logic.Models;
using TaskStorageOfPeople.Logic.Models.Users;
using T = PocketSafe.DAL.Repositories.Abstact;

namespace TaskStorageOfPeople.Logic
{
    public class TaskService
    {
        private ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskDTO> GetTestTasksList()
        {
            var tasks = _taskRepository.Get("", 0, 10);
            var list = tasks.Select(x => new TaskDTO()
            {
                Id = x.Id,
                Subject = x.Subject,
                Description = x.Description,
                UserId = x.UserId
            }).ToList();
            return list;
        }
        
        public int AddTask(TaskCreateDTO task)
        {
            var newTask = new PocketSafe.DAL.Task()
            {
                Subject = task.Subject,
                Description = task.Description,
                UserId = task.UserId
            };
            _taskRepository.Create(newTask);
            return newTask.Id;
        }
        public TaskDTO GetTask(int id)
        {
            var tasks = GetTestTasksList();
            var task = tasks.Where(u => u.Id == id).First();
            return new TaskDTO(){
                Id = id,
                Subject = task.Subject,
                Description = task.Description,
                UserId = task.UserId
            };
        }
        public object EditTask(TaskEditDTO taskEdit)
        {
            var listTasks = new PocketSafe.DAL.Task() {
                Id = taskEdit.Id,
                Subject = taskEdit.Subject,
                Description = taskEdit.Description,
                UserId = taskEdit.UserId
            };
            _taskRepository.Update(listTasks);
            return taskEdit.UserId;
        }
    }
}
