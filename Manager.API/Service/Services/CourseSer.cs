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
    public class CourseSer : ICourseSer
    {
        private readonly IMapper _mapper;
        private readonly ICourseRep _courseRep;
        private readonly ICourseSubjectRep _courseSubjectRep;

        public CourseSer(IMapper mapper, ICourseRep courseRep, ICourseSubjectRep courseSubjectRep)
        {
            _mapper = mapper;
            _courseRep = courseRep;
            _courseSubjectRep = courseSubjectRep;
        }

        public async Task<CourseDto> Create(CourseDto courseDTO)
        {
            var course = _mapper.Map<Course>(courseDTO);
            //course.DateCreated = DateTime.Now;

            course.Validate();
            var courseCreated = await _courseRep.Create(course);
            var courseReturn = _mapper.Map<CourseDto>(courseCreated);
            courseReturn.CourseSubjectDto = new List<CourseSubjectDto>();

            foreach (var item in courseDTO.CodeSubject)
            {
                var courseSubjectDto = new CourseSubjectDto(courseCreated.Code, item);
                var courseSubject = _mapper.Map<CourseSubject>(courseSubjectDto);
                //courseSubject.CreatedDate = DateTime.Now;

                courseSubject.Validate();
                var courseSubjectCreated = await _courseSubjectRep.Create(courseSubject);
                courseReturn.CourseSubjectDto.Add(_mapper.Map<CourseSubjectDto>(courseSubjectCreated));
            }
            return (courseReturn);
        }

        public async Task<CourseDto> Get(int code)
        {
            var course = await _courseRep.Get(code);

            return (_mapper.Map<CourseDto>(course));
        }

        public async Task<List<CourseDto>> Get()
        {

            var listCourses = await _courseRep.Get();

            return (_mapper.Map<List<CourseDto>>(listCourses));
        }

        public async Task Remove(int code)
        {
            var list = await _courseSubjectRep.ForCourse(code);
            foreach (var item in list)
            {
                await _courseSubjectRep.Remove(item.Code);
            }
            await _courseRep.Remove(code);
        }

        public async Task<CourseDto> Update(CourseDto courseDTO)
        {
            var courseexist = await _courseRep.Get(courseDTO.Code);
            if (courseexist == null)
                throw new DomainException("Não Existe esse curso para ser alterado");

            var course = _mapper.Map<Course>(courseDTO);
            course.Validate();
            course.UpdateCourse(courseDTO.Name);

            var courseUpdate = await _courseRep.Update(course);
            return (_mapper.Map<CourseDto>(courseUpdate));

        }

        public async Task<CourseSubjectDto> AddSubject(CourseSubjectDto courseSubjectDTO)
        {
            var courseSubject = _mapper.Map<CourseSubject>(courseSubjectDTO);
            //courseSubject.DateCreated = DateTime.Now;

            courseSubject.Validate();
            var courseSubjectCreated = await _courseSubjectRep.Create(courseSubject);
            return (_mapper.Map<CourseSubjectDto>(courseSubjectCreated));
        }

        public async Task DeleteSubject(CourseSubjectDto courseSubjectDTO)
        {
            var courseSub = _mapper.Map<CourseSubject>(courseSubjectDTO);
            //courseSub.DateCreated = DateTime.Now;

            courseSub.Validate();
            //var courseSubject = await _courseSubjectRep.ForSubject(courseSub);

            await _courseSubjectRep.Remove(courseSub.Code);
        }
    }
}
