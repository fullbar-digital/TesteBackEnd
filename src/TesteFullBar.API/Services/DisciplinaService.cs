using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Disciplina;
using TesteFullBar.Domain.Interfaces.Notifications;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Interfaces.UoW;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Validation.DisciplinaValidation;

namespace TesteFullBar.API.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository _disciplinaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainNotification _domainNotification;

        public DisciplinaService(IDisciplinaRepository disciplinaRepository, IUnitOfWork unitOfWork, IMapper mapper, IDomainNotification domainNotification)
        {
            _disciplinaRepository = disciplinaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainNotification = domainNotification;
        }

        public async Task<IEnumerable<DisciplinaViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<DisciplinaViewModel>>(await _disciplinaRepository.GetAll());
        }

        public async Task<DisciplinaViewModel> GetByIdAsync(DisciplinaIdViewModel disciplinaVM)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaRepository.GetByIdAsync(disciplinaVM.Id));
        }

        public async Task<DisciplinaViewModel> GetByDescricaoAsync(DisciplinaDescricaoViewModel disciplinaVM)
        {
            return _mapper.Map<DisciplinaViewModel>(await _disciplinaRepository.GetByDescricaoAsync(disciplinaVM.Descricao));
        }

        public DisciplinaViewModel Add(DisciplinaViewModel disciplinaVM)
        {
            DisciplinaViewModel viewModel = null;
            var model = _mapper.Map<Disciplina>(disciplinaVM);

            var validation = new DisciplinaInsertValidation(_disciplinaRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return viewModel;
            }

            _disciplinaRepository.Add(model);
            _unitOfWork.Commit();

            viewModel = _mapper.Map<DisciplinaViewModel>(model);

            return viewModel;
        }

        public void Update(DisciplinaViewModel disciplinaVM)
        {
            var model = _mapper.Map<Disciplina>(disciplinaVM);

            var validation = new DisciplinaUpdateValidation(_disciplinaRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            _disciplinaRepository.Update(model);
            _unitOfWork.Commit();
        }

        public void Remove(DisciplinaViewModel disciplinaVM)
        {
            var model = _mapper.Map<Disciplina>(disciplinaVM);

            var validation = new DisciplinaDeleteValidation().Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            _disciplinaRepository.Remove(model);
            _unitOfWork.Commit();
        }
    }
}
