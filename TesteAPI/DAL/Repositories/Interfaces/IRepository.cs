using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TesteAPI.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {      
        T GetByID(object id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null);
        bool Adicionar(T entity);
        bool Atualizar(T entity);
        bool Deletar(T entity);
    }
}
