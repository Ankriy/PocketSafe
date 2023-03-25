using PocketSafe.DAL.Repositories.Abstact;
using PocketSafe.DAL.Repositories.Mock.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PocketSafe.DAL.Repositories.Mock
{
    public class TaskMockRepository : ITaskRepository, IRepository<Task>
    {
        private TaskMockData _taskMockData;

        public TaskMockRepository(TaskMockData taskMockData)
        {
            _taskMockData = taskMockData;
        }


        public Task Create(Task item)
        {
            item.Id = _taskMockData.Tasks.Last().Id + 1;
            _taskMockData.Tasks.Add(item);
            return item;
        }

        public void Delete(int id)
        {
            var task = _taskMockData.Tasks.SingleOrDefault(x => x.Id == id);
            _taskMockData.Tasks.Remove(task);
        }

        public Task Get(int id)
        {
            return _taskMockData
                .Tasks
                .FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Task> Get(Func<Task, bool> where)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .ToList();
        }

        public ICollection<Task> Get(Func<Task, bool> where, int skip, int take)
        {
            return _taskMockData
                .Tasks
                .Where(where)
                .Skip(skip)
                .Take(take)
                .ToList();
        }
        public ICollection<Task> Get(string search, int skip, int take, int id)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return _taskMockData
                .Tasks
                .Count();
        }
        public int Count(int userid)
        {
            return _taskMockData
                .Tasks
                .Where(x => x.UserId == userid)
                .Count();
        }
        public void Update(Task item)
        {
            var task = _taskMockData.Tasks.SingleOrDefault(x => x.Id == item.Id);
            task.Subject = item.Subject;
            task.Description = item.Description;
            task.UserId = item.UserId;
        }

        public ICollection<Task> Get(string search, int skip, int take)
        {
            throw new NotImplementedException();
        }
    }
}
