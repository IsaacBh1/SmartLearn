using SmartLearn.Application.Common;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.DTOs.Authentication;

namespace SmartLearn.Application.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<Result<AuthResponse>> Register(RegisterRequest request);
    Result <AuthResponse> Login(LoginRequest request);   
    Result<RefreshTokenResponse> RefreshToken(RefreshTokenRequest request); 
    Result<bool> RevokeToken(string email);

}