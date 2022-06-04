
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task7.Data;

namespace Task8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = StartUp.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<Runner>().Run();
        }
    }
}









