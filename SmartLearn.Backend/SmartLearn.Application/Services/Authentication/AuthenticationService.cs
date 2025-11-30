using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging; 
using SmartLearn.Application.Common;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.DTOs.Authentication;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Domain.Entities;

namespace SmartLearn.Application.Services.Authentication;

public class AuthenticationService(
    UserManager<User> userManager,
    SignInManager<User> signInManager,
    IJwtTokenGenerator jwtTokenGenerator,
    ILogger<AuthenticationService> logger) : IAuthenticationService
{
    private const string TokenProvider = "SmartLearnApp";
    private const string TokenName = "RefreshToken";

    public async Task<Result<AuthResponse>> Register(RegisterRequest request)
    {
        var existingUser = await userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {
            return Result<AuthResponse>.Failure("User already exists");
        }

        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = request.Role
        };

        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            logger.LogWarning("Registration failed for {Email}: {Errors}", request.Email, errors);
            return Result<AuthResponse>.Failure(errors);
        }

        
        return Result<AuthResponse>.Success(new AuthResponse(
            user.Id,
            string.Empty,
            string.Empty, 
            user.FirstName,
            user.LastName ?? string.Empty
        ), "User registered successfully");
    }

    public async Task<Result<AuthResponse>> Login(LoginRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            return Result<AuthResponse>.Failure("Invalid credentials");
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                return Result<AuthResponse>.Failure("Account is locked out");
            if (result.IsNotAllowed) 
                return Result<AuthResponse>.Failure("Email is not confirmed");
            
            return Result<AuthResponse>.Failure("Invalid credentials");
        }

        var accessToken = jwtTokenGenerator.GenerateAccessToken(user);
        var refreshToken = jwtTokenGenerator.GenerateRefreshToken();

        await UpdateRefreshToken(user, refreshToken);

        return Result<AuthResponse>.Success(new AuthResponse(
            user.Id,
            accessToken,
            refreshToken,
            user.FirstName,
            user.LastName ?? string.Empty
        ), "Login successful");
    }

    public async Task<Result<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
    {
        var principal = jwtTokenGenerator.GetPrincipalFromExpiredToken(request.Token);
        if (principal == null)
            return Result<RefreshTokenResponse>.Failure("Invalid access token");

        var userId = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (userId == null)
            return Result<RefreshTokenResponse>.Failure("Invalid token claims");

        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
            return Result<RefreshTokenResponse>.Failure("User not found");

        var storedRefreshToken = await userManager.GetAuthenticationTokenAsync(user, TokenProvider, TokenName);

        if (string.IsNullOrEmpty(storedRefreshToken) || storedRefreshToken != request.RefreshToken)
        {
            return Result<RefreshTokenResponse>.Failure("Invalid refresh token");
        }

        var newAccessToken = jwtTokenGenerator.GenerateAccessToken(user);
        var newRefreshToken = jwtTokenGenerator.GenerateRefreshToken();

        await UpdateRefreshToken(user, newRefreshToken);

        return Result<RefreshTokenResponse>.Success(new RefreshTokenResponse(newAccessToken, newRefreshToken));
    }

    public async Task<Result<bool>> RevokeToken(string email)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null)
            return Result<bool>.Failure("User not found");

        var result = await userManager.RemoveAuthenticationTokenAsync(user, TokenProvider, TokenName);

        if (!result.Succeeded)
            return Result<bool>.Failure("Could not revoke token");

        return Result<bool>.Success(true);
    }

    private async Task UpdateRefreshToken(User user, string refreshToken)
    {
        await userManager.RemoveAuthenticationTokenAsync(user, TokenProvider, TokenName);
        await userManager.SetAuthenticationTokenAsync(user, TokenProvider, TokenName, refreshToken);
    }
}