using Task7.Data;
using Task7.DataAccessLayer;
using Task7.Models;

namespace Task7.Services
{
    public class GetStudentInfoService : IGetStudentInfoService
    {
        private IInfoStringFormatter _infoStringFormatter;
        private IGenericRepository<Student> studentContext;

        public GetStudentInfoService(IInfoStringFormatter infoStringFormatter)
        {
            _infoStringFormatter = infoStringFormatter;
        }

        public void SetFormatter(IInfoStringFormatter infoStringFormatter)
        {
            _infoStringFormatter = infoStringFormatter;
        }

        public string GetInfo(int id)
        {
            using (var dbContext = new AppDbContext()) {
                    studentContext = new GenericRepository<Student>(dbContext);
                    var student = studentContext.GetByID(id);
                if (student != null)
                    return _infoStringFormatter.FormatInfoString(student);
                else
                    return "Student with this Id not Found";
            }
        }
    }
}
