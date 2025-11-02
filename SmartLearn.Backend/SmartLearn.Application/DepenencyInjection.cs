using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Application.Services.Authentication;
using SmartLearn.Domain.Entities;

namespace  SmartLearn.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>(); 
        
        return services;
    }
    
}