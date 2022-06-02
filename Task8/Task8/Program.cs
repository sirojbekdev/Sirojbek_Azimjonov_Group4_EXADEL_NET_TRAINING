
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
            var host = CreateHostBuilder(args).Build();
            var runner = ActivatorUtilities.CreateInstance<Runner>(host.Services);
            runner.Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                    
                //.ConfigureWebHostDefaults(webBuilder =>
                //{
                //    webBuilder.UseStartup<Startup>();
                //});

        //public static IHostBuilder CreateHostBuilder(string[] args)
        //{
        //    IConfiguration _configuration;

        //    return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, configuration) =>
        //    {
        //        configuration.Sources.Clear();
        //        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    }).ConfigureServices((context, services) =>
        //    {
        //        services.AddDbContext<AppDbContext>(options =>
        //        {
        //            options.UseSqlServer(op => { context.})
        //        })
        //    });
        //}
    }
}









