using System;
using System.Data.Entity;
using System.Linq;
using Domain.Abstract;

namespace Domain.Repositories
{
    public class GenericRepository<T> : BaseRepository, IRepository<T> where T : class
    {
        private EFDbContext _dbContext;
        private DbSet<T> _dbSet;
        protected GenericRepository()
        {
        }
        internal GenericRepository(EFDbContext context)
        {
            Init(context);
        }
        
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T item)
        {
            _dbSet.Add(item);
        }

        public void Remove(int id)
        {
            var item = GetById(id);

            _dbSet.Remove(item);
        }

        public void Update(T item)
        {
            var entry = _dbContext.Entry(item);
            _dbSet.Attach(item);
            entry.State = EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public override void Init(EFDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
    }
}
