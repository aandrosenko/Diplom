using Domain.Repositories;

namespace Domain.Abstract
{
    public interface IUnitOfWork
    {
        GenericRepository<T> GetGenericRepository<T>() where T : class;

        TRepository GetRepository<TRepository>() where TRepository : BaseRepository, new();
    }
}
