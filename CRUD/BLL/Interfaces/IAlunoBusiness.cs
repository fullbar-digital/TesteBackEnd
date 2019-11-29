using System;
using System.Collections.Generic;
using CRUD.ViewModel;

namespace CRUD.BLL.Interfaces
{
    public interface IAlunoBusiness
    {
        List<AlunoViewModel> GetAll();
        AlunoViewModel GetById(int id);
        bool Update(int id, AlunoViewModel aluno);
        bool Save(AlunoViewModel aluno);
        bool Delete(int id);
        List<AlunoViewModel> GetByFilter(FilterViewModel filter);
    }
}
