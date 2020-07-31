using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using CRUD.DAL.Interfaces;
using CRUD.Model;
using CRUD.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL
{
    public class AlunoRepository : IAlunoRepository
    {
        protected readonly Infra.AppContext Context;

        public AlunoRepository(Infra.AppContext context)
        {
            Context = context;
        }

        public virtual Aluno GetById(int id)
        {
            return Context.Set<Aluno>().Find(id);
        }

        public virtual List<Aluno> GetAll()
        {
            return Context.Set<Aluno>().ToList();
        }

        public virtual bool Insert(Aluno item)
        {
            Context.Set<Aluno>().Add(item);

            return Save();
        }

        public virtual bool Update(Aluno item)
        {
            Context.Entry(item).State = EntityState.Modified;

            return Save();
        }

        public virtual bool Delete(Aluno item)
        {
            Context.Set<Aluno>().Remove(item);

            return Save();
        }

        private bool Save()
        {
            try
            {
                return Context.SaveChanges() > 0;
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Aluno> GetByFilter(FilterViewModel filter)
        {
            List<Aluno> list = Context.Set<Aluno>()
                .Where(x => (string.IsNullOrEmpty( filter.nome) || x.Nome == filter.nome) &&
                            (string.IsNullOrEmpty(filter.curso ) || x.Curso == filter.curso) &&
                            (string.IsNullOrEmpty(filter.registroAcademico) || x.RA == filter.registroAcademico)
                            ).ToList();

            return list.Where(x => (string.IsNullOrEmpty(filter.status) || x.status.ToLower() == filter.status.ToLower())).ToList();
        }
    }
}

