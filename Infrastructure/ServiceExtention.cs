using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceExtention
    {
        public static void AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TestAPIContext>(
                options => options
                .UseSqlServer(connectionString)
            );
            services.AddTransient<UserRepository, UserRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
