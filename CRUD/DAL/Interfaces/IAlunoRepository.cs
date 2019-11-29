using System;
using System.Collections.Generic;
using CRUD.Model;
using CRUD.ViewModel;

namespace CRUD.DAL.Interfaces
{
    public interface IAlunoRepository
    {

        Aluno GetById(int id);

        List<Aluno> GetAll();

        bool Insert(Aluno item);

        bool Update(Aluno item);

        bool Delete(Aluno item);
        List<Aluno> GetByFilter(FilterViewModel filter);
    }
}
