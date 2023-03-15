using System;
using System.Collections.Generic;

namespace PocketSafe.DAL
{
    public class TaskMockData
    {
        private List<Task> _tasks;

        public TaskMockData()
        {
            _tasks = new List<Task>();
            for (int i = 1; i < 45; i++)
            {
                _tasks.Add(new Task() { Id = i, 
                    Description = $"Description of task {i}. Created {DateTime.Now.ToString()}",
                    Subject = $"Task {i}", 
                    UserId = 1 });
            }

        }

        public List<Task> Tasks => _tasks;

    }
}
