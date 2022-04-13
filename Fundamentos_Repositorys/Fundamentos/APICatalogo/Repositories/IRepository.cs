using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCatalogo.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get(); // retorna lista do tipo "IQueryable" podendo customizar
        T GetById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges(T entity);
    }
}
