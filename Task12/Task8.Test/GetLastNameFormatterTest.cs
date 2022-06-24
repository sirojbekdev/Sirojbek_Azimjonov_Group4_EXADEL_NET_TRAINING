namespace Task8.TestN
{
    [TestFixture]
    public class GetLastNameFormatterTest
    {
        private readonly GetLastNameService _sut = new();


        [Test]
        [TestCaseSource(typeof(TestSource), nameof(TestSource.Students_ForLastName))]
        public async Task GetLastNameService_WhenValid_ReturnsLastName(Student student, string expected)
        {
            // Arrange
            var _expected = expected;
            // Act
            var _lastName = _sut.FormatInfoString(student);

            // Assert
            Assert.AreEqual(_expected, _lastName);
        }

        [Test]
        [TestCase(null)]
        public async Task GetLastNameService_WhenInvalid_ReturnsNull(Student student)
        {
            // Arrange
            // Act
            var _lastName = _sut.FormatInfoString(student);

            // Assert
            Assert.IsNull(_lastName);
        }
    }
}
