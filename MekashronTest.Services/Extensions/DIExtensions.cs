using MekashronTest.Services.Login;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MekashronTest.Services.Extensions
{
    public static class DIExtensions
    {
        public static IServiceCollection RegisterLogin(this IServiceCollection services)
        {
            services
                .AddTransient<ILoginService, LoginService>();

            return services;
        } 
    }
}
