using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IRepository<T> : IDisposable where T: class 
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        void Save();
    }
}
