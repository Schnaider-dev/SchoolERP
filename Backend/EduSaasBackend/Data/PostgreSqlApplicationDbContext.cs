using Microsoft.EntityFrameworkCore;

namespace EduSaasBackend.Data;

public sealed class PostgreSqlApplicationDbContext(
    DbContextOptions<PostgreSqlApplicationDbContext> options)
    : ApplicationDbContext(options);
