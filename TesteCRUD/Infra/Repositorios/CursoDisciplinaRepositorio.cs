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
    public class CursoDisciplinaRepositorio : BaseRepository<CursoDisciplina>, ICursoDisciplinaRepositorio
    {
        private readonly Contexto.Contexto _contexto;

        public CursoDisciplinaRepositorio(Contexto.Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<CursoDisciplina> ListaPorCursoDisciplina(CursoDisciplina cursoDisciplina)
        {
            var item = await _contexto.CursoDisciplina
                .Where(x => x.CursoCodigo == cursoDisciplina.CursoCodigo 
                && x.DisciplinaCodigo == cursoDisciplina.DisciplinaCodigo)
                .AsNoTracking()
                .ToListAsync();

            return item.FirstOrDefault();
        }

        public async Task<List<CursoDisciplina>> ListaPorCurso(int cursoCodigo)
        {
            var item = await _contexto.CursoDisciplina
                .Where(x => x.CursoCodigo == cursoCodigo)
                .AsNoTracking()
                .ToListAsync();

            return item;
        }

        public async Task<List<CursoDisciplina>> ListaPorDisciplina(int disciplinaCodigo)
        {
            var item = await _contexto.CursoDisciplina
                .Where(x => x.DisciplinaCodigo == disciplinaCodigo)
                .AsNoTracking()
                .ToListAsync();

            return item;
        }
    }
}
