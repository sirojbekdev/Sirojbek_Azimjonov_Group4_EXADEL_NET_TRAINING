
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task7.Data;

namespace Task8
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = StartUp.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<Runner>().Run();
        }
    }
}









