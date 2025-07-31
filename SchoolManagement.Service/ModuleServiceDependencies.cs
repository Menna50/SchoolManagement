using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Service.Services.Abstract;
using SchoolManagement.Service.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Service
{
    public static  class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            return services; 
        }
    }
}
