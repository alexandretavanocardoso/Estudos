using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ApiCatalogo.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IQueryable<T> Get()
        {
            return _appDbContext.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _appDbContext.Set<T>().SingleOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _appDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            _appDbContext.Set<T>().Update(entity);
        }

        public void SaveChanges(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
