using Roofstock.PM.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roofstock.PM.Service
{
    public interface IService<T> where T : Entity
    {
        T GetById(long id);
        IEnumerable<T> GetAll();
        IQueryable<T> FindAll(Expression<Func<T, bool>> predicate);
        bool Contains(Expression<Func<T, bool>> predicate);
        void AddOrUpdate(T item);
    }
}
