using System.Security.Claims;
using SmartLearn.Domain.Entities;

namespace SmartLearn.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}