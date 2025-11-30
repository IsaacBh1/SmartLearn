using SmartLearn.Application.Common;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.DTOs.Authentication;

namespace SmartLearn.Application.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<Result<AuthResponse>> Register(RegisterRequest request);
    Task<Result<AuthResponse>> Login(LoginRequest request);   
    Task<Result<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request); 
    Task<Result<bool>> RevokeToken(string email);

}