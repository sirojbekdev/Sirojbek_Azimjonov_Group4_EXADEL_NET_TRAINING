using Moq;
using System.Text;
using Task7.DataAccessLayer;

namespace Task8.TestN
{
    [TestFixture]
    public class Tests
    {

        private readonly GetStudentInfoService _sut;
        private readonly Mock<IGenericRepository<Student>> _context = new Mock<IGenericRepository<Student>>();
        private readonly GetFullInfoService _fullInfoService = new();
        private readonly GetLastNameService _lastNameService = new();

        public Tests()
        {
            _sut = new(_context.Object);
        }

        [Test]
        [TestCaseSource(typeof(TestSource),nameof(TestSource.Students_ForLastName))]
        public async Task GetLastNameService_WhenValid_ReturnsLastName(Student student, string lastName)
        {
            // Arrange
            _sut.SetFormatter(_lastNameService);

            _context.Setup(x => x.GetByIdAsync(student.Id)).ReturnsAsync(student);
            // Act
            var _lastName = await _sut.GetInfo(student.Id);

            // Assert
            Assert.That(_lastName, Is.EqualTo(lastName));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-145)]
        [TestCase(-2500)]
        [TestCase(null)]
        [TestCase(-12)]
        public async Task GetLastNameService_WhenInvalid_ReturnsError(int? id)
        {
            // Arrange
            _sut.SetFormatter(_lastNameService);
            _context.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            // Act
            var _lastName = await _sut.GetInfo(id);

            // Assert
            Assert.That(_lastName, Is.EqualTo("Student with this Id not Found"));
        }

        [Test]
        [TestCaseSource(typeof(TestSource), nameof(TestSource.Students_ForFullInfo))]
        public async Task GetFullInfoService_WhenValid_ReturnFullInfo(Student student, int id)
        {
            // Arrange
            _sut.SetFormatter(_fullInfoService);
            _context.Setup(x => x.GetByIdAsync(student.Id)).ReturnsAsync(student);
            StringBuilder sb = new();
            sb.AppendLine("Id: " + student.Id);
            sb.AppendLine("FirstName: " + student.FirstName);
            sb.AppendLine("LastName: " + student.LastName);
            sb.AppendLine("PhoneNumber: " + student.PhoneNumber);
            sb.AppendLine("Address: " + student.Address);
            sb.AppendLine("DateOfBirth: " + student.DateOfBirth);
            var expected = sb.ToString();

            // Act
            var _lastName = await _sut.GetInfo(id);

            // Assert
            Assert.That(_lastName, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-15)]
        [TestCase(-1000)]
        [TestCase(null)]
        [TestCase(-170)]
        public async Task GetFullInfoService_WhenInvalid_ReturnsError(int? id)
        {
            // Arrange
            _sut.SetFormatter(_fullInfoService);
            _context.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            // Act
            var _lastName = await _sut.GetInfo(id);

            // Assert
            Assert.That(_lastName, Is.EqualTo("Student with this Id not Found"));
        }
    }
}