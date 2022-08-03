using AutoMapper;
using Domain.Entities;
using Manager.API.commands;
using Manager.API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.API.Controllers
{
    
        [EnableCors("MyPolicy")]
        [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
        [ApiController]
        public class StudentController : Controller
        {
            private readonly IMapper _mapper;
            private readonly IStudentSer _studentService;
            public StudentController(IMapper mapper, IStudentSer studentService)
            {
                _mapper = mapper;
                _studentService = studentService;
            }

            [HttpPost]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/Create")]
            public async Task<IActionResult> Criar([FromBody] CreateStudent createStudentVm)
            {
                try
                {
                    var studentDto = _mapper.Map<StudentDto>(createStudentVm);
                    var studentCreated = await _studentService.Create(studentDto);

                    return Ok(new ModelResult
                    {
                        Message = "Aluno criado com sucesso",
                        Success = true,
                        Data = studentCreated
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }

            }

            [HttpPut]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/Update")]
            public async Task<IActionResult> Editar([FromBody] StudentDto studentDTO)
            {
                try
                {
                    var studentUpdate = await _studentService.Update(studentDTO);

                    return Ok(new ModelResult
                    {
                        Message = "Aluno Editado com sucesso",
                        Success = true,
                        Data = studentDTO
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpDelete]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/delete")]
            public async Task<IActionResult> Apaga(int codigo)
            {
                try
                {
                    await _studentService.Remove(codigo);

                    return Ok(new ModelResult
                    {
                        Message = "Aluno Apagado!",
                        Success = true,
                        Data = null
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/List")]
            public async Task<IActionResult> Lista(int codigo)
            {
                try
                {
                    var aluno = await _studentService.Get(codigo);

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = aluno
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/ListForName")]
            public async Task<IActionResult> ListaPorNome(string nome)
            {
                try
                {
                    var aluno = await _studentService.ListForRA(nome);

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = aluno
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/ListForRA")]
            public async Task<IActionResult> ListaPorRA(string ra)
            {
                try
                {
                    var aluno = await _studentService.ListForRA(ra);

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = aluno
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            //
            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/ListForCourse")]
            public async Task<IActionResult> ListForCourse(string NomeCurso)
            {
                try
                {
                    var student = await _studentService.ListForCourse(NomeCurso);

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = student
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/ListForStatus")]
            public async Task<IActionResult> ListaPorStatus(string status)
            {
                try
                {
                    var aluno = await _studentService.ListForStatus(status);

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = aluno
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            [HttpGet]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/ListAll")]
            public async Task<IActionResult> ListaTodas()
            {
                try
                {
                    var listaAluno = await _studentService.Get();

                    return Ok(new ModelResult
                    {
                        Message = "aluno Achado com sucesso!",
                        Success = true,
                        Data = listaAluno
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }
            }

            /*---------------------------------------------------------------------------*/
            [HttpPut]
            [Microsoft.AspNetCore.Mvc.Route("/v1/student/addnote")]
            public async Task<IActionResult> AdicionaNota([FromBody] StudentSubjectVm studentSubjectDTO)
            {
                try
                {
                    var studentSubject = _mapper.Map<StudentSubjectDto>(studentSubjectDTO);
                    var subjectAdd = await _studentService.AddNote(studentSubject);

                    return Ok(new ModelResult
                    {
                        Message = "Nota Adicionada com sucesso",
                        Success = true,
                        Data = subjectAdd
                    });
                }
                catch (DomainException ex)
                {
                    return BadRequest(CommandsResult.DomainErrorMessage(ex.Message, ex.Errors));
                }
                catch (Exception ex)
                {
                    return StatusCode(500, CommandsResult.ApplicationErrorMessage(ex));
                }

            }
        }
}
