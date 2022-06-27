using Template.Api.ApplicationCore.Intefaces;
using Template.Api.ApplicationCore.Intefaces.Services;

namespace Template.Api.ApplicationCore.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context,
            IStudentService studentService,
            ICourseSubjectStudentService courseSubjectStudentService)
        {
            _context = context;

            Students = studentService;
            CourseSubjectStudentService = courseSubjectStudentService;
        }

        public IStudentService Students { get; private set; }
        public ICourseSubjectStudentService CourseSubjectStudentService { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}