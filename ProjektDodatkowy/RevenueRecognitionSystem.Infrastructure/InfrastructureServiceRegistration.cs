using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RevenueRecognitionSystem.Domain.Interfaces.Repositories;
using RevenueRecognitionSystem.Infrastructure.Implementations;

namespace RevenueRecognitionSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, string dbAdress)
        {
            services.AddDbContext<ReveuneDbContext>(options => options.UseSqlServer(dbAdress));
            
            
            
            
            services.AddScoped<IBaseClientRepository, BaseClientRepository>();
            services.AddScoped<ICompanyClientRepository, CompanyClientRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();           
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IIndividualClientRepository, IndividualClientRepository>();
            services.AddScoped<ISoftwareSystemRepository, SoftwareSystemRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
