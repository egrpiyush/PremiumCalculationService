using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PremiumCalculationService.Application;
using PremiumCalculationService.Functions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

[assembly: FunctionsStartup(typeof(Startup))]
namespace PremiumCalculationService.Functions
{
    public class Startup : FunctionsStartup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public Startup()
        {

        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var applicationAssembly = typeof(AutofacModule).GetTypeInfo().Assembly;
            builder.Services
                .AddMediatR(applicationAssembly);

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);
        }
    }
}
