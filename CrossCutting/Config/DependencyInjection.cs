using Data.Context;
using Data.Repositories;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Mapping;
using Service.Services;

namespace CrossCutting.Config
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContextDb>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IRenterRepository, RenterRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IRenterService, RenterService>();
            services.AddAutoMapper(typeof(DTOToDomain));
            return services;
        }
    }
}
