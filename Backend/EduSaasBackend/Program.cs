using System.Text;
using EduSaasBackend.Data;
using EduSaasBackend.Models;
using EduSaasBackend.Modules.Authentification.Services;
using EduSaasBackend.Modules.Authentification.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
        ValidIssuer = Environment.GetEnvironmentVariable("JWt_Issuer"),
        ValidAudience = Environment.GetEnvironmentVariable("JWT_Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            Environment.GetEnvironmentVariable("JWT_SECRET")
            ?? throw new InvalidOperationException("Environment variable 'JWT_SECRET' is required.")))
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

builder.Services.AddAuthorization(options => {
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Principal", policy => policy.RequireRole("Principal"));
    options.AddPolicy("DeputyPrincipal", policy => policy.RequireRole("DeputyPrincipal"));
    options.AddPolicy("Teacher", policy => policy.RequireRole("Teacher"));
    options.AddPolicy("Staff", policy => policy.RequireRole("Staff"));
    options.AddPolicy("Guardian", policy => policy.RequireRole("Guardian"));
    options.AddPolicy("Student", policy => policy.RequireRole("Student"));
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
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

await SeedRoles.SeedRolesAsync(app.Services);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
