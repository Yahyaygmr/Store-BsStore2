using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
           _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            if (trackChanges)
            {
                return _context.Set<T>();
            }
            else
            {
                return _context.Set<T>().AsNoTracking();
            }

        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            if (trackChanges)
            {
                return _context.Set<T>().Where(expression).SingleOrDefault();
            }
            else
            {
                return _context.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();
            }
        }

        public void Update(T entity)
        {
           _context.Set<T>().Update(entity);
        }
    }
}
