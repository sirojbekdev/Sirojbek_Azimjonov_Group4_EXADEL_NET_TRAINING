using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task7.Data;
using Task7.DataAccessLayer;
using Task7.Services;

namespace Task8
{
    public class StartUp
    {
        public static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
            IConfiguration configuration = builder.Build();
            services.AddSingleton(configuration);
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped<IInfoStringFormatter, GetFullInfoService>();
            services.AddScoped<IInfoStringFormatter, GetLastNameService>();
            services.AddSingleton<IGetStudentInfoService, GetStudentInfoService>();
            services.AddSingleton<Runner>();

            return services;
        }
    }
}
