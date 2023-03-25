using PocketSafe.DAL.Repositories.Abstact;
using PocketSafe.Logic.Models.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStorageOfPeople.Logic.Models;
using TaskStorageOfPeople.Logic.Models.Users;

namespace TaskStorageOfPeople.Logic
{
    public class TaskListService
    {
        private ITaskRepository _taskRepository;
        public TaskListService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public TaskListDTO Get(int skip, int take, int userId)
        {
            var result = new TaskListDTO()
            {
                Skip = skip,
                Take = take
            };

            var count = _taskRepository.Count(userId);
            result.TotalCount = count;

            if (skip > count)
            {
                result.Tasks = new List<TaskDTO>();
                return result;
            }

            result.Tasks = _taskRepository
            .Get("", skip, take, userId)
            .Select(x => new TaskDTO()
            {
                Id = x.Id,
                Subject = x.Subject,
                Description = x.Description,
                UserId = x.UserId
            }).ToList();

            return result;
        }
    }
}
