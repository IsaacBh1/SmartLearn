namespace SmartLearn.Contracts.Authentication; 

public record LoginResponse
(
    Guid Id,
    string FirstName,
    string LastName,
    Guid Role, 
    string Token
);