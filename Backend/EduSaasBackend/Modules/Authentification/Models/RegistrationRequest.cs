using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Modules.Authentification.Models;

public class RegistrationRequest
{
    [Required, StringLength(80, MinimumLength = 1)]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80, MinimumLength = 1)]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email field is required."), EmailAddress(ErrorMessage = "Please enter a valid email: youremail@gmail.com"), StringLength(256, MinimumLength = 20, ErrorMessage = "Email field cannot be longer than 256 characters.")]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(128, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;

    public bool IsSchoolPrinc { get; set; } = false;
}