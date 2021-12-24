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
    public class CourseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var obj = _unitOfWork.CourseRepository.Where(w=> true)
                .Select(s => new CourseApivm() { 
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            return Ok(obj);
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Add(CourseAddApiVm model)
        {
            var existsCourse = _unitOfWork.CourseRepository
                .Where(w => w.Name.Equals(model.Name))
                .FirstOrDefault();

            if (existsCourse != null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "Já existe um curso com este nome"
                });
            }

            var course = _mapper.Map<Course>(model);
            _unitOfWork.CourseRepository.Add(course);
            _unitOfWork.Commit();

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Curso cadastrado com sucesso!"
            });
        }
    }
}
