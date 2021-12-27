using Servico.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Interfaces
{
    public interface IAlunoServico
    {
        Task<AlunoDTO> Create(AlunoDTO alunoDTO);
        Task<AlunoDTO> Update(AlunoDTO alunoDTO);
        Task Remove(int codigo);
        Task<GetAlunoDTO> Get(int codigo);
        Task<List<AlunoDTO>> Get();
        Task<AlunoDisciplinaDTO> AdicionaDisciplina(AlunoDisciplinaDTO alunoDTO);
        Task<List<GetAlunoDTO>> ListaPorNome(string nome);
        Task<GetAlunoDTO> ListaPorRA(string RA);
        Task<List<GetAlunoDTO>> ListaPorStatus(string status);
        Task<List<GetAlunoDTO>> ListaPorCurso(string nomeCurso);
        Task<AlunoDisciplinaDTO> AdicionaNota(AlunoDisciplinaDTO alunoDTO);
    }
}
