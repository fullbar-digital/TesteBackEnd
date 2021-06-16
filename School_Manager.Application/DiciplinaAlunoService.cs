using System;
using System.Threading.Tasks;
using School_Manager.Application.Interface;
using School_Manager.Domain;
using School_Manager.Persistence;

namespace School_Manager.Application
{
    public class DiciplinaAlunoService : IDiciplinaAlunoService
    {
        private readonly IGenerica generica;
        private readonly ISchool school;

        public DiciplinaAlunoService(IGenerica _generica, ISchool _school)
        {
            generica = _generica;
            school = _school;
        }

        public async Task<DiciplinaAluno> AddDiciplinaAlunos(DiciplinaAluno model)
        {
             try
            {
                generica.Add<DiciplinaAluno>(model);
                if (await generica.SalveChangesAsync())
                {
                    return model;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public Task<DiciplinaAluno> GetAllDiciplinaAlunoByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

 
    }
}