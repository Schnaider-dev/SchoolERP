using Microsoft.EntityFrameworkCore;

namespace EduSaasBackend.Data;

public sealed class SqliteApplicationDbContext(
    DbContextOptions<SqliteApplicationDbContext> options)
    : ApplicationDbContext(options);
