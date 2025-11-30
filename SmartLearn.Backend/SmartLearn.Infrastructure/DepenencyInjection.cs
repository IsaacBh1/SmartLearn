using Microsoft.Extensions.DependencyInjection;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Application.Services.Authentication;
using SmartLearn.Infrastructure.Services.Auth;

namespace SmartLearn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }
}