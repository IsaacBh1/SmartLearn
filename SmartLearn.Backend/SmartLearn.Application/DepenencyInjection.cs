using Microsoft.Extensions.DependencyInjection;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Application.Services.Authentication;

namespace  SmartLearn.Application;

public static class ServiceExtentions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>(); 
        
        return services;
    }
    
}