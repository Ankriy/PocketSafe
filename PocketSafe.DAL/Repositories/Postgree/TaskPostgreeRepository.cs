using Dapper;
using Npgsql;
using PocketSafe.Domain.Repository;
using T = PocketSafe.Domain.Models;

namespace TaskProject.DAL.Repositories
{
    public class TaskPostgreeRepository : ITaskRepository, IRepository<T.Task>
    {
        private readonly NpgsqlConnection _connection;

        public TaskPostgreeRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        public T.Task Create(T.Task item)
        {
            //item.CreatedDate = DateTime.UtcNow;

            var query = $"INSERT INTO public.\"Task\"(\"Subject\", \"Description\", \"UserId\")" +
                $"VALUES('{item.Subject}', '{item.Description}','{item.UserId}') RETURNING \"Id\";";

            item.Id = _connection.ExecuteScalar<int>(query);

            return item;
        }
        public void Delete(int id)
        {
            _connection.Execute("DELETE public.\"Task\" WHERE \"Id\" = @Id", new { Id = id });
        }
        public T.Task Get(int id)
        {
            var task = _connection.Query<T.Task>($"SELECT * FROM public.\"Task\" WHERE \"Id\" = {id}").FirstOrDefault();
            return task;
        }
        public ICollection<T.Task> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Subject\" ilike 'search%' or \"Description\" ilike 'search%'";

            var tasks = _connection.Query<T.Task>($"SELECT * FROM public.\"Task\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return tasks ?? new List<T.Task>();
        }
        public ICollection<T.Task> Get(string search, int skip, int take, int userid)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? $"WHERE \"UserId\" = {userid}" : $"WHERE \"Subject\" ilike 'search%' or \"Description\" ilike 'search%' and \"UserId\" = {userid}";
            string a = $"SELECT * FROM public.\"Task\" {searchQuery} ORDER BY \"Id\" OFFSET {skip} LIMIT {take}";
            var tasks = _connection.Query<T.Task>($"SELECT * FROM public.\"Task\" {searchQuery} ORDER BY \"Id\" OFFSET {skip} LIMIT {take}").ToList();
            return tasks ?? new List<T.Task>();
        }
        public int Count()
        {
            var count = _connection.Query($"SELECT * FROM public.\"Task\"").Count();
            return count;
        }
        public int Count(int userid)
        {
            var count = _connection.Query($"SELECT * FROM public.\"Task\" Where \"UserId\" = {userid}").Count();
            return count;
        }
        public void Update(T.Task item)
        {
            _connection.Execute($"UPDATE public.\"Task\" SET \"Subject\" = '{item.Subject}', \"Description\" = '{item.Description}', \"UserId\" = '{item.UserId}' WHERE \"Id\" = {item.Id}");
        }

        
    }
}
