using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.InfrastructureBases;
using SchoolManagement.Infrastructure.Repositories.Implementations;
using SchoolManagement.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient(typeof(IGenericRepo<>),typeof(GenericRepo<>)) ;
            return services;
        }
    }
}
