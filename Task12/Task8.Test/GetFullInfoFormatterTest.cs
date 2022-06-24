using System.Text;

namespace Task8.TestN
{
    [TestFixture]
    public class GetFullInfoFormatterTest
    {
        private readonly GetFullInfoService _sut = new();


        [Test, TestCaseSource(typeof(TestSource), nameof(TestSource.Students_ForFullInfo))]
        public void GetFullInfoService_WhenValid_ReturnsFullInfo(Student student, int id)
        {
            // Arrange
            StringBuilder sb = new();
            sb.AppendLine("Id: " + student.Id);
            sb.AppendLine("FirstName: " + student.FirstName);
            sb.AppendLine("LastName: " + student.LastName);
            sb.AppendLine("PhoneNumber: " + student.PhoneNumber);
            sb.AppendLine("Address: " + student.Address);
            sb.AppendLine("DateOfBirth: " + student.DateOfBirth);
            var _expected =sb.ToString();
            // Act
            var info = _sut.FormatInfoString(student);

            // Assert
            Assert.That(info, Is.EqualTo(_expected));
            
        }

        [Test]
        [TestCase(null)]
        public void GetFullInfoService_WhenInvalid_ReturnsNull(Student student)
        {
            // Arrange
            // Act
            var _lastName = _sut.FormatInfoString(student);

            // Assert
            Assert.That(_lastName, Is.Null);
        }
    }
}
