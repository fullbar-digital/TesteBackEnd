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
    public class AlunoRepositorio : BaseRepository<Aluno>, IAlunoRepositorio 
    {
        private readonly Contexto.Contexto _contexto;

        public AlunoRepositorio(Contexto.Contexto contexto) : base(contexto)
        {
            this._contexto = contexto;
        }
        public async Task<List<Aluno>> ListaAlunoPorNome(string nome)
        {
            var lista = await _contexto.Aluno.Where(
                    x => x.Nome.ToLower() == nome.ToLower()
                ).AsNoTracking().ToListAsync();

            return lista;
        }

        public async Task<Aluno> ListaAlunoPorRA(string ra)
        {
            var lista = await _contexto.Aluno.Where(
                    x => x.RA.ToLower() == ra.ToLower()
                ).AsNoTracking().ToListAsync();

            return lista.FirstOrDefault();
        }

        public async Task<List<Aluno>> ListaAlunoPorCurso(int codigo)
        {
            var lista = await _contexto.Aluno.Where(
                    x => x.CursoCodigo == codigo
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
