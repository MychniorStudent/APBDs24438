using Microsoft.Extensions.DependencyInjection;
using RevenueRecognitionSystem.Application.Implementations;
using RevenueRecognitionSystem.Domain.Interfaces.Services;

namespace RevenueRecognitionSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IClientService,ClientService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IUserService, UserService>();

            //services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
