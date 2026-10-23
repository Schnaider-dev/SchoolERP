namespace EduSaasBackend.Modules.Authentification.Controllers;

using EduSaasBackend.Modules.Authentification.Models;
using EduSaasBackend.Modules.Authentification.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

//With [ApiController], invalid DTOs automatically get a 400 Bad Request.
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly IAuthentificationService _authentificationService;
    public AuthController(IAuthentificationService authentificationService)
    {
        _authentificationService = authentificationService;
    }


    /* 
        Avec Api Controller, il faut preciser a quelle route doit repondre la methode, sinon elle ne reponds qu'a la route de base qui correspond a l'attribut founit.
        Contrairement au MVC avec vues, il n y a pas de convention implicite Index. Il faut definir clairement comment on souhaite que l URL corresponde.

    */
    [HttpPost("register")]

    // AuthController.cs accepts registration as a JSON body.
    public async Task<IActionResult> Register([FromBody] RegistrationRequest registerRequest)
    {
        var result = await _authentificationService.RegisterUserAsync(registerRequest);
        if (!result.Succeeded)
        {
            return BadRequest(new
            {
                errors = result.Errors.Select(error => new
                {
                    error.Code,
                    error.Description
                })
            });
        }

        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var jwtToken = await _authentificationService.LoginUserAsync(loginRequest);
        if(jwtToken is not null)
        {
            return Ok(jwtToken);
        }
        return Unauthorized();
    }

}