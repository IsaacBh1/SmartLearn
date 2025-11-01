namespace SmartLearn.Application.Services.Authentication;

public interface IAuthenticationService
{
    RegisterResult Register( string firstName,string lastName,string email,string password );
    LoginResult Login(string email , string password);   

}