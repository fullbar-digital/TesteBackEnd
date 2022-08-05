using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TesteAPI.MLL.ViewObject;

namespace TesteAPI.BLL
{
    public class AlunoBLL : Interfaces.IAlunoBLL
    {
        private readonly DAL.Repositories.Interfaces.IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AlunoBLL(DAL.Repositories.Interfaces.IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void CadastrarAluno(MLL.ViewObject.AlunoVO alunoVO)
        {
            var alunoBase = _uow.AlunoRepositorio.GetAll(x => x.Registro_Academico == alunoVO.Registro_Academico).FirstOrDefault();

            if (!(alunoBase is null))
                throw new System.Exception("Aluno com RA informado ja existente");

            var curso = _uow.CursoRepositorio.GetAll(x => x.Nome == alunoVO.Nome_Curso).FirstOrDefault();
            if (curso is null)
                throw new System.Exception("Curso não encontrado");

            var alunoMapeado = _mapper.Map<MLL.Aluno>(alunoVO);

            alunoMapeado.CursoCodigo = curso.Codigo;                       

            _uow.AlunoRepositorio.Adicionar(alunoMapeado);
            _uow.Commit();

        }


        public List<AlunoDetailsVO> GetAlunoPorCampo(FiltroVO filtroVO)
        {
            List<MLL.Aluno> listaAlunos = null;

            if (filtroVO.TipoFiltro == TpFiltro.Nome)
                listaAlunos = _uow.AlunoRepositorio.GetAll(x => x.Nome == filtroVO.Valor).ToList();
            else if (filtroVO.TipoFiltro == TpFiltro.Status)
            {
                listaAlunos = _uow.AlunoRepositorio.GetAll().ToList();
                foreach (MLL.Aluno aluno in listaAlunos)
                {
                    if (aluno.Status == filtroVO.Valor)
                        listaAlunos.Add(aluno);
                }
            }
            else if (filtroVO.TipoFiltro == TpFiltro.Curso)
                listaAlunos = _uow.AlunoRepositorio.GetAll(x => x.Curso.Nome == filtroVO.Valor).ToList();
            else if (filtroVO.TipoFiltro == TpFiltro.Ra)
                listaAlunos = _uow.AlunoRepositorio.GetAll(x => x.Registro_Academico == filtroVO.Valor).ToList();

            List<MLL.ViewObject.AlunoDetailsVO> alunosVO = new List<MLL.ViewObject.AlunoDetailsVO>();

            foreach (MLL.Aluno aluno in listaAlunos)
            {
                alunosVO.Add(_mapper.Map<MLL.ViewObject.AlunoDetailsVO>(aluno));
            }

            return alunosVO;
        }

        public List<MLL.ViewObject.AlunoDetailsVO> GetAllAlunos()
        {
            var listaAlunos = _uow.AlunoRepositorio.GetAll();
            List<MLL.ViewObject.AlunoDetailsVO> alunosVO = new List<MLL.ViewObject.AlunoDetailsVO>();

            foreach (MLL.Aluno aluno in listaAlunos)
            {                
                var novoVO = _mapper.Map<MLL.ViewObject.AlunoDetailsVO>(aluno);

                alunosVO.Add(novoVO);
            }
            return alunosVO;
        }

        public bool AlterarAluno(MLL.ViewObject.AlunoVO alunoVO)
        {
            var alunoBase = _uow.AlunoRepositorio.GetAll(x => x.Registro_Academico == alunoVO.Registro_Academico).FirstOrDefault();

            if (alunoBase == null)
                throw new System.Exception("Aluno não encontrado");
           
            if (alunoBase.Status != alunoVO.Status)
                throw new System.Exception("Status não pode ser alterado");

            //var alunoMapeado = _mapper.Map<MLL.Aluno>(alunoVO);
            alunoBase.Codigo = alunoBase.Codigo;
            alunoBase.Curso = _uow.CursoRepositorio.GetAll(x => x.Nome == alunoVO.Nome_Curso).FirstOrDefault();
            alunoBase.Nome = alunoVO.Nome;
            alunoBase.Registro_Academico = alunoVO.Registro_Academico;
            alunoBase.Periodo = alunoVO.Periodo;           

            _uow.AlunoRepositorio.Atualizar(alunoBase);
            _uow.Commit();

            return true;
        }

        public bool DeletarAluno(string ra)
        {
            var alunoBase = _uow.AlunoRepositorio.GetAll(x => x.Registro_Academico == ra).FirstOrDefault();

            if (alunoBase is null)
                throw new System.Exception("Aluno não encontrado pelo Registro aacadêmico");


            _uow.AlunoRepositorio.Deletar(alunoBase);
            _uow.Commit();

            return true;
        }

        private string GetStatusAluno(MLL.Aluno aluno)
        {
            var totalPontos = aluno.Notas.Sum(x => x.Nota);
            var qtdDisciplinas = aluno.Notas.Count();

            var media = totalPontos / qtdDisciplinas;

            return media >= 7 ? "APROVADO" : "REPROVADO";
        }

       

    }
}
