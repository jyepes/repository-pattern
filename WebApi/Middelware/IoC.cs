using System;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Generic;

namespace WebApi.Middelware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            //inyectar los servicios del repositorio genérico
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
