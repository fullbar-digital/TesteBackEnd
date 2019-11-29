using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.BLL.Interfaces;
using CRUD.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD.API
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        IAlunoBusiness alunoBusiness;

        public AlunoController(IAlunoBusiness _alunoBusiness)
        {
            alunoBusiness = _alunoBusiness;
        }


        [HttpGet]
        public List<AlunoViewModel> Get()
        {
           return alunoBusiness.GetAll();
        }

        [HttpPost("filter")]
        public List<AlunoViewModel> Get(FilterViewModel filter)
        {
            return alunoBusiness.GetByFilter(filter);
        }

        [HttpGet("{id}")]
        public AlunoViewModel Get(int id)
        {
            return alunoBusiness.GetById(id);
        }

        [HttpPost]
        public bool Post(AlunoViewModel aluno)
        {
            return alunoBusiness.Save(aluno);
        }

        [HttpPut("{id}")]
        public bool Put(int id, AlunoViewModel aluno)
        {
            return alunoBusiness.Update(id, aluno);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return alunoBusiness.Delete(id);
        }
    }
}
