using AutoMapper;
using Domain.Interfaces.Repository;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Aluno
{
    public class AlunoRepository : BaseRepository<Domain.Entities.Aluno>, IAlunoRepository
    {
        private DbSet<Domain.Entities.Aluno> _dataset;
        private readonly IMapper _mapper;

        public AlunoRepository(BaseContext context, IMapper mapper) : base(context)
        {
            _dataset = context.Set<Domain.Entities.Aluno>();
            _mapper = mapper;
        }

        public List<Domain.Entities.Aluno> ListarAlunos()
        {
            try
            {
                var alunos = _context.Alunos.Include(o => o.Curso).Include(o => o.Curso.Disciplinas).Include(o => o.RelacaoAlunoDisciplinas).ToList();
                foreach (var aluno in alunos)
                {
                    var relacaoAlunoDisciplinas = _context.RelacaoAlunoDisciplinas.Where(o => o.RelacaoAlunoId.Equals(aluno.Id)).ToList();
                    aluno.RelacaoAlunoDisciplinas = relacaoAlunoDisciplinas;
                }

                return alunos;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<List<Domain.Entities.Aluno>> FiltrarAlunos(string filtrar, string parametro)
        {
            try
            {
                var filtro = parametro switch
                {
                    "nome" => await _context.Alunos.Where(x => x.Nome.Contains(filtrar))
                                                        .Include(o => o.Curso)
                                                        .Include(o => o.Curso.Disciplinas)
                                                        .Include(o => o.RelacaoAlunoDisciplinas)
                                                        .ToListAsync(),
                    "ra" => await _context.Alunos.Where(x => x.Ra.Contains(filtrar))
                                                        .Include(o => o.Curso)
                                                        .Include(o => o.Curso.Disciplinas)
                                                        .Include(o => o.RelacaoAlunoDisciplinas)
                                                        .ToListAsync(),
                    "curso" => await _context.Alunos.Where(x => x.Curso.Nome.Contains(filtrar))
                                                        .Include(o => o.Curso)
                                                        .Include(o => o.Curso.Disciplinas)
                                                        .Include(o => o.RelacaoAlunoDisciplinas)
                                                        .ToListAsync(),
                    "status" => await _context.Alunos.Where(x => x.Status.Contains(filtrar))
                                                        .Include(o => o.Curso)
                                                        .Include(o => o.Curso.Disciplinas)
                                                        .Include(o => o.RelacaoAlunoDisciplinas)
                                                        .ToListAsync(),
                    _ => throw new NotImplementedException()
                };

                foreach (var aluno in filtro)
                {
                    var relacaoAlunoDisciplinas = _context.RelacaoAlunoDisciplinas.Where(o => o.RelacaoAlunoId.Equals(aluno.Id)).ToList();
                    aluno.RelacaoAlunoDisciplinas = relacaoAlunoDisciplinas;
                }

                return filtro;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}