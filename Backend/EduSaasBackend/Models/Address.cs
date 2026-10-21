using System.ComponentModel.DataAnnotations;

namespace EduSaasBackend.Models;

public class Address
{
    [Required, StringLength(100, MinimumLength = 2)]
    public string Country { get; set; } = null!;

    [Required, StringLength(100, MinimumLength = 2)]
    public string City { get; set; } = null!;

    [Required, StringLength(100, MinimumLength = 2)]
    public string Municipality { get; set; } = null!;

    [StringLength(150)]
    public string? StreetAddress { get; set; }

    [StringLength(20)]
    public string? PostalCode { get; set; }

    [StringLength(250)]
    public string? MorePrecision { get; set; }
}
