using Dapper;
using Npgsql;
using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProject.DAL.Repositories
{
    public class TaskPostgreeRepository : ITaskRepository, IRepository<Task>
    {
        private readonly NpgsqlConnection _connection;

        public TaskPostgreeRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        public Task Create(Task item)
        {
            //item.CreatedDate = DateTime.UtcNow;

            var query = $"INSERT INTO public.\"Task\"(\"Subject\", \"Description\", \"userId\")" +
                $"VALUES('{item.Subject}', '{item.Description}','{item.UserId}');" +
                $"SELECT CAST(SCOPE_IDENTITY() as int)\"";

            item.Id = _connection.ExecuteScalar<int>(query);

            return item;
        }
        public void Delete(int id)
        {
            _connection.Execute("DELETE public.\"Task\" WHERE Id = @Id", new { Id = id });
        }
        public Task Get(int id)
        {
            var user = _connection.Query<Task>($"SELECT * FROM public.\"Task\" WHERE \"Id\" = {id}").FirstOrDefault();
            return user;
        }
        public ICollection<Task> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Subject\" ilike 'search%' or \"Description\" ilike 'search%'";

            var users = _connection.Query<Task>($"SELECT * FROM public.\"Task\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return users ?? new List<Task>();
        }
        public int Count()
        {
            var count = _connection.Query($"SELECT * FROM public.\"Task\"").Count();
            return count;
        }
        public void Update(Task item)
        {
            throw new NotImplementedException();
        }
    }
}
