using EduSaasBackend.Models;
using EduSaasBackend.Models.Enum;

namespace EduSaasBackend.Modules.Authentification.Models;

public class RegisterUser
{
    public ApplicationUser User { get; set; } = null!;
    public SchoolRole Role { get; set; }
}