using Task7.Services;

Found:
Console.WriteLine("1.Press 1 to get full info about student by id \n" +
    "2.Press 2 to get student’s last name by id");
var serviceChoice = int.Parse(Console.ReadLine());
Console.WriteLine("Enter the Id");
var id = int.Parse(Console.ReadLine());

if (serviceChoice == 1)
{
    GetStudentInfoService service = new GetStudentInfoService(new GetFullInfoService());
    Console.WriteLine(service.GetInfo(id));
    goto Found;
}
else if (serviceChoice == 2)
{
    GetStudentInfoService service = new GetStudentInfoService(new GetLastNameService());
    Console.WriteLine(service.GetInfo(id));
    goto Found;
}
else
{
    Console.WriteLine("wrong input");
    goto Found;
}
