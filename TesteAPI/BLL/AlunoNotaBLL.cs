using AutoMapper;
using System.Linq;
using TesteAPI.MLL.ViewObject;
using TesteAPI.MLL;
using System;

namespace TesteAPI.BLL
{
    public class AlunoNotaBLL : Interfaces.IAlunoNotaBLL
    {
        private readonly DAL.Repositories.Interfaces.IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public AlunoNotaBLL(DAL.Repositories.Interfaces.IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        
        public void CadastrarNota(NotaCadastroVO notaVO)
        {
            try
            {
                var alunoBase = _uow.AlunoRepositorio.GetAll(x => x.Registro_Academico == notaVO.RaAluno).FirstOrDefault();

                if (alunoBase is null)
                    throw new System.Exception("Aluno não encontrado");

                foreach (var nota in notaVO.Notas)
                {
                    AlunoNota alunoNota = new MLL.AlunoNota();

                    alunoNota.Disciplina = _uow.DisciplinaRepositorio.GetAll(x => x.Nome == nota.Disciplina_Nome).FirstOrDefault();
                    alunoNota.Aluno = alunoBase;
                    alunoNota.Nota = nota.Nota;

                    _uow.AlunoNotaRepositorio.Adicionar(alunoNota);
                }

                alunoBase.Status = GetStatusAluno(alunoBase);
                _uow.AlunoRepositorio.Atualizar(alunoBase);

                _uow.Commit();
            }
            catch(Exception ex)
            {
                throw ex;
            }           
        }

        private string GetStatusAluno(MLL.Aluno aluno)
        {
            var totalPontos = aluno.Notas.Sum(x => x.Nota);
            var qtdDisciplinas = aluno.Notas.Count();

            var media = totalPontos / qtdDisciplinas;

            return media >= 7 ? "APROVADO" : "REPROVADO";
        }
    }
}
