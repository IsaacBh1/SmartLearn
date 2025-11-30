using Microsoft.AspNetCore.Mvc;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.DTOs.Authentication;
using SmartLearn.Application.Interfaces.Authentication;

namespace SmartLearn.Api.Controllers;


[Controller]
[Route("auth")]
public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
{
    [Route("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var result = _authenticationService.Register(request); 
        return Ok(result);
    }
    
    [Route("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authenticationService.Login(request);
        return Ok(result);
    }
}