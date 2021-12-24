using AutoMapper;

using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

using Repositories;

using System;
using System.Collections.Generic;
using System.Linq;

using Web.Api.ViewModels;

namespace Web.Api
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("List")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult List()
        {
            var result = new List<StudentApivm>();
            var objs = _unitOfWork.StudentRepository.Where(w => true);
            foreach (var student in objs)
            {
                var swcas = _unitOfWork.StudentRepository.SingleWithCourseAndSchoolReportsWithSubject(student.Id);
                foreach (var item in swcas)
                {
                    if (item.Value.Count > 0)
                        return Ok(new DefaultApiResult()
                        {
                            Success = false,
                            Message = item.Value.First()
                        });

                    var s = item.Key;
                    result.Add(new StudentApivm()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Ra = s.Ra,
                        Period = s.Period,
                        ProfilePicture = s.ProfilePicture,
                        Course = s.Course.Name,
                        Status = s.Status,
                        SchoolReports = s.SchoolReports.Select(s => new SchoolReportApivm()
                        {
                            Subject = s.Subject.Name,
                            Grade = s.Grade
                        }).ToList()
                    });
                }
            }
            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Listando alunos",
                Content = result
            });
        }

        [HttpPost("Add")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Add(StudentAddApiVm model)
        {
            var existsCourse = _unitOfWork.CourseRepository
                .Where(w => w.Id.Equals(model.CourseId), CollectionPaths: new[] { "Subjects" })
                .FirstOrDefault();

            if (existsCourse == null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = "Este Id de curso não existe"
                });
            }

            var existsStudent = _unitOfWork.StudentRepository.Where(a => a.Name.Equals(model.Name)).FirstOrDefault();
            if (existsStudent != null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = $"O aluno {model.Name} já está cadastrado"
                });
            }

            foreach (var subject in existsCourse.Subjects)
            {
                if (!model.Subjects.Select(s => s.Id).Contains(subject.Id))
                {
                    return Ok(new DefaultApiResult()
                    {
                        Success = false,
                        Message = $"O Aluno precisa ter notas em cada diciplina que o curso contempla"
                    });
                }
            }

            foreach (var subject in model.Subjects)
            {
                var existsSubject = _unitOfWork.SubjectRepository
                    .Where(w => w.Id.Equals(subject.Id)).FirstOrDefault();

                if (existsSubject == null)
                {
                    return Ok(new DefaultApiResult()
                    {
                        Success = false,
                        Message = $"Este Id de disciplina não existe. {subject.Id}"
                    });
                }
            }

            Student student = _mapper.Map<Student>(model);
            _unitOfWork.StudentRepository.Add(student);
            _unitOfWork.Commit();

            foreach (var subjectOfCourse in model.Subjects)
            {
                _unitOfWork.SchoolReportRepository.AddOrUpdateReport(student.Id, subjectOfCourse.Id, subjectOfCourse.Grade);
            }

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Aluno cadastrado com sucesso!"
            });
        }

        [HttpGet("Filter")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Filter([FromQuery] StudentFilterApiVm model)
        {
            var objs = _unitOfWork.StudentRepository.Where(w =>
                    (model.Name == null ? true : w.Name.Contains(model.Name)) &&
                    (model.Ra == null ? true : w.Ra.Contains(model.Ra)) &&
                    (model.CourseId.HasValue ? w.CourseId.Equals(model.CourseId) : true) &&
                    (model.Status == null ? true : w.Status.Contains(model.Status))
                );

            var result = new List<StudentApivm>();
            foreach (var student in objs)
            {
                var swcas = _unitOfWork.StudentRepository.SingleWithCourseAndSchoolReportsWithSubject(student.Id);
                foreach (var item in swcas)
                {
                    if (item.Value.Count > 0)
                        return Ok(new DefaultApiResult()
                        {
                            Success = false,
                            Message = item.Value.First()
                        });

                    var s = item.Key;
                    result.Add(new StudentApivm()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Ra = s.Ra,
                        Period = s.Period,
                        ProfilePicture = s.ProfilePicture,
                        Course = s.Course.Name,
                        Status = s.Status,
                        SchoolReports = s.SchoolReports.Select(s => new SchoolReportApivm()
                        {
                            Subject = s.Subject.Name,
                            Grade = s.Grade
                        }).ToList()
                    });
                }
            }
            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Listando alunos",
                Content = result
            });
        }


        [HttpPatch("Update")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Update(StudentUpdateApiVm model)
        {
            if(!model.StudentId.HasValue)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = $"É necessário informar o Id do aluno"
                });
            }

            var existsStudent = _unitOfWork.StudentRepository.Where(a => a.Id.Equals(model.StudentId)).FirstOrDefault();
            if (existsStudent == null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = $"Não existe um aluno com o Id informado"
                });
            }

            if(!string.IsNullOrEmpty(model.Name))
            {
                existsStudent.Name = model.Name;
            }

            if (!string.IsNullOrEmpty(model.Ra))
            {
                existsStudent.Ra = model.Ra;
            }

            if (!string.IsNullOrEmpty(model.ProfilePicture))
            {
                existsStudent.ProfilePicture = model.ProfilePicture;
            }

            if (model.Period.HasValue && model.Period > 0)
            {
                existsStudent.Period = model.Period.Value;
            }

            if (model.CourseId.HasValue)
            {
                var existsCourse = _unitOfWork.CourseRepository
                .Where(w => w.Id.Equals(model.CourseId.Value))
                .FirstOrDefault();

                if (existsCourse == null)
                {
                    return Ok(new DefaultApiResult()
                    {
                        Success = false,
                        Message = "Não existe um curso com o Id informado"
                    });
                }

                existsStudent.CourseId = model.CourseId.Value;
            }

            _unitOfWork.StudentRepository.Update(existsStudent);
            _unitOfWork.Commit();

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Cadastro do aluno atualizado com sucesso!"
            });
        }



        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(DefaultApiResult), 200)]
        public IActionResult Delete(StudentDeleteApiVm model)
        {
            if (!model.StudentId.HasValue)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = $"É necessário informar o Id do aluno"
                });
            }

            var existsStudent = _unitOfWork.StudentRepository.Where(a => a.Id.Equals(model.StudentId)).FirstOrDefault();
            if (existsStudent == null)
            {
                return Ok(new DefaultApiResult()
                {
                    Success = false,
                    Message = $"Não existe um aluno com o Id informado"
                });
            }

            _unitOfWork.StudentRepository.Delete(existsStudent);
            _unitOfWork.Commit();

            return Ok(new DefaultApiResult()
            {
                Success = true,
                Message = "Aluno excluído da base de dados!"
            });
        }

    }
}



