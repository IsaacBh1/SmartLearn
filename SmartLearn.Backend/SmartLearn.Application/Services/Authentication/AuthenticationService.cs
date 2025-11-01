using SmartLearn.Application.Services.Authentication;

namespace SmartLearn.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService
{
    public LoginResult Login(string FirstName, string Password)
    {
        return new LoginResult(Guid.NewGuid(), "Demo", "User", "Dummy");
    }

    public RegisterResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new RegisterResult(Guid.NewGuid(), FirstName, LastName, "Dummy");
    }
}