using Microsoft.AspNetCore.Mvc;

using Repositories;

using Web.Api.ViewModels;

namespace Web.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SchoolReportController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public SchoolReportController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Add(SchoolReportAddApiVm model)
        {
            if(!_unitOfWork.StudentRepository.Any(w=>w.Id.Equals(model.StudentId)))
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "Este Id de estudante não existe"
                });
            }

            if (!_unitOfWork.SubjectRepository.Any(w => w.Id.Equals(model.SubjectId)))
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "Este Id de disciplina não existe"
                });
            }

            if (model.Grade < 0 || model.Grade > 10.0m)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "A nota deve variar entre '0.0' e '10.0'"
                });
            }

            _unitOfWork.SchoolReportRepository.AddOrUpdateReport(model.StudentId, model.SubjectId, model.Grade);

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Nota lançada com sucesso!"
            });
        }
    }
}
