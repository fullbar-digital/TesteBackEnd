using BancoAlunos.Data;
using BancoAlunos.Interfaces;
using BancoAlunos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BancoAlunos.Repositories
{
    public class AlunosRepository : IAlunosRepository
    {
        #region Injecao de Dependecia
        private readonly AlunosContext _context;

        public AlunosRepository(AlunosContext context)
        {
            _context = context;
        }
        #endregion

        #region MetodosDB
        public List<Alunos> GetAllData()
        {
            return _context.DbAlunos.ToList();
        }
        public Alunos GetAlunosByIdData(int id)
        {
            return _context.DbAlunos.FirstOrDefault(p => p.Id == id);
        }
        public void PutAlunoData(Alunos aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
        }
        public void PostAlunoData(Alunos aluno)
        {
            _context.DbAlunos.Add(aluno);
        }
        public void DeleteAlunoData(Alunos aluno)
        {
            _context.DbAlunos.Remove(aluno);

        }
        public void SaveChangesAlunoData()
        {
            _context.SaveChanges();
        }
        

        public bool AlunoExistsData(int id)
        {
            return _context.DbAlunos.Any(e => e.Id == id);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
