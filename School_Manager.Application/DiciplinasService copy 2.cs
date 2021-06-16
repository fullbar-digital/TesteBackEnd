using System;
using System.Threading.Tasks;
using School_Manager.Application.Interface;
using School_Manager.Domain;
using School_Manager.Persistence;

namespace School_Manager.Application
{
    public class DiciplinasService : IDiciplinaService
    {
        private readonly IGenerica generica;
        private readonly ISchool school;

        public DiciplinasService(IGenerica _generica, ISchool _school)
        {
            generica = _generica;
            school = _school;
        }
        public async Task<Diciplina> AddDiciplinas(Diciplina model)
        {
            try
            {
                generica.Add<Diciplina>(model);
                if (await generica.SalveChangesAsync())
                {
                    return await school.GetAllDiciplinaByIDAsync(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<Diciplina> GetAllDiciplinaByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Diciplina[]> GetAllDiciplinasAsync()
        {
            try
            {
                var diciplinas = await school.GetAllDiciplinasAsync();
                if (diciplinas == null) return null;

                return diciplinas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
                ;
            }
        }

 
    }
}