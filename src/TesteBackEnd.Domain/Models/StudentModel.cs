using TesteBackEnd.Domain.Enums;

namespace TesteBackEnd.Domain.Models
{
    public class StudentModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _academicRecord;
        public string AcademicRecord
        {
            get { return _academicRecord; }
            set { _academicRecord = value; }
        }

        private string _period;
        public string Period
        {
            get { return _period; }
            set { _period = value; }
        }

        private string _courseId;
        public string CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }
        private Status _status;
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
        
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
    }
}