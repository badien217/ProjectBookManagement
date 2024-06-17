using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace persistence
{
    public static class Registrations
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<AddDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnect")));
            //services.AddScoped(typeof(IReadReponsitories<>), typeof(ReadRepositories<>));
            //services.AddScoped(typeof(IWriteReponsitories<>), typeof(WriteReponsitory<>));
           // services.AddScoped<IUnitOfWork, UnitOfWork>(); 
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;
            })
               .AddRoles<Role>()
               .AddEntityFrameworkStores<AddDbContext>();
        }
    }
}
