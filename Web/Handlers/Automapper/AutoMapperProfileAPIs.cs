using AutoMapper;

using Domain.Entities;

using Web.Api.ViewModels;

namespace Web.Handlers.Automapper
{
	public class AutoMapperProfileAPIs : Profile
	{
		public AutoMapperProfileAPIs()
		{
			CreateMap<Student, StudentAddApiVm>().ReverseMap();
			CreateMap<Subject, SubjectAddApiVm>().ReverseMap();
			CreateMap<Subject, CourseAddSubjectApiVm>().ReverseMap();
			CreateMap<Course, CourseAddApiVm>().ReverseMap();
			
		}
	}
}
