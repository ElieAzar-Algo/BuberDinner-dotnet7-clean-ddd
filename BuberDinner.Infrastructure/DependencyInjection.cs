using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BuberDinner.Infrastructure.Persistence;
using BuberDinner.Application.Common.Interfaces.Persistance;

namespace BuberDinner.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName!));

            services.AddSingleton<IJwtTokenGenerator, jwtTokenGenerator>();
            services.AddSingleton<IDateTimePorvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, userRepository>();
            return services;
    }
}