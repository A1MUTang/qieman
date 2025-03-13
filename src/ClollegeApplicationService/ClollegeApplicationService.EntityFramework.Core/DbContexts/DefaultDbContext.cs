using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace ClollegeApplicationService.EntityFramework.Core;

[AppDbContext("ClollegeApplicationService", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
