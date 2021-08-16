using FullbarDigital.CadastroDeAlunos.Dominio.Interfaces;
using FullbarDigital.CadastroDeAlunos.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FullbarDigital.CadastroDeAlunos.Dominio
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoService(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public void DeleteAluno(long id)
        {
            _alunoRepository.DeleteAluno(id);
        }

        public List<Aluno> GetAlunos(string nome, string ra, string curso, string status)
        {
            return _alunoRepository.GetAlunos(nome, ra, curso, status);
        }

        public List<Historico> GetHistorico(long idAluno)
        {
            return _alunoRepository.GetHistorico(idAluno);
        }

        public long InsertAluno(Aluno aluno)
        {
            var diciplinas = _alunoRepository.GetDiciplinas(aluno.CursoId);
            foreach (var item in diciplinas)
            {
                if(!(aluno.Historicos.Any(x => x.DiciplinaId == item.Id)))
                {
                    aluno.Historicos.Add(new Historico
                    {
                        DiciplinaId = item.Id,
                        Nota = 0
                    });
                }
            }
            return _alunoRepository.InsertAluno(aluno);
        }

        public long InsertCurso(Curso curso)
        {
            return _alunoRepository.InsertCurso(curso);
        }

        public long InsertDiciplina(Diciplina diciplina)
        {
            return _alunoRepository.InsertDiciplina(diciplina);
        }

        public void UpdateAluno(Aluno aluno)
        {
            _alunoRepository.UpdateAluno(aluno);
        }

        public void UpdateHistorico(Historico historico) 
        {
            var diciplina = _alunoRepository.GetDiciplina(historico.DiciplinaId);
            
            if (historico.Nota >= diciplina.NotaMinima)
            {
                historico.Status = "Aprovado";
            }
            else
            {
                historico.Status = "Reprovado";
            }

            _alunoRepository.UpdateHistorico(historico);
        }
    }
}
