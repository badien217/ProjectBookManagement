using Application.Interfaces.AutoMapping;
using Mapping.AutoMapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public static class Registration
    {
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddSingleton<IAutoMapper, MapperCommonObject>();
        }
    }
}
