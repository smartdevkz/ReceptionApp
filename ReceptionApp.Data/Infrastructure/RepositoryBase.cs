using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReceptionApp.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected DbContext DbContext;

        public RepositoryBase(DbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public T Get(int id)
        {
            return this.DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.DbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return this.DbContext.Set<T>().Where(predicate).ToList();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate).SingleOrDefault();
        }

        public void Add(T entity)
        {
            this.DbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.DbContext.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            this.DbContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.DbContext.Set<T>().RemoveRange(entities);
        }
    }
}
