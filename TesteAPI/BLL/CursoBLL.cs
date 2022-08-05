using AutoMapper;
using System.Linq;

namespace TesteAPI.BLL
{
    public class CursoBLL : Interfaces.ICursoBLL
    {

        private readonly DAL.Repositories.Interfaces.IUnitOfWork _uow;
        private readonly IMapper _mapper;


        public CursoBLL(DAL.Repositories.Interfaces.IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void CadastrarCurso(MLL.ViewObject.CursoVO cursoVO)
        {
            var cursoBase = _uow.CursoRepositorio.GetAll(x => x.Nome == cursoVO.Nome).FirstOrDefault();

            if (!(cursoBase is null))
                throw new System.Exception("Curso ja cadastrado com o nome informado");

            if(cursoVO.Disciplinas == null || cursoVO.Disciplinas.Count == 0)
                throw new System.Exception("Curso sem disciplinas informadas.");

            _uow.CursoRepositorio.Adicionar(_mapper.Map<MLL.Curso>(cursoVO));
        }               
    }
}
