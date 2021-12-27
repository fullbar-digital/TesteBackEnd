using Domain.Entities;
using Dominio.Validador;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Dominio.Entidades
{
    public class CursoDisciplina : Base
    {
        public virtual int CursoCodigo { get; set; }
        public Curso Curso { get; set; }
        public virtual int DisciplinaCodigo { get; set; }
        public Disciplina Disciplina { get; set; }
        public DateTime? DataCriacao { get; set; }

        public CursoDisciplina(){}

        public CursoDisciplina(int cursoCodigo, Curso curso, int disciplinaCodigo, Disciplina disciplina)
        {
            CursoCodigo = cursoCodigo;
            Curso = curso;
            DisciplinaCodigo = disciplinaCodigo;
            Disciplina = disciplina;
        }
        public override bool Validate()
        {
            var validador = new CursoDisciplinaValidador();
            var validation = validador.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
