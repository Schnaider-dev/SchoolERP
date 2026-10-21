using EduSaasBackend.Modules.Authentification.Models;
using EduSaasBackend.Modules.Authentification.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace EduSaasBackend.Modules.Authentification.Services;

public class AuthentificationService : IAuthentificationService
{
    private readonly UserManager<RegisterUser> _userManager;
    private readonly SignInManager<RegisterUser> _signInManager;
    public AuthentificationService(UserManager<RegisterUser> userManager, SignInManager<RegisterUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public string RegisterUserAsync(RegisterUser user)
    {
        return "";
    }
    public string LoginUserAsync()
    {
        return "";
    }
}