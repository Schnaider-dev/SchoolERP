namespace EduSaasBackend.Modules.Authentification.Controllers;

using EduSaasBackend.Models;
using EduSaasBackend.Modules.Authentification.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    public AuthController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    //Avec Api Controller, il faut preciser à quelle route doit repondre la methode, sinon elle ne reponds qu'à la route de base qui correspond à l'attribut founit.
    // Contrairement au MVC avec vues, il n’y a pas de convention implicite Index. Il faut définir clairement comment on souhaite que l’URL corresponde.

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromQuery] RegisterUser RegisterUser)
    {
        var result = await _userManager.CreateAsync(RegisterUser.User);
        if (!result.Succeeded)
        {
            return BadRequest(result);
        }
        
        
        
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }

    [HttpGet]
    public string GetMessage()
    {
        return "contrairement au MVC avec vues, il n’y a pas de convention implicite Index → tu dois définir clairement comment tu veux que l’URL corresponde.";
    }

}