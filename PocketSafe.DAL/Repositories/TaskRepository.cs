using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProject.DAL.Repositories
{
    public class TaskRepository : ITaskRepository, IRepository<Task>
    {
        private TaskMockData _testTaskData;

        public TaskRepository(TaskMockData testTaskData)
        {
            _testTaskData = testTaskData;
        }


        public void Delete(int id)
        {
            var user = _testTaskData.Tasks.FirstOrDefault(x => x.Id == id);
            _testTaskData.Tasks.Remove(user);
        }

        public Task Get(int id)
        {
            return _testTaskData
                .Tasks
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Task> Get(Func<Task, bool> where)
        {
            return _testTaskData
                .Tasks
                .Where(where)
                .ToList();
        }

        public ICollection<Task> Get(Func<Task, bool> where, int skip, int take)
        {
            return _testTaskData
                .Tasks
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public int GetCount(Func<Task, bool> where)
        {
            return _testTaskData
                .Tasks
                .Where(where)
                .Count();
        }

        public Task Save(Task item)
        {
            if(item.Id <= 0)
            {
                item.Id = _testTaskData.Tasks.Last().Id + 1;
                _testTaskData.Tasks.Add(item);
                return item;
            }

            var user = _testTaskData.Tasks.SingleOrDefault(x => x.Id == item.Id);
            user.Subject = item.Subject;
            user.Description = item.Description;

            return user;
        }
    }
}
