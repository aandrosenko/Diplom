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
    }
}
