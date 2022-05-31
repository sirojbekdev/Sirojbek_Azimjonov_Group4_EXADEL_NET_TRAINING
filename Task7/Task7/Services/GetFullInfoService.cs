using System.Text;
using Task7.Models;

namespace Task7.Services
{
    public class GetFullInfoService : IInfoStringFormatter
    {
        public string FormatInfoString(Student student)
        {
            StringBuilder sb = new();
            sb.Append("Id: " + student.Id);
            sb.Append("FirstName: " + student.FirstName);
            sb.Append("LastName: " + student.LastName);
            sb.Append("PhoneNumber: " + student.PhoneNumber);
            sb.Append("Address: " + student.Address);
            sb.Append("DateOfBirth: " + student.DateOfBirth);
            return sb.ToString();
        }
    }
}
