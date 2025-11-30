namespace SmartLearn.Application.DTOs.Authentication;

public record RefreshTokenResponse(
        string Token,
        string RefreshToken
);