using AppAlunos.Business.Intefaces;
using AppAlunos.Business.Models;
using AppAlunos.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAlunos.Data.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MeuDbContext context) : base(context)
        {

        }

        public virtual async Task RemoverAsync(Guid id)
        {
            DbSet.Remove(new Aluno { Id = id });
            await Db.SaveChangesAsync();
        }

        public List<Aluno> RetornarAlunosCursoDisciplina()
        {
            var alunos = Db.Alunos
                .Include(x => x.Curso)
                .Include(x => x.AlunosDisciplinas).ToList();

            return alunos;

        }

        public List<Aluno> RetornarAlunosFiltro(string filtro, string valor)
        {
            if (filtro == "status")
            {
                var query = (from AlunoDisciplina in Db.AlunoDisciplinas
                             join Aluno in Db.Alunos on AlunoDisciplina.AlunoId equals Aluno.Id
                             where AlunoDisciplina.Status == valor
                             select AlunoDisciplina).ToList(); //serve para a propriedade AlunosDisciplinas não vir nulo,
                                                               //tive dificuldades para fazer esse join, e essa foi a única forma que encontrei

                var aluno = (from AlunoDisciplina in Db.AlunoDisciplinas
                             join Aluno in Db.Alunos on AlunoDisciplina.AlunoId equals Aluno.Id
                             where AlunoDisciplina.Status == valor
                             select Aluno).Distinct().ToList();

                return aluno.Count == 0 ? new List<Aluno>() : aluno;
            }

            return filtro switch
            {
                "nome" => Db.Alunos
                    .Where(x => x.Nome.Contains(valor)).Include(x => x.Curso).Include(x => x.AlunosDisciplinas).ToList(),
                "ra" => Db.Alunos
                    .Where(x => x.RegistroAcademico.Contains(valor)).Include(x => x.Curso).Include(x => x.AlunosDisciplinas).ToList(),
                "curso" => Db.Alunos
                    .Where(x => x.Curso.Nome.Contains(valor)).Include(x => x.Curso).Include(x => x.AlunosDisciplinas).ToList(),
                _ => new List<Aluno>()
            };
        }
    }
}
