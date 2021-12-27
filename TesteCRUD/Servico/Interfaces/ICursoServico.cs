using Servico.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Interfaces
{
    public interface ICursoServico
    {
        Task<CursoDTO> Create(CursoDTO cursoDTO);
        Task<CursoDTO> Update(CursoDTO cursoDTO);
        Task Remove(int codigo);
        Task<CursoDTO> Get(int codigo);
        Task<List<CursoDTO>> Get();
        Task<CursoDisciplinaDTO> AddDisciplina(CursoDisciplinaDTO cursoDisciplinaDTO);
        Task DelDisciplina(CursoDisciplinaDTO cursoDisciplinaDTO);
    }
}
