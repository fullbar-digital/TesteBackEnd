using Cadastro.AlunosAPI.Data.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.AlunosAPI.Repository
{
    interface IAlunosRepository
    {
        Task<IEnumerable<AlunoVO>> FindAll();
        Task<AlunoVO> FindById(long id);
        Task<AlunoVO> Create(AlunoVO vo);
        Task<AlunoVO> Update(AlunoVO vo);
        Task<bool> Delete(long id);
    }
}
