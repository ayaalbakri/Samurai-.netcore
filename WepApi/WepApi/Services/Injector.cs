using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WepApi.Domain_Models;
using WepApi.Domain_Models.CityRepository;
using WepApi.Domain_Models.PointOfInterestRepository;

namespace WepApi.Services
{
    public static class Injector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            #region "Services"  
            services.AddMvc();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(ICityRepository), typeof(CityRepository));
            services.AddScoped(typeof(IPointOfInterestRepository), typeof(PointOfInterestRepository));
            return services;
            #endregion
        }





    }
}
