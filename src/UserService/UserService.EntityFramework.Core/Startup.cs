using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace UserService.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "UserService.Database.Migrations");
    }
}
