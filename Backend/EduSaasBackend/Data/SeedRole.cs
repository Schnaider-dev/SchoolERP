using EduSaasBackend.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace EduSaasBackend.Data;

public static class SeedRoles{
    public static async Task SeedRolesAsync(IServiceProvider service)
    {
        //RoleManager Service is a scoped service, it can only run when in scope
        using var scope = service.CreateScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        var roles = Enum.GetValues<SchoolRole>().Select(s => s.ToString()).ToList();

        foreach(string role in roles)
        {
            if(!await roleManager.RoleExistsAsync(role))
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role));
                if (!result.Succeeded){
                    var errors = String.Join(";\n", result.Errors.Select(error => error.Description));
                    throw new InvalidOperationException($"Could not create role: {role}: {errors}");
                }
            }
        }

    }
}