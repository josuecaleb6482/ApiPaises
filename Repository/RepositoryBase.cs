using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Paises.Models;
using Microsoft.EntityFrameworkCore;

namespace Paises.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected CountriesContext RepositoryContext { get; set; } 
        public RepositoryBase(CountriesContext RepositoryContext)
        {
            this.RepositoryContext = RepositoryContext;
        }
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
            this.RepositoryContext.SaveChangesAsync();
        }

        public System.Linq.IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public System.Linq.IQueryable<T> FindCondition(Expression<System.Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
            this.RepositoryContext.SaveChangesAsync();
        }
    }
}