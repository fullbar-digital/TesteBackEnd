using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Aluno;
using TesteFullBar.API.ViewModels.Aluno.Query;
using TesteFullBar.Domain.Interfaces.Notifications;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Interfaces.UoW;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Validation.AlunoValidation;

namespace TesteFullBar.API.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainNotification _domainNotification;
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IAlunoDisciplinaRepository _alunoDisciplinaRepository;

        public AlunoService(IAlunoRepository alunoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IDomainNotification domainNotification,
            IDisciplinaRepository disciplinaRepository,
            IAlunoDisciplinaRepository alunoDisciplinaRepository)
        {
            _alunoRepository = alunoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainNotification = domainNotification;
            _disciplinaRepository = disciplinaRepository;
            _alunoDisciplinaRepository = alunoDisciplinaRepository;
        }

        public async Task<AlunoViewModel> GetByRaAsync(AlunoRaViewModel alunoVM)
        {
            return _mapper.Map<AlunoViewModel>(await _alunoRepository.GetByRaAsync(alunoVM.Ra));
        }

        public async Task<AlunoViewModel> GetByIdAsync(AlunoIdViewModel alunoVM)
        {
            var aluno = _mapper.Map<AlunoViewModel>(await _alunoRepository.GetByIdAsync(alunoVM.Id));

            var disciplinas = _alunoDisciplinaRepository.GetByAlunoIdAsync(aluno.Id);

            aluno.Disciplinas = disciplinas.Select(n => new AlunoDisciplinaViewModel()
            {
                DisciplinaId = n.DisciplinaId,
                Nota = n.Nota
            }).ToList();

            return aluno;
        }

        public AlunoViewModel Add(AlunoViewModel alunoVM)
        {
            AlunoViewModel viewModel = null;
            var model = _mapper.Map<Aluno>(alunoVM);

            MapearDisciplinasEStatus(alunoVM.Disciplinas, model);

            var validation = new AlunoInsertValidation(_alunoRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return viewModel;
            }

            _alunoRepository.Add(model);
            _unitOfWork.Commit();

            viewModel = _mapper.Map<AlunoViewModel>(model);

            return viewModel;
        }

        public void Update(AlunoViewModel alunoVM)
        {
            var model = _mapper.Map<Aluno>(alunoVM);

            var disciplinas = _alunoDisciplinaRepository.GetByAlunoIdAsync(model.Id);

            MapearDisciplinasEStatus(alunoVM.Disciplinas, model);

            var validation = new AlunoUpdateValidation(_alunoRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            //disciplinas a remover
            List<AlunoDisciplina> removerDisciplinas = disciplinas.Where(n => !alunoVM.Disciplinas.Any(a => a.DisciplinaId == n.DisciplinaId)).ToList();

            //novas disciplinas
            List<AlunoDisciplina> addDisciplinas = alunoVM.Disciplinas.Where(n => !disciplinas.Any(a => a.DisciplinaId == n.DisciplinaId))
                .Select(n => new AlunoDisciplina() { AlunoId = alunoVM.Id, DisciplinaId = n.DisciplinaId, Nota = n.Nota }).ToList();

            //disciplinas atualizar
            model.AlunoDisciplinas = model.AlunoDisciplinas.Where(n => !removerDisciplinas.Any(a => a.DisciplinaId == n.DisciplinaId) && disciplinas.Any(a => a.DisciplinaId == n.DisciplinaId)).ToList();

            foreach (var item in removerDisciplinas)
            {
                _alunoDisciplinaRepository.Remove(item);
            }

            foreach (var item in addDisciplinas)
            {
                _alunoDisciplinaRepository.Add(item);
            }

            _alunoRepository.Update(model);
            _unitOfWork.Commit();
        }

        private void MapearDisciplinasEStatus(List<AlunoDisciplinaViewModel> alunoDisciplinas, Aluno model)
        {
            model.SetDisciplinas(alunoDisciplinas.Select(n => new AlunoDisciplina() { AlunoId = model.Id, Nota = n.Nota, DisciplinaId = n.DisciplinaId }).ToList());

            model.SetStatus(_disciplinaRepository.GetByIdsAsync(alunoDisciplinas.Select(n => n.DisciplinaId).ToList()));
        }

        public void Remove(AlunoViewModel alunoVM)
        {
            var model = _mapper.Map<Aluno>(alunoVM);

            var validation = new AlunoDeleteValidation().Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            _alunoRepository.Remove(model);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<AlunoQueryViewModel>> GetByFilterAsync(AlunoFilterViewModel filter)
        {
            if (string.IsNullOrWhiteSpace(filter.Nome) &&
                string.IsNullOrWhiteSpace(filter.RA) &&
                string.IsNullOrWhiteSpace(filter.Status) &&
                filter.CursoId.GetValueOrDefault() == 0)
            {
                _domainNotification.AddNotification("PesquisaAluno", "Necessário informar ao menos um filtro");
                return null;
            }

            return _mapper.Map<IEnumerable<AlunoQueryViewModel>>(await _alunoRepository.GetByFilterAsync(filter.RA, filter.Nome, filter.CursoId, filter.Status));
        }
    }
}
