using Dominio.Entidades;
using Infra.Interfaces;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repositorios
{
    public class DisciplinaRepositorio : BaseRepository<Disciplina>, IDisciplinaRepositorio
    {
        private readonly Contexto.Contexto _contexto;
        public DisciplinaRepositorio(Contexto.Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }
    }
}
