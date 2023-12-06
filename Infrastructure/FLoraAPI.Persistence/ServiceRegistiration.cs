using FloraAPI.Application.Abstractions.Cache;
using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Application.Repositories.FruitRepository;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities.User;
using FloraAPI.Persistence.Services;
using FLoraAPI.Persistence.Context;
using FLoraAPI.Persistence.Repositories.FarmerRepository;
using FLoraAPI.Persistence.Repositories.FruitRepository;
using FLoraAPI.Persistence.Repositories.TreeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace FLoraAPI.Persistence
{
    public static class ServiceRegistiration
    {
        
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            services.AddSingleton<IConnectionMultiplexer>(multiplexer);

            services.AddDbContext<FloraAPIDbContext>(options =>
     options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ITreeReadRepository, TreeReadRepository>();
            services.AddScoped<ITreeWriteRepository, TreeWriteRepository>();
            services.AddScoped<IFruitReadRepository, FruitReadRepository>();
            services.AddScoped<IFruitWriteRepository, FruitWriteRepository>();
            services.AddScoped<IFarmerReadRepository, FarmerReadRepository>();
            services.AddScoped<IFarmerWriteRepository,FarmerWriteRepository>();

            services.AddSingleton<ICacheService, CacheService>();

            services.AddIdentity<User, FloraAPI.Domain.Entities.User.Role>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireDigit = true;
                options.User.RequireUniqueEmail = true;
                
            }
          
            ).AddEntityFrameworkStores<FloraAPIDbContext>();
        }
    }
    public static class Configuration
    {

       
        static public string ConnectionString
        {

            get
            {

                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/FLoraAPI.API"));
                cfg.AddJsonFile("appsettings.json");//microsoft.extensions.configuration.json adındaki paket üst 2 satır için gerekli.

                return cfg.GetConnectionString("MicrosoftSQL");
            }
        }
    }

}
