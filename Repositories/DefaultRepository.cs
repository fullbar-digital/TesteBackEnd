using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DefaultRepository<TEntity> : IDefaultRepository<TEntity> where TEntity : class
    {
        protected EfDbContext _context;
        private DbSet<TEntity> Entity { get { return _context.Set<TEntity>(); } }

        public DefaultRepository(EfDbContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return Entity.AsNoTracking().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.AsNoTracking().Count(predicate);
        }

        public TEntity Add(TEntity obj)
        {
            Entity.Add(obj);
            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public void Delete(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.AsNoTracking().Any(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate, string[] CollectionPaths = null, string[] ReferencePaths = null)
        {
            var ent = Entity.Single(predicate);

            if (CollectionPaths != null)
                foreach (var path in CollectionPaths)
                {
                    _context.Entry(ent).Collection(path).Load();
                }

            if (ReferencePaths != null)
                foreach (var path in ReferencePaths)
                {
                    _context.Entry(ent).Reference(path).Load();
                }

            return ent;
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> predicate, string[] CollectionPaths = null, string[] ReferencePaths = null)
        {
            var list = Entity
                .Where(predicate).ToList();

            if (ReferencePaths != null)
                foreach (var path in ReferencePaths.ToList())
                {
                    foreach (var item in list)
                    {
                        var reference = _context.Entry(item).Reference(path);
                        if (!reference.IsLoaded)
                            reference.Load();
                    }
                }

            if (CollectionPaths != null)
                foreach (var path in CollectionPaths.ToList())
                {
                    foreach (var item in list)
                    {
                        var reference = _context.Entry(item).Collection(path);
                        if (!reference.IsLoaded)
                            reference.Load();
                    }
                }

            return list;
        }
    }
}

