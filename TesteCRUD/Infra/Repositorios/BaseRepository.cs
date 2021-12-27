using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Dominio.Entidades;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepositorio<T> where T : Base
    {
        private readonly Infra.Contexto.Contexto _contexto;

        public BaseRepository(Infra.Contexto.Contexto context)
        {
            _contexto = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _contexto.Add(obj);
            await _contexto.SaveChangesAsync();

            return obj;
        }

        public virtual async Task<T> Update(T obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();

            return obj;
        }

        public virtual async Task Remove(long id)
        {
            var obj = await Get(id);

            if (obj != null)
            {
                _contexto.Remove(obj);
                await _contexto.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(long id)
        {
            try
            {
                var obj = await _contexto.Set<T>()
                                    .AsNoTracking()
                                    .Where(x => x.Codigo == id)
                                    .ToListAsync();

                return obj.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual async Task<List<T>> Get()
        {
            return await _contexto.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }
    }
}
