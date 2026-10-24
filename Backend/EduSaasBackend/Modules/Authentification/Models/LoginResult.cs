namespace EduSaasBackend.Modules.Authentification.Models;

public class LoginResult
{
    public string? Token { get; set; }
    public string? ErrorMessage { get; set; }
}