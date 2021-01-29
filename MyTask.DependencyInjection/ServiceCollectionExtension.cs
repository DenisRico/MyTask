using System;
using Microsoft.Extensions.DependencyInjection;
using MyTask.Interfaces.Services;
using MyTask.BusinessLogic.Services.Car;


namespace MyTask.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterBusinessLogicServices(this IServiceCollection services)
        {
            ///service car
            services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
