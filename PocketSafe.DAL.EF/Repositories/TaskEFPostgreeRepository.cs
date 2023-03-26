using PocketSafe.Domain.Repository;
using PocketSafe.DAL.EF;
using T = PocketSafe.Domain.Models;
using PocketSafe.Domain.Models;

namespace PocketSafe.DAL.EF.Repositories
{
    public class TaskEFPostgreeRepository : ITaskRepository, IRepository<T.Task>
    {

        private readonly PostgreeContext _context;

        public TaskEFPostgreeRepository(PostgreeContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Task.Count();
        }

        public int Count(int userid)
        {
            return _context.Task.Where(x => x.UserId == userid).Count();
        }

        public T.Task Create(T.Task item)
        {
            _context.Task.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var task = _context.Task.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _context.Task.Remove(task);
                _context.SaveChanges();
            }
        }

        public ICollection<T.Task> Get(string search, int skip, int take)
        {
            var tasks = _context.Task
                .Where(x => string.IsNullOrEmpty(search) || x.Subject.Contains(search) || x.Description.Contains(search))
                .Skip(skip)
                .Take(take)
                .ToList();

            return tasks;
        }

        public T.Task? Get(int id)
        {
            return _context.Task.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<T.Task> Get(string search, int skip, int take, int userid)
        {
            IQueryable<T.Task> query = _context.Task;
            if (!string.IsNullOrEmpty(search))
                query = query.Where(x => x.Subject.StartsWith(search) || x.Description.StartsWith(search));

            var tasks = query
                .OrderBy(p => p.Id)
                .Where(x => x.UserId == userid)
                .Skip(skip)
                .Take(take)
                .ToList();

            return tasks;
        }

        public void Update(T.Task item)
        {
            _context.Task.Update(item);
            _context.SaveChanges();
        }
    }
}
