using API;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.NUnit.Infrastructure.Integration.Test
{
    [SetUpFixture]
    public partial class Testing
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [OneTimeSetUp]
        public void RunBeforeAnyTest()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var serveces = new ServiceCollection();
            var startup = new Startup(_configuration);

            serveces.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            w.ApplicationName == "API" &&
            w.EnvironmentName == "Development"));

            startup.ConfigureServices(serveces);

            _scopeFactory = serveces.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var contex = scope.ServiceProvider.GetService<StoreContext>();

            contex.Add(entity);
            await contex.SaveChangesAsync();
        }

        //public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
    }
}
