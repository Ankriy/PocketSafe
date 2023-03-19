using Dapper;
using Npgsql;
using PocketSafe.DAL;
using PocketSafe.DAL.Repositories.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskProject.DAL.Repositories
{
    public class UserPostgreeRepository : IUserRepository, IRepository<User>
    {
        private readonly NpgsqlConnection _connection;

        public UserPostgreeRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
        }
        public User Create(User item)
        {
            //item.CreatedDate = DateTime.UtcNow;

            var query = $"INSERT INTO public.\"User\"(\"Name\", \"Surname\", \"Email\")" +
                $"VALUES('{item.Name}', '{item.SurName}','{item.Email}');" +
                $"SELECT CAST(SCOPE_IDENTITY() as int)\"";

            item.Id = _connection.ExecuteScalar<int>(query);

            return item;
        }
        public void Delete(int id)
        {
            _connection.Execute("DELETE public.\"User\" WHERE Id = @Id", new { Id = id });
        }
        public User Get(int id)
        {
            var user = _connection.Query<User>($"SELECT * FROM public.\"User\" WHERE \"Id\" = {id}").FirstOrDefault();
            return user;
        }
        public ICollection<User> Get(string search, int skip, int take)
        {
            var searchQuery = string.IsNullOrWhiteSpace(search) ? "" : $"WHERE \"Name\" ilike 'search%' or \"Surname\" ilike 'search%'";

            var users = _connection.Query<User>($"SELECT * FROM public.\"User\" {searchQuery} OFFSET {skip} LIMIT {take}").ToList();
            return users ?? new List<User>();
        }
        public int Count()
        {
            var count = _connection.Query($"SELECT * FROM public.\"User\"").Count();
            return count;
        }
        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        
    }
}
