using AutoMapper;
using Domain.Entities;
using Infra.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
        public class StudentSer : IStudentSer
        {
            private readonly IMapper _mapper;
            private readonly IStudentRep _studentRep;
            private readonly ICourseRep _courseRep;
            private readonly IStudentSubjectRep _studentSubjectRep;
            private readonly ISubjectRep _subjectRep;
            private readonly ICourseSubjectRep _courseSubjectRep;

            public StudentSer(IMapper mapper, IStudentRep studentRep, ICourseRep courserep, IStudentSubjectRep studentsubjectrep,
                ISubjectRep subjectrep, ICourseSubjectRep coursesubjectrep)
            {
                _mapper = mapper;
                _studentRep = studentRep;
                _courseRep = courserep;
                _studentSubjectRep = studentsubjectrep;
                _subjectRep = subjectrep;
                _courseSubjectRep = coursesubjectrep;
            }

            public async Task<StudentDto> Create(StudentDto studentdto)
            {
                var student = _mapper.Map<Student>(studentdto);
                //student. = DateTime.Now;

                student.Validate();
                var studentcreated = await _studentRep.Create(student);
                var listSubject = await _courseSubjectRep.ForCourse(studentcreated.CodeCourse);
                var studentcreatedDTO = _mapper.Map<StudentDto>(studentcreated);
                studentcreatedDTO.StudentSubjectDto = new List<StudentSubjectDto>();

                foreach (var item in listSubject)
                {
                    var studentSubjectDto = new StudentSubjectDto(studentcreated.Code, item.SubjectId, 0);
                    var studentSubCreated = await AddSubject(studentSubjectDto);

                    studentcreatedDTO.StudentSubjectDto.Add(studentSubCreated);
                }

                return studentcreatedDTO;
            }

            public async Task<GetStudentDto> Get(int code)
            {
                var student = await _studentRep.Get(code);
                var course = await _courseRep.Get(student.CodeCourse);
                var lista = await _studentSubjectRep.ListSubjects(code);

                var studentDto = new GetStudentDto(student.Name, student.RA, student.Turn, student.Picture);
                var listStudentSubject = new List<GetStudentSubjectDto>();

                foreach (var item in lista)
                {
                    var StudentSub = new GetStudentSubjectDto(item.Note, item.Status);
                    var subject = await _subjectRep.Get(item.SubjectId);

                    StudentSub.SubjectName = subject.Name;
                    StudentSub.ApproveMin = subject.ApproveMin;
                    listStudentSubject.Add(StudentSub);
                }
                studentDto.Subjects = listStudentSubject;
                studentDto.Course = _mapper.Map<CourseDto>(course);

                return studentDto;
            }

            public async Task<List<GetStudentDto>> ListForName(string name)
            {
                var listStudent = await _studentRep.StudentForName(name);
                var listStudentDto = new List<GetStudentDto>();

                foreach (var student in listStudent)
                {
                    var course = await _courseRep.Get(student.CodeCourse);
                    var list = await _studentSubjectRep.ListSubjects(student.Code);

                    var studentDTO = new GetStudentDto(student.Name, student.RA, student.Turn, student.Picture);
                    var listStudentSub = new List<GetStudentSubjectDto>();

                    foreach (var item in list)
                    {
                        var studentSub = new GetStudentSubjectDto(item.Note, item.Status);
                        var subject = await _subjectRep.Get(item.SubjectId);

                        studentSub.SubjectName = subject.Name;
                        studentSub.ApproveMin = subject.ApproveMin;
                        listStudentSub.Add(studentSub);
                    }
                    studentDTO.Subjects = listStudentSub;
                    studentDTO.Course = _mapper.Map<CourseDto>(course);

                    listStudentDto.Add(studentDTO);
                }
                return listStudentDto;
            }

            public async Task<GetStudentDto> ListForRA(string RA)
            {
                var student = await _studentRep.StudentForRa(RA);

                var course = await _courseRep.Get(student.CodeCourse);
                var list = await _studentSubjectRep.ListSubjects(student.Code);

                var studentDTO = new GetStudentDto(student.Name, student.RA, student.Turn, student.Picture);
                var listStudentSub = new List<GetStudentSubjectDto>();

                foreach (var item in list)
                {
                    var studentSub = new GetStudentSubjectDto(item.Note, item.Status);
                    var subject = await _subjectRep.Get(item.SubjectId);

                    studentSub.SubjectName = subject.Name;
                    studentSub.ApproveMin = subject.ApproveMin;
                    listStudentSub.Add(studentSub);
                }
                studentDTO.Subjects = listStudentSub;
                studentDTO.Course = _mapper.Map<CourseDto>(course);

                return studentDTO;
            }

            public async Task<List<GetStudentDto>> ListForStatus(string status)
            {
                var listStudentSubject = await _studentSubjectRep.ListStudentForStatus(status);
                var listStudentDTO = new List<GetStudentDto>();

                foreach (var listSubject in listStudentSubject)
                {
                    var student = await _studentRep.Get(listSubject.StudentId);
                    var course = await _courseRep.Get(student.CodeCourse);
                    var list = await _studentSubjectRep.ListSubjects(student.Code);

                    var studentDto = new GetStudentDto(student.Name, student.RA, student.Turn, student.Picture);
                    var listStudentSub = new List<GetStudentSubjectDto>();

                    foreach (var item in list)
                    {
                        var studentSub = new GetStudentSubjectDto(item.Note, item.Status);
                        var subject = await _subjectRep.Get(item.SubjectId);

                        studentSub.SubjectName = subject.Name;
                        studentSub.ApproveMin = subject.ApproveMin;
                        listStudentSub.Add(studentSub);
                    }
                    studentDto.Subjects = listStudentSub;
                    studentDto.Course = _mapper.Map<CourseDto>(course);

                    listStudentDTO.Add(studentDto);
                }
                return listStudentDTO;
            }
            //
            public async Task<List<GetStudentDto>> ListForCourse(string nameCourse)
            {
                var listCourse = await _courseRep.CourseForName(nameCourse);
                var listStudentDto = new List<GetStudentDto>();

                foreach (var course in listCourse)
                {
                    var listStudent = await _studentRep.StudentForCourse(course.Code);
                    foreach (var StudentItem in listStudent)
                    {
                        var lista = await _studentSubjectRep.ListSubjects(StudentItem.Code);

                        var studentDTO = new GetStudentDto(StudentItem.Name, StudentItem.RA, StudentItem.Turn, StudentItem.Picture);
                        var listStudentSub = new List<GetStudentSubjectDto>();

                        foreach (var item in lista)
                        {
                            var studentsub = new GetStudentSubjectDto(item.Note, item.Status);
                            var subject = await _subjectRep.Get(item.SubjectId);

                            studentsub.SubjectName = subject.Name;
                            studentsub.ApproveMin = subject.ApproveMin;
                            listStudentSub.Add(studentsub);
                        }
                        studentDTO.Subjects = listStudentSub;
                        studentDTO.Course = _mapper.Map<CourseDto>(course);

                        listStudentDto.Add(studentDTO);
                    }
                }
                return listStudentDto;
            }

            public async Task<List<StudentDto>> Get()
            {
                var listStudent = await _studentRep.Get();

                return _mapper.Map<List<StudentDto>>(listStudent);
            }

            public async Task Remove(int code)
            {
                var lista = await _studentSubjectRep.ListSubjects(code);
                foreach (var item in lista)
                {
                    await _studentSubjectRep.Remove(item.Code);
                }
                await _studentRep.Remove(code);
            }

            public async Task<StudentDto> Update(StudentDto studentDTO)
            {
                var studentExist = await _studentRep.Get(studentDTO.Code);
                if (studentExist == null)
                    throw new DomainException("Não existe esse aluno para ser alterado");

                var student = _mapper.Map<Student>(studentDTO);
                //student.DateCreate = DateTime.Now;

                student.Validate();
                student.StudentUpdate(studentDTO.Name, studentDTO.RA, studentDTO.Turn, studentDTO.Picture, studentDTO.CourseId);

                var studentUpdated = await _studentRep.Update(student);
                return _mapper.Map<StudentDto>(studentUpdated);
            }

            public async Task<StudentSubjectDto> AddSubject(StudentSubjectDto studentDto)
            {
                var student = _mapper.Map<StudentSubject>(studentDto);
                var subject = await _subjectRep.Get(studentDto.SubjectId);
                student.Status = student.Note >= subject.ApproveMin ? "Aprovado" : "Reprovado";
                //student.DateCreate = DateTime.Now;

                student.Validate();
                var studentCreated = await _studentSubjectRep.Create(student);
                return _mapper.Map<StudentSubjectDto>(studentCreated);
            }

            public async Task<StudentSubjectDto> AddNote(StudentSubjectDto studentDTO)
            {
                var alunoExist = await _studentSubjectRep.ListForStudentSubject(studentDTO.StudentId, studentDTO.SubjectId);
                if (alunoExist == null)
                    throw new DomainException("Não existe esse aluno para ser adicionado nota");

                var student = _mapper.Map<StudentSubject>(studentDTO);
                var subject = await _subjectRep.Get(studentDTO.SubjectId);
                var status = student.Note >= subject.ApproveMin ? "Aprovado" : "Reprovado";

                student.UpdateNote(studentDTO.Note, studentDTO.Status, alunoExist.Code);


                student.Validate();
                var studentCreated = await _studentSubjectRep.Update(student);
                return _mapper.Map<StudentSubjectDto>(studentCreated);
            }
        }
}
