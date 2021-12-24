using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Repositories
{
    public interface IDefaultRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity Update(TEntity obj);
        void Delete(TEntity obj);
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        TEntity Single(Expression<Func<TEntity, bool>> predicate, string[] CollectionPaths = null, string[] ReferencePaths = null);

        List<TEntity> Where(Expression<Func<TEntity, bool>> predicate, string[] CollectionPaths = null, string[] ReferencePaths = null);

    }
}
