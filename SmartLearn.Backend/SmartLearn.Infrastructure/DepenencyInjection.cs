using Microsoft.Extensions.DependencyInjection;
using SmartLearn.Application.Services.Authentication;

namespace SmartLearn.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}