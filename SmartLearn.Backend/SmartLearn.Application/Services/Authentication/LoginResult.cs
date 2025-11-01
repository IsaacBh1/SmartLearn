namespace SmartLearn.Application.Services.Authentication; 


public record LoginResult (

    Guid Id , 
    string FirstName,
    string LastName,
    string Token
); 