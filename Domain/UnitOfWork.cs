using System.Linq.Expressions;
using Domain.Abstract;
using Domain.Repositories;

namespace Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _dbContext;
        public UnitOfWork()
        {
            _dbContext = new EFDbContext();
        }

        public GenericRepository<T> GetGenericRepository<T>() where T : class 
        {
            return new GenericRepository<T>(_dbContext);
        }

        public TRepository GetRepository<TRepository>() where TRepository : BaseRepository, new()
        {
            var repository = new TRepository();
            repository.Init(_dbContext);

            return repository;
        }
    }
}
