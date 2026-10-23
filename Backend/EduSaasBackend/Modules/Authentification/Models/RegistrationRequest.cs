using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Modules.Authentification.Models;

public class RegistrationRequest
{
    [Required, StringLength(80, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(128, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    public bool IsSchoolPrinc{ get; set; }
}