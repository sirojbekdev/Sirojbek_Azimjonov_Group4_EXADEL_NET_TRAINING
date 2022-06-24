using Task7.Data;
using Task7.DataAccessLayer;
using Task7.Models;

namespace Task7.Services
{
    public class GetStudentInfoService : IGetStudentInfoService
    {
        private IInfoStringFormatter _infoStringFormatter;
        private readonly IGenericRepository<Student> _studentContext;
        

        public GetStudentInfoService(IGenericRepository<Student> studentContext)
        {
            _studentContext = studentContext;
        }

        public void SetFormatter(IInfoStringFormatter infoStringFormatter)
        {
            _infoStringFormatter = infoStringFormatter;
        }

        public async Task<string> GetInfo(int? id)
        {
            var student = await _studentContext.GetByIdAsync(id);
            if (student != null)
                return _infoStringFormatter.FormatInfoString(student);
            else
                return "Student with this Id not Found";            
        }
    }
}
