using EduSaasBackend.Data;
using EduSaasBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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


builder.Services.AddIdentityCore<ApplicationUser>()
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

app.UseAuthorization();

app.MapControllers();

app.Run();
