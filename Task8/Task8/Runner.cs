using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.Data;
using Task7.Services;

namespace Task8
{
    public class Runner : IRunner
    {
        public async Task Run()
        {
            Console.WriteLine("1.Press 1 to get full info about student by id \n" +
                "2.Press 2 to get student’s last name by id\n"+
                "3.Exit");
            var serviceChoice = int.Parse(Console.ReadLine());

            if (serviceChoice == 1)
            {
                GetStudentInfoService service = new(new GetFullInfoService());
                Console.WriteLine("Enter the Id");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine(await service.GetInfo(id));
                await Run();
            }
            else if (serviceChoice == 2)
            {
                GetStudentInfoService service = new(new GetLastNameService());
                Console.WriteLine("Enter the Id");
                var id = int.Parse(Console.ReadLine());
                Console.WriteLine(await service.GetInfo(id));
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
