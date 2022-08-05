using AutoMapper;
using System.Linq;

namespace TesteAPI.BLL
{
    public class DisciplinaBLL : Interfaces.IDisciplinaBLL
    {
        private readonly DAL.Repositories.Interfaces.IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public DisciplinaBLL(DAL.Repositories.Interfaces.IUnitOfWork  uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public void CadastrarDisciplina(MLL.ViewObject.DisciplinaVO disciplinaVO)
        {
            var cursoBase = _uow.DisciplinaRepositorio.GetAll(x => x.Nome == disciplinaVO.Nome).FirstOrDefault();

            if (cursoBase is null)
                throw new System.Exception("Disciplina ja cadastrada com o nome informado");

            _uow.DisciplinaRepositorio.Adicionar(_mapper.Map<MLL.Disciplina>(disciplinaVO));
        }
    }
}
