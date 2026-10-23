using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EduSaasBackend.Models;
using EduSaasBackend.Modules.Authentification.Models;
using EduSaasBackend.Modules.Authentification.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EduSaasBackend.Modules.Authentification.Services;

public class AuthentificationService : IAuthentificationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    public AuthentificationService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterUserAsync(RegistrationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var email = request.Email.Trim();
        var user = new ApplicationUser
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = email,
            UserName = email
        };

        if (request.IsSchoolPrinc)
        {
            await _userManager.AddToRoleAsync(user, "Principal");
        }


        return await _userManager.CreateAsync(user, request.Password);
    }

    public async Task<string?> LoginUserAsync(LoginRequest loginRequest)
    {
        var email = loginRequest.Email;
        var password = loginRequest.Password;
        var user = await _userManager.FindByEmailAsync(email);

        if (user != null && await _userManager.CheckPasswordAsync(user, password))
        {
            var JwtToken = await GenerateJwtToken(user);
            return JwtToken;
        }
        ;

        return null;
    }

    private async Task<string> GenerateJwtToken(ApplicationUser user)
    {
        var SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY") ?? throw new InvalidOperationException("Environment variable 'JWT_SECRET' is required.");
        var issuer = Environment.GetEnvironmentVariable("JWt_Issuer") ?? throw new InvalidOperationException("Environment variable 'JWt_Issuer' is required.");
        var audience = Environment.GetEnvironmentVariable("JWT_Audience") ?? throw new InvalidOperationException("Environment variable 'JWT_Audience' is required.");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
        var roles = await _userManager.GetRolesAsync(user);
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var rolesClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty)
        }.Concat(rolesClaims);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials);

        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

        return jwtToken;
    }

}