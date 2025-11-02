using Microsoft.AspNetCore.Mvc;
using SmartLearn.Application.DTOs.Auth;
using SmartLearn.Application.Interfaces.Authentication;
using SmartLearn.Application.Services.Authentication;

namespace SmartLearn.Api.Controllers;


[Controller]
[Route("auth")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    // [Route("register")]
    // public IActionResult Register([FromBody] RegisterRequest request)
    // {
    //     var result = authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password); 
    //     return Ok(result);
    // }
    //
    // [Route("login")]
    // public IActionResult Login([FromBody] LoginRequest request)
    // {
    //     var result = authenticationService.Login(request.Email, request.Password);
    //     return Ok(result);
    // }
}