using Application.Abstractions;
using Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.User;

[ApiController]
public class UserController(IAuthService authService) : ControllerBase
{
    [HttpPost("/api/auth/login")]
    public IActionResult Index(LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }
        
        var response = authService.Login(request);
        
        if(response == null)
            return NotFound(new ProblemDetails
            {
                Title = "User not found.",
                Detail = "User not found, please check username and password.",
                Status = StatusCodes.Status404NotFound
            });
        
        return Ok(response);
    }
    
    [HttpGet("/api/auth/baseInitialize")]
    public IActionResult BaseInitialize()
    {
        var response = authService.FirstInitiazlie();
        
        return Ok(response);
    }
}