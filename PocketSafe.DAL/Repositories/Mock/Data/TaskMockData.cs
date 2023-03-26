using PocketSafe.Domain.Models;
using T = PocketSafe.Domain.Models;

namespace PocketSafe.DAL.Repositories.Mock.Data
{
    public class TaskMockData
    {
        private UserMockData _userMockData;
        private List<T.Task> _tasks;

        public TaskMockData(UserMockData userMockDataService)
        {
            _userMockData = userMockDataService;
            _tasks = new List<T.Task>();

            Random rnd = new Random();
            var usersCount = _userMockData.Users.Count;
            for (int i = 1; i < 300; i++)
            {
                int contractorId = rnd.Next(1, usersCount);
                _tasks.Add(new T.Task()
                {
                    Id = i,
                    Description = $"Description of task {i}. Created {DateTime.Now.ToString()}",
                    Subject = $"Task {i}",
                    UserId = contractorId
                });
            }

        }

        public List<T.Task> Tasks => _tasks;

    }
}
