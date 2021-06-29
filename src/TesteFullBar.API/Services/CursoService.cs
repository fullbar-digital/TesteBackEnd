using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteFullBar.API.Services.Interfaces;
using TesteFullBar.API.ViewModels.Curso;
using TesteFullBar.Domain.Interfaces.Notifications;
using TesteFullBar.Domain.Interfaces.Repository;
using TesteFullBar.Domain.Interfaces.UoW;
using TesteFullBar.Domain.Models;
using TesteFullBar.Domain.Validation.CursoValidation;

namespace TesteFullBar.API.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDomainNotification _domainNotification;

        public CursoService(ICursoRepository cursoRepository, IUnitOfWork unitOfWork, IMapper mapper, IDomainNotification domainNotification)
        {
            _cursoRepository = cursoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _domainNotification = domainNotification;
        }

        public async Task<IEnumerable<CursoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CursoViewModel>>(await _cursoRepository.GetAll());
        }

        public async Task<CursoViewModel> GetByIdAsync(CursoIdViewModel cursoVM)
        {
            return _mapper.Map<CursoViewModel>(await _cursoRepository.GetByIdAsync(cursoVM.Id));
        }

        public async Task<CursoViewModel> GetByDescricaoAsync(CursoDescricaoViewModel cursoVM)
        {
            return _mapper.Map<CursoViewModel>(await _cursoRepository.GetByDescricaoAsync(cursoVM.Descricao));
        }

        public CursoViewModel Add(CursoViewModel cursoVM)
        {
            CursoViewModel viewModel = null;
            var model = _mapper.Map<Curso>(cursoVM);

            var validation = new CursoInsertValidation(_cursoRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return viewModel;
            }

            _cursoRepository.Add(model);
            _unitOfWork.Commit();

            viewModel = _mapper.Map<CursoViewModel>(model);

            return viewModel;
        }

        public void Update(CursoViewModel cursoVM)
        {
            var model = _mapper.Map<Curso>(cursoVM);

            var validation = new CursoUpdateValidation(_cursoRepository).Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            _cursoRepository.Update(model);
            _unitOfWork.Commit();
        }

        public void Remove(CursoViewModel cursoVM)
        {
            var model = _mapper.Map<Curso>(cursoVM);

            var validation = new CursoDeleteValidation().Validate(model);

            if (!validation.IsValid)
            {
                _domainNotification.AddNotifications(validation);
                return;
            }

            _cursoRepository.Remove(model);
            _unitOfWork.Commit();
        }
    }
}
