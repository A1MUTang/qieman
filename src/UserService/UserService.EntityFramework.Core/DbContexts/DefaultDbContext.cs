using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace UserService.EntityFramework.Core;

[AppDbContext("UserService", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
