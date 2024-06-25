using Microsoft.Extensions.DependencyInjection;
using RevenueRecognitionSystem.Domain.Interfaces.Services;

namespace RevenueRecognitionSystem.Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services)
        {
            //services.AddScoped<IUserService,USer>
            return services;
        }
    }
}

