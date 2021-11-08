using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBackend.Domain.Models;
using TesteBackend.Domain.Exceptions;

namespace TesteBackend.Domain.Repositories
{
    public interface IAlunoRepository
    {
        public Aluno Add(Aluno aluno);
        public Aluno Get(int ra);
        public IList<Aluno> GetAluno(Func<Aluno, bool> filtro);
        public Aluno Edit(Aluno alunoEdit);
        public void Remove(int ra);
    }

    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly ICursoRepository _cursoRepository;

        public AlunoRepository(DbBackendContext context, ICursoRepository cursoRepository) : base(context)
        {
            this._cursoRepository = cursoRepository;
        }

        /// <summary>
        /// Adicionar aluno ao repositório
        /// </summary>
        /// <param name="alunoModel">Aluno para cadastro</param>
        /// <returns>Retorna aluno cadastrado</returns>
        /// <exception cref="NotFoundException">Item não localizado</exception>
        public Aluno Add(Aluno alunoModel)
         {
            Curso cursoDb = this._cursoRepository.Get(alunoModel.CursoId);

            #region Análise curso correto
            if (cursoDb is null)
                throw new NotFoundException("O curso informado não foi localizado");

            if (cursoDb.Disciplinas.Count == 0)
                throw new OperationCanceledException("Não é permitido cadastrar aluno em um curso que não possui disciplinas cadastradas"); 
            #endregion

            Aluno alunoNovo = new Aluno(nome: alunoModel.Nome,
                                        periodo: alunoModel.Periodo,
                                        curso: cursoDb,
                                        foto: alunoModel.Foto,
                                        matriculas: new List<Matricula>());

            foreach (var disciplinaCurso in cursoDb.Disciplinas)
            {
                var nota = alunoModel
                                .Matricula
                                .Where(m => m.DisciplinaId == disciplinaCurso.Id)
                                .Select(m => new
                                {
                                    DisciplinaId = m.DisciplinaId,
                                    Nota = m.Nota
                                })
                                .FirstOrDefault();

                #region Análise disciplinas corretas
                if (nota is null)
                    throw new NotFoundException($"A disciplina de ID:{disciplinaCurso.Id} não localizada no curso informado");

                if (nota.DisciplinaId <= 0)
                    throw new NotFoundException($"Não localizada a nota para a disciplina {disciplinaCurso.Nome}"); 
                #endregion

                var matricula = new Matricula(aluno: alunoNovo, disciplina: disciplinaCurso, nota: nota.Nota);

                alunoNovo.Matricula.Add(matricula);
            }

            AtualizarStatusAluno(alunoNovo);

            this.dbSets.Add(alunoNovo);
            this.Save();

            return alunoNovo;
        }

        /// <summary>
        /// Consulta de aluno
        /// </summary>
        /// <param name="ra">Registro Acadêmico (RA) do aluno</param>
        /// <returns>Retorna aluno</returns>
        public Aluno Get(int ra)
            => this.dbSets
                       .Include(a => a.Curso)
                       .Include(a => a.Matricula)
                       .ThenInclude(m => m.Disciplina)
                       .Where(a => a.Ra == ra)
                       .FirstOrDefault();

        /// <summary>
        /// Consulta lista de alunos
        /// </summary>
        /// <param name="filtro">Filtro para pesquisa de alunos</param>
        /// <returns>Retorna lista de alunos</returns>
        public IList<Aluno> GetAluno(Func<Aluno, bool> filtro)
            => this.dbSets.Include(a => a.Curso)
                             .Include(a => a.Matricula)
                             .ThenInclude(m => m.Disciplina)
                             .Where(filtro)
                             .ToList();

        /// <summary>
        /// Edita os dados do aluno
        /// </summary>
        /// <param name="alunoEdit">Modelo de aluno para alteração</param>
        /// <returns>Retorna aluno após alteração dos dados</returns>
        /// <exception cref="NotFoundException">Item não localizado</exception>
        public Aluno Edit(Aluno alunoEdit)
        {
            Aluno alunoDb = this.dbSets.Include(a => a.Curso)
                                       .Include(a => a.Matricula)
                                       .ThenInclude(m => m.Disciplina)
                                       .Where(a => a.Ra == alunoEdit.Ra)
                                       .FirstOrDefault();

            if (alunoDb is null)
                throw new NotFoundException($"Aluno RA {alunoEdit.Ra} não encontrado");

            alunoDb.Nome = alunoEdit.Nome;
            alunoDb.Periodo = alunoEdit.Periodo;
            alunoDb.Foto = alunoEdit.Foto;

            foreach (var matricula in alunoDb.Matricula)
            {
                var notaNova = alunoEdit.Matricula.Where(ae => ae.DisciplinaId == matricula.Disciplina.Id)
                                                  .Select(m => new {
                                                      Disciplina = m.DisciplinaId,
                                                      Nota = m.Nota
                                                  }).SingleOrDefault();

                if (notaNova is null)
                    throw new NotFoundException($"Não encontrada a nota para a disciplina {matricula.Disciplina.Nome}");
                
                matricula.AtualizaNota(notaNova.Nota);
            }

            AtualizarStatusAluno(alunoDb);

            this.Save();
            return alunoDb;
        }

        /// <summary>
        /// Exclusão de aluno
        /// </summary>
        /// <param name="ra">Registro Acadêmico (RA) do aluno</param>
        /// <exception cref="KeyNotFoundException">Item não localizado para exclusão</exception>
        public void Remove(int ra)
        {
            Aluno alunoDb = this.dbSets
                                    .Include(a => a.Matricula)
                                    .Where(a => a.Ra == ra)
                                    .FirstOrDefault();

            if (alunoDb is null)
                throw new KeyNotFoundException($"Aluno RA {ra} não localizado");
            
            this.dbSets.Remove(alunoDb);
            this.Save();
        }


        private static void AtualizarStatusAluno(Aluno alunoNovo)
        {
            StatusResult statusAluno = alunoNovo
                                            .Matricula
                                            .Where(m => m.Status == StatusResult.Reprovado)
                                            .Select(m => m.Status)
                                            .DefaultIfEmpty(StatusResult.Aprovado)
                                            .FirstOrDefault();

            alunoNovo.AlterarStatus(statusAluno);
        }

        private void Save() => this.context.SaveChanges();

    }
}
