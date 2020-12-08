using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly BaseContext _context;
        private DbSet<TEntity> _dataset;

        public BaseRepository(BaseContext context)
        {
            _context = context;
            _dataset = _context.Set<TEntity>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(o => o.Id.Equals(id));
                if (result == null)
                    return false;

                _dataset.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<TEntity> InsertAsync(TEntity item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }

                item.CreateAt = DateTime.UtcNow;
                _dataset.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                throw err;
            }

            return item;
        }

        public async Task<TEntity> SelectAsync(Guid id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(o => o.Id.Equals(id));
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<IEnumerable<TEntity>> SelectAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                if (result == null)
                {
                    return null;
                }

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public Task<bool> ExistAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable> ListarAlunos()
        //{
        //    try
        //    {
        //        var alunos = _context.Alunos
        //                       .Include(o => o.Curso)
        //                       .Include(o => o.Curso.Disciplinas)
        //                       .Include(o => o.RelacaoAlunoDisciplinas).ToListAsync();

        //        return await (Task<IEnumerable>)(IEnumerable)alunos;

        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //}
    }
}