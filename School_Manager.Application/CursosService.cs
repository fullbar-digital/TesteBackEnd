using System;
using System.Threading.Tasks;
using School_Manager.Application.Interface;
using School_Manager.Domain;
using School_Manager.Persistence;

namespace School_Manager.Application
{
    public class CursosService : ICursoService
    {
        private readonly IGenerica generica;
        private readonly ISchool school;

        public CursosService(IGenerica _generica, ISchool _school)
        {
            generica = _generica;
            school = _school;
        }
        public async Task<Curso> AddCurso(Curso model)
        {
            try
            {
                generica.Add<Curso>(model);
                if (await generica.SalveChangesAsync())
                {
                    return await school.GetAllCursoByIDAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<Curso> GetAllCursoByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Curso[]> GetAllCursosAsync()
        {
            try
            {
                var cursos = await school.GetAllCursosAsync();
                if (cursos == null) return null;

                return cursos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }

 
    }
}