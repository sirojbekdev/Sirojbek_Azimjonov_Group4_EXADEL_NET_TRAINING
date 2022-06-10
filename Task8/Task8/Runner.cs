using Task7.Services;

namespace Task8
{
    public class Runner : IRunner
    {
        private IGetStudentInfoService _studentInfoService;
        private IInfoStringFormatter _fullInfoService;
        private IInfoStringFormatter _lastNameService;
        public Runner(GetStudentInfoService studentInfoService, GetFullInfoService fullInfoService, GetLastNameService lastNameService)
        {
            _studentInfoService = studentInfoService;
            _fullInfoService = fullInfoService;
            _lastNameService = lastNameService;
        }

        public async Task Run()
        {
            Console.WriteLine("1.Press 1 to get full info about student by id \n" +
                "2.Press 2 to get student’s last name by id\n"+
                "3.Exit");
            var serviceChoice = int.Parse(Console.ReadLine());

            if (serviceChoice == 1)
            {
                _studentInfoService.SetFormatter(_fullInfoService);
                Console.WriteLine("Enter the Id");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine(await _studentInfoService.GetInfo(id));
                await Run();
            }
            else if (serviceChoice == 2)
            {
                _studentInfoService.SetFormatter(_lastNameService);
                Console.WriteLine("Enter the Id");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine(await _studentInfoService.GetInfo(id));
                await Run();
            }
            else if (serviceChoice == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("wrong input");
                await Run();
            }
        }
    }
}
