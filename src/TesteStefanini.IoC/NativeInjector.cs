using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TesteStefanini.Application;
using TesteStefanini.Application.Interfaces;
using TesteStefanini.Data;
using TesteStefanini.Data.Repositories;
using TesteStefanini.Domain.Repositories;

namespace TesteStefanini.IoC
{
    public static class NativeInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            RegisterInfraServices(services);
            RegisterApplicationServices(services);
            services.AddDbContext<TesteStefaniniContext>(cfg => cfg.UseInMemoryDatabase("Data Source=localhost;Initial Catalog=stefanini_db;User ID=root;Password=admin"));

            return services;
        }

        private static void RegisterInfraServices(IServiceCollection services)
        {
            services.AddScoped<ITesteStefaniniRepository, TesteStefaniniRepository>();
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IOrderApplication, OrderApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
        }
    }
}
