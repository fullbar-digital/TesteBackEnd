using AutoMapper;

using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using Repositories;

using System.Linq;

using Web.Api.ViewModels;

namespace Web.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var obj = _unitOfWork.SubjectRepository.Where(w => true)
                .Select(s => new SubjectApivm()
                {
                    Id = s.Id,
                    Name = s.Name,
                    MinimumApprovalGrade = s.MinimumApprovalGrade,
                }).ToList();

            return Ok(obj);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Add(SubjectAddApiVm model)
        {
            var existsCourse = _unitOfWork.CourseRepository
                .Where(w => w.Id.Equals(model.CourseId))
                .FirstOrDefault();

            if (existsCourse == null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "Não existe um curso com este Id"
                });
            }

            var subject = _mapper.Map<Subject>(model);
            _unitOfWork.SubjectRepository.Add(subject);
            _unitOfWork.Commit();

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Disciplina cadastrada com sucesso!"
            });
        }
    }
}
