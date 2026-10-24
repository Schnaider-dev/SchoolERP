using System.Text;
using EduSaasBackend.Data;
using EduSaasBackend.Models;
using EduSaasBackend.Modules.Authentification.Services;
using EduSaasBackend.Modules.Authentification.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsDevelopment())
{
    var connectionString = builder.Configuration.GetConnectionString("Sqlite")
        ?? throw new InvalidOperationException(
            "Connection string 'Sqlite' is required in the Development environment.");

    builder.Services.AddDbContext<SqliteApplicationDbContext>(options =>
    {
        options.UseSqlite(connectionString);
    });
    builder.Services.AddScoped<ApplicationDbContext>(
        services => services.GetRequiredService<SqliteApplicationDbContext>());
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("PostgreSql")
        ?? throw new InvalidOperationException(
            "Connection string 'PostgreSql' must be configured outside Development.");

    builder.Services.AddDbContext<PostgreSqlApplicationDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
    builder.Services.AddScoped<ApplicationDbContext>(
        services => services.GetRequiredService<PostgreSqlApplicationDbContext>());
}
;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            Environment.GetEnvironmentVariable("SECRET_KEY")
            ?? throw new InvalidOperationException("Environment variable 'SECRET_KEY' is required.")))
    };
})
.AddGoogle(options =>
{
    options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID") ?? throw new InvalidOperationException("Environment variable 'GOOGLE_CLIENT_ID' is required.");
    options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET") ?? throw new InvalidOperationException("Environment variable 'GOOGLE_CLIENT_SECRET' is required.");
   
    options.Events = new OAuthEvents
    {
        OnCreatingTicket = async context =>
        {
            var email = context.Identity?.FindFirst(ClaimTypes.Email)?.Value;
            var googleId = context.Identity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var firstName = context.Identity?.FindFirst(ClaimTypes.GivenName)?.Value;
            var lastName = context.Identity?.FindFirst(ClaimTypes.Surname)?.Value;

            var userManager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();
            var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
            var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthentificationService>();

            if (string.IsNullOrWhiteSpace(email))
            {
                return;
            }

            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                var newUser = new ApplicationUser
                {
                    FirstName = firstName ?? "",
                    LastName = lastName ?? "",
                    Email = email,
                    UserName = email,
                    GoogleId = googleId
                };
                var createResult = await userManager.CreateAsync(newUser);
                if (createResult.Succeeded) user = newUser;
            }
            else
            {
                // Link GoogleId if not already linked
                if (string.IsNullOrEmpty(user.GoogleId))
                {
                    user.GoogleId = googleId;
                    await userManager.UpdateAsync(user);
                }
            }

            var result = await authService.LoginByGoogleAsync(user);
        }
    };
});

//TODO
// .AddOAuth("Google", options =>
// {
//     options.ClientId = builder.Configuration["Authentication:Google:ClientId"]
//         ?? throw new InvalidOperationException("Google OAuth client ID is required.");
//     options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]
//         ?? throw new InvalidOperationException("Google OAuth client secret is required.");
//     options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
//     options.TokenEndpoint = "https://oauth2.googleapis.com/token";
//     options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";
//     options.CallbackPath = "/signin-google";
//     options.Scope.Add("email");
//     options.Scope.Add("profile");
// });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(IdentityPolicyData.UserAdminPolictName, policy => policy.RequireRole(IdentityPolicyData.UserAdminPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserPrincipalPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserDeputyPrincipalPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserDeputyPrincipalPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserDeputyPrincipalPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserTeacherPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserTeacherPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserStaffPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserStaffPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserStudentGuardianPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserStudentGuardianPolicyRole));
    options.AddPolicy(IdentityPolicyData.UserStudentPolicyName, policy => policy.RequireRole(IdentityPolicyData.UserStudentPolicyRole));
});

builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();

//Need to save these services into DI to get access to services like UserManager, RoleManager, ect
// AddIdentityCore provides the minimun services required for user manager plus JWT settings for user authentification
builder.Services.AddIdentityCore<ApplicationUser>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = true;
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

// TODO: builder.Services.AddAuthentication();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, _, _) =>
    {
        document.Components ??= new OpenApiComponents();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "Jwt"
        };
        return Task.CompletedTask;
    });

    options.AddOperationTransformer((operation, context, _) =>
    {
        var metadata = context.Description.ActionDescriptor.EndpointMetadata;
        var requiresAuthorization = metadata.OfType<IAuthorizeData>().Any();
        var allowsAnonymous = metadata.OfType<IAllowAnonymous>().Any();

        if (requiresAuthorization && !allowsAnonymous)
        {
            operation.Security ??= [];
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", context.Document)] = []
            });
        }
        return Task.CompletedTask;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "EduSaas API V1"); });
}

await SeedRoles.SeedRolesAsync(app.Services);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
