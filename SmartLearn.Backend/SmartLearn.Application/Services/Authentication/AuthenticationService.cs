using Microsoft.AspNetCore.Identity;
using SmartLearn.Application.Common;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.DTOs.Authentication;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Domain.Entities;

namespace SmartLearn.Application.Services.Authentication;
public class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
{
    public Task<Result<AuthResponse>> Register(RegisterRequest request)
    {
        
        var existingUser = _userManager.FindByEmailAsync(request.Email); 
        if (existingUser != null) 
            return Task.FromResult(Result<AuthResponse>.Failure("User is already exist"));
        
        var user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = request.Role
        };
        var result = _userManager.CreateAsync(user, request.Password);
        return Task.FromResult(Result<AuthResponse>.Failure("User is already exist"));
    }

    public Result<AuthResponse> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public Result<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request)
    {
        throw new NotImplementedException();
    }

    public Result<bool> RevokeToken(string email)
    {
        throw new NotImplementedException();
    }
}