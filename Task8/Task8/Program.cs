
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Task7.Data;
using Task7.Services;

namespace Task8
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<DbContext, AppDbContext>();
                    services.AddTransient<IInfoStringFormatter, GetFullInfoService>();
                    services.AddTransient<IInfoStringFormatter, GetLastNameService>();
                    services.AddTransient<IGetStudentInfoService, GetStudentInfoService>();
                    services.AddSingleton<IRunner, Runner>();
                })
                .Build();

            var svc = ActivatorUtilities.CreateInstance<Runner>(host.Services, new GetStudentInfoService(), new GetFullInfoService(), new GetLastNameService());
            await svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
        }
    }
}









