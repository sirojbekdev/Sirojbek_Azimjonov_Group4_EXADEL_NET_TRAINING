namespace Task8.TestN
{
    public class TestSource
    {
        public static List<Student> Students = new() {

            new Student()
        {
            Id = 3,
            FirstName = "Alex",
            LastName = "Bob3",
            Address = "Awdsc 65",
            ClassId = 1,
            DateOfBirth = DateTime.Now,
            PhoneNumber = "46451645"
        },
            new Student()
            {
                Id = 100,
                FirstName = "Alex",
                LastName = "Bob100",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            },
            new Student()
            {
                Id = 150,
                FirstName = "Alex",
                LastName = "Bob150",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            },
            new Student()
            {
                Id = 7,
                FirstName = "Alex",
                LastName = "Bob7",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            },
            new Student()
            {
                Id = 25,
                FirstName = "Alex",
                LastName = "Bob25",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            },
            new Student()
            {
                Id = 22,
                FirstName = "Alex",
                LastName = "Bob22",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            },
            new Student()
            {
                Id = 111,
                FirstName = "Alex",
                LastName = "Bob111",
                Address = "Awdsc 65",
                ClassId = 1,
                DateOfBirth = DateTime.Now,
                PhoneNumber = "46451645"
            }
        };

        public static IEnumerable<TestCaseData> Students_ForLastName
        {
            get
            {
                foreach (var student in Students)
                {
                    yield return new TestCaseData(student, "LastName: " + student.LastName);
                }
            }
        }
        public static IEnumerable<TestCaseData> Students_ForFullInfo
        {
            get
            {
                foreach (var student in Students)
                {
                    yield return new TestCaseData(student, student.Id);
                }
            }
        }
    }
}
