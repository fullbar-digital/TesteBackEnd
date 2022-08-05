using System.Collections.Generic;
using TesteAPI.MLL.ViewObject;

namespace TesteAPI.BLL.Interfaces
{
    public interface IAlunoBLL
    {
        void CadastrarAluno(MLL.ViewObject.AlunoVO alunoVO);
        List<MLL.ViewObject.AlunoDetailsVO> GetAlunoPorCampo(FiltroVO filtroVO);
        List<MLL.ViewObject.AlunoDetailsVO> GetAllAlunos();
        bool AlterarAluno(MLL.ViewObject.AlunoVO alunoVO);
        bool DeletarAluno(string ra);

    }
}
