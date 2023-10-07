using AutoMapper;
using CapitalPlacement.Repository;
using CapitalPlacement.Repository.Interface;

namespace CapitalPlacement.Extension
{
    public static class ServiceRepositoryExtension
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProgramDetails, ProgramDetailsRepository>();
            services.AddScoped<IApplicationForm, ApplicationFormRepository>();
            services.AddScoped<IWorkFlow, WorkFlowRepository>();
          

            return services;
        }
    }
}
