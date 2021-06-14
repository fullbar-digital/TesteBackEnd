using Fullbar.Teste.Domain.Entities;
using Fullbar.Teste.Infra.Context;
using Fullbar.Teste.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fullbar.Teste.Infra.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Aluno> ObterAlunoCursoDisciplinas(Guid id)
        {
            return await Db.Alunos.AsNoTracking()
                .Include(a => a.Curso)
                .Include(a => a.Curso.Disciplinas)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Aluno>> ObterAlunosCursoDisciplinas()
        {
            return await Db.Alunos.AsNoTracking()
                .Include(a => a.Curso)
                .Include(a => a.Curso.Disciplinas)
                .ToListAsync();
        }

        public async Task<Aluno> Obter(Aluno aluno)
        {
            return await Db.Alunos.AsNoTracking()
                .Include(a => a.Curso)
                .Include(a => a.Curso.Disciplinas)
                .FirstOrDefaultAsync(c => c.Id == aluno.Id || c.Nome == aluno.Nome || c.Periodo == aluno.Periodo || c.RA == c.RA || c.Status == c.Status);
        }
    }
}