using EduSaasBackend.Modules.Authentification.Models;

namespace EduSaasBackend.Modules.Authentification.Services.Interfaces;

public interface IAuthentificationService
{
    public string RegisterUserAsync(RegisterUser user);
    public string LoginUserAsync();
}