using Dominio.Entidades;
using Infra.Interfaces;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class AlunoDisciplinaRepositorio : BaseRepository<AlunoDisciplina>, IAlunoDisciplinaRepositorio
    {
        private readonly Contexto.Contexto _contexto;

        public AlunoDisciplinaRepositorio(Contexto.Contexto contexto) : base (contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<AlunoDisciplina>> ListaDisciplinas(int codigoAluno)
        {
            var lista = await _contexto.AlunoDisciplina.Where(
                    x => x.AlunoCodigo == codigoAluno
                ).AsNoTracking().ToListAsync();

            return lista;
        }

        public async Task<AlunoDisciplina> ListaPorAlunoDisciplina(int codigoAluno, int codigoDisciplina)
        {
            var lista = await _contexto.AlunoDisciplina.Where(
                    x => x.AlunoCodigo == codigoAluno && x.DisciplinaCodigo == codigoDisciplina
                ).AsNoTracking().ToListAsync();

            return lista.FirstOrDefault();
        }
        public async Task<List<AlunoDisciplina>> ListaAlunoPorStatus(string status)
        {
            var lista = await _contexto.AlunoDisciplina.Where(
                    x => x.Status == status
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
