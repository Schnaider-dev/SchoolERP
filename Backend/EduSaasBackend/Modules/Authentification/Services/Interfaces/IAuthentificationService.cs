using EduSaasBackend.Modules.Authentification.Models;
using Microsoft.AspNetCore.Identity;

namespace EduSaasBackend.Modules.Authentification.Services.Interfaces;

public interface IAuthentificationService
{
    public Task<IdentityResult> RegisterUserAsync(RegistrationRequest registerRequest);
    public Task<string?> LoginUserAsync(LoginRequest loginRequest);
}