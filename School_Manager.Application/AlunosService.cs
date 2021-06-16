using System;
using System.Threading.Tasks;
using School_Manager.Application.Interface;
using School_Manager.Domain;
using School_Manager.Persistence;

namespace School_Manager.Application
{
    public class AlunosService : IAlunosService
    {
        private readonly IGenerica generica;
        private readonly ISchool school;

        public AlunosService(IGenerica _generica, ISchool _school)
        {
            generica = _generica;
            school = _school;
        }
        public async Task<Aluno> AddAlunos(Aluno model)
        {
            try
            {
                generica.Add<Aluno>(model);
                if (await generica.SalveChangesAsync())
                {
                    return await school.GetAllAlunoByIDAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Aluno> UpdateAluno(int alunoId, Aluno model)
        {
            try
            {
                var aluno = await school.GetAllAlunoByIDAsync(alunoId);
                if (aluno == null) return null;
                model.Id = aluno.Id;

                generica.Update(model);
                if (await generica.SalveChangesAsync())
                {
                    return await school.GetAllAlunoByIDAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAluno(int alunoId)
        {
            try
            {
                var aluno = await school.GetAllAlunoByIDAsync(alunoId);
                if (aluno == null) throw new Exception("Nao encontrado.");

                generica.Delete<Aluno>(aluno);
                return await generica.SalveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<Aluno[]> GetAllAlunosAsync()
        {
            try
            {
                var alunos = await school.GetAllAlunosAsync();
                if (alunos == null) return null;

                return alunos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }

        public async Task<Aluno> GetAllAlunoByIDAsync(int id)
        {
            try
            {
                var aluno = await school.GetAllAlunoByIDAsync(id);
                if (aluno == null) return null;

                return aluno;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }

        public async Task<Aluno> GetAllAlunoByNomeAsync(string nome)
        {
            try
            {
                var aluno = await school.GetAllAlunoByNomeAsync(nome);
                if (aluno == null) return null;

                return aluno;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }

        public async Task<Aluno> GetAllAlunoByRAAsync(int ra)
        {
            try
            {
                var aluno = await school.GetAllAlunoByRAAsync(ra);
                if (aluno == null) return null;

                return aluno;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }


        public async Task<Aluno[]> GetAllAlunosByStatusAsync(bool status)
        {
            try
            {
                var alunos = await school.GetAllAlunosByStatusAsync(status);
                if (alunos == null) return null;

                return alunos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                
            }
        }
    }
}