using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SmartLearn.Domain.Shared;

namespace SmartLearn.Application.DTOs.Authentication; 


public record RegisterRequest
(
    [Required]
    string FirstName,
    string LastName,
    [EmailAddress]
    string Email,
    [PasswordPropertyText]
    string Password ,
    [Required]
    enRole Role 
);