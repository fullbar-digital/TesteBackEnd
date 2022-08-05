using System.Linq;
using System.Linq.Expressions;
using System;
using Microsoft.EntityFrameworkCore;

namespace TesteAPI.DAL.Repositories
{
    public class Repository<T> : Interfaces.IRepository<T> where T : class
    {
        private readonly DAL.Contexto _context;
        private Exception _erro = null;
        private DbSet<T> _dbSet;

        public Repository(Contexto context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Adicionar(T entity)
        {
            try
            {
                _context.Add<T>(entity);
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                _erro = ex;
                return false;
            }
           
        }

        public bool Atualizar(T entity)
        {
            try
            {
                _context.Update<T>(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }
        }

        public bool Deletar(T entity)
        {
            try
            {
                _context.Remove<T>(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _erro = ex;
                return false;
            }
        }

        public System.Linq.IQueryable<T> GetAll(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return _dbSet.Where(predicate);
            }
            return _dbSet.AsQueryable();
        }

        public T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

    }
}
