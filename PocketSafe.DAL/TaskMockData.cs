using System;
using System.Collections.Generic;

namespace PocketSafe.DAL
{
    public class TaskMockData
    {
        private UserMockData _userMockData;
        private List<Task> _tasks;

        public TaskMockData(UserMockData userMockDataService)
        {
            _userMockData = userMockDataService;
            _tasks = new List<Task>();

            Random rnd = new Random();
            var usersCount = _userMockData.Users.Count;
            for (int i = 1; i < 300; i++)
            {
                int contractorId = rnd.Next(1, usersCount);
                _tasks.Add(new Task() { Id = i, 
                    Description = $"Description of task {i}. Created {DateTime.Now.ToString()}",
                    Subject = $"Task {i}", 
                    UserId =  contractorId});
            }

        }

        public List<Task> Tasks => _tasks;

    }
}
