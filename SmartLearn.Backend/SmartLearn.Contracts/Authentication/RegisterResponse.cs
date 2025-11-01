namespace SmartLearn.Contracts.Authentication; 

public record RegisterResponse
(
    Guid Id , 
    string FirstName,
    string LastName,
    string Token
);