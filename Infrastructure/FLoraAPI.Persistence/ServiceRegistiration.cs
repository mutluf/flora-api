using FloraAPI.Application.Repositories.FarmerRepository;
using FloraAPI.Application.Repositories.FruitRepository;
using FloraAPI.Application.Repositories.TreeRepository;
using FloraAPI.Domain.Entities.User;
using FLoraAPI.Persistence.Context;
using FLoraAPI.Persistence.Repositories.FarmerRepository;
using FLoraAPI.Persistence.Repositories.FruitRepository;
using FLoraAPI.Persistence.Repositories.TreeRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FLoraAPI.Persistence
{
    public static class ServiceRegistiration
    {//bu metot içinde yazılabilir ama fark ettiysen buradaki addDbContext'i bir de program.cs içine static diye çağrılmıyor şu şey de.
        //static olmalı bu neden extension metot var içinde, aslında karışık da hazır bir metoda ekleme yapmak gibi anlamadım tamam anladım zaten movie de sen öyle yapmıştın?
       
        
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<FloraAPIDbContext>(options =>
     options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<ITreeReadRepository, TreeReadRepository>();
            services.AddScoped<ITreeWriteRepository, TreeWriteRepository>();
            services.AddScoped<IFruitReadRepository, FruitReadRepository>();
            services.AddScoped<IFruitWriteRepository, FruitWriteRepository>();
            services.AddScoped<IFarmerReadRepository, FarmerReadRepository>();
            services.AddScoped<IFarmerWriteRepository,FarmerWriteRepository>();
            //artık eklenecek servisleri buradan ekleyebilirsin dbcontext de buradan çalışacak.kullanıcı daha da sinirlensin diye şifre de ne istediğimizi belirtmeyeelim bir kez hata yapmadıkça+577
            services.AddIdentity<User, Role>(options =>
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

        //Bu metotda Connection string property yapısı oluşturduk. Bu yapıyı ServiceRegistiration içine vereceğiz.
        //.Get isteğine string gidecek ve ServiceRegistiration ile program.cs içine servis olarak eklenecektir.
        static public string ConnectionString
        {

            get
            {// ConnectionStringi alıyor artık.

                ConfigurationManager cfg = new ConfigurationManager();
                cfg.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/FLoraAPI.API"));
                cfg.AddJsonFile("appsettings.json");//microsoft.extensions.configuration.json adındaki paket üst 2 satır için gerekli.

                return cfg.GetConnectionString("MicrosoftSQL");
            }
        }
    }

}
