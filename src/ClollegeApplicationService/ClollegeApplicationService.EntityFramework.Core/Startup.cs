using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace ClollegeApplicationService.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "ClollegeApplicationService.Database.Migrations");
    }
}
