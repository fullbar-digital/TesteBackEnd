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
    public class CursoRepositorio : BaseRepository<Curso>, ICursoRepositorio 
    {
        private readonly Contexto.Contexto _contexto;

        public CursoRepositorio(Contexto.Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
        public async Task<List<Curso>> ListaCursoPorNome(string nome)
        {
            var lista = await _contexto.Curso.Where(
                    x => x.Nome == nome
                ).AsNoTracking().ToListAsync();

            return lista;
        }
    }
}
