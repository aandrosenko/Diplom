using Domain.Repositories;

namespace Domain.Abstract
{
    public interface IUnitOfWork
    {
        GenericRepository<T> GetGenericRepository<T>() where T : class;
    }
}
