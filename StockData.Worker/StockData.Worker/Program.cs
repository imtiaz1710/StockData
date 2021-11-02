using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstDemo.Training;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using StockData.DataService.Contexts;
using System;

namespace StockData.Worker
{
    public class Program
    {
        private static IConfiguration _configuration = new ConfigurationBuilder()
                       .AddJsonFile("appsettings.json", false).AddEnvironmentVariables()
                       .Build();
        private static string _connectionString = _configuration.GetConnectionString("DefaultConnection");
        private static string _migrationAssemblyName = typeof(Worker).Assembly.FullName;

        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(_configuration)
                .CreateLogger();
            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureContainer<ContainerBuilder>(builder => {
                    builder.RegisterModule(new WorkerModule(_connectionString,
                        _migrationAssemblyName, _configuration));

                    builder.RegisterModule(new DataServiceModule(_connectionString,
                        _migrationAssemblyName));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    services.AddDbContext<DataServiceContext>(options =>
                        options.UseSqlServer(_connectionString, b =>
                        b.MigrationsAssembly(_migrationAssemblyName)));
                });
    }
}
