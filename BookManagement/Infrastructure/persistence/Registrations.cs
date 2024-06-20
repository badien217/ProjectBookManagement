using Application.Interfaces.Reponsitories;
using Application.Interfaces.UnitOfWork;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using persistence.context;
using persistence.Reponsitory;
using persistence.UnitOfWork;
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
            services.AddScoped(typeof(IReadReponsitory<>), typeof(ReadReponsitory<>));
            services.AddScoped(typeof(IWriteReponsitory<>), typeof(WriteReponsitory<>));
            services.AddScoped<IUnitOfWork, UnitOfWorks>(); 
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
