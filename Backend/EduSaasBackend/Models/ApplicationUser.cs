using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace EduSaasBackend.Models;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(80)]
    public string FirstName { get; set; } = null!;

    [Required, StringLength(80)]
    public string LastName { get; set; } = null!;
    public string? GoogleId { get; set}
    public ICollection<SchoolMembership> SchoolMemberships { get; set; } = new List<SchoolMembership>();
}
