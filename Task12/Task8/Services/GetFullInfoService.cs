using System.Text;
using Task7.Models;

namespace Task7.Services
{
    public class GetFullInfoService : IInfoStringFormatter
    {
        public string FormatInfoString(Student? student)
        {
            if (student == null)
                return null;

            StringBuilder sb = new();
            sb.AppendLine("Id: " + student.Id);
            sb.AppendLine("FirstName: " + student.FirstName);
            sb.AppendLine("LastName: " + student.LastName);
            sb.AppendLine("PhoneNumber: " + student.PhoneNumber);
            sb.AppendLine("Address: " + student.Address);
            sb.AppendLine("DateOfBirth: " + student.DateOfBirth);
            return sb.ToString();
        }
    }
}
