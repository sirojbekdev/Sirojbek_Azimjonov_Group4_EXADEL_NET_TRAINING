using Task7.Models;

namespace Task7.Services
{
    public class GetLastNameService : IInfoStringFormatter
    {
        public string FormatInfoString(Student? student)
        {
            if (student == null)
                return null;
            return "LastName: " + student.LastName;
        }
    }
}
