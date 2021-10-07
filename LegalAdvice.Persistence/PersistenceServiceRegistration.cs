using LegalAdvice.Application.Contracts.Persistence;
using LegalAdvice.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LegalAdvice.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IRequestRepository, RequestRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ILawyerRepository, LawyerRepository>();

            return services;
        }
    }
}
