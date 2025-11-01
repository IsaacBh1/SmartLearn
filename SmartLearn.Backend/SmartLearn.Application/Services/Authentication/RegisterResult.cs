namespace SmartLearn.Application.Services.Authentication; 

public record RegisterResult (

    Guid Id , 
    string FirstName,
    string LastName,
    string Token
); 