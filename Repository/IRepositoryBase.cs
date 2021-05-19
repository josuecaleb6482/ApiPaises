using System;
using System.Linq;
using System.Linq.Expressions;

namespace Paises.Repository
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindCondition(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}