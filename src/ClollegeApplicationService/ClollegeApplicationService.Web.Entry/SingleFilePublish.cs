using Furion;
using System.Reflection;

namespace ClollegeApplicationService.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "ClollegeApplicationService.Application",
            "ClollegeApplicationService.Core",
            "ClollegeApplicationService.EntityFramework.Core",
            "ClollegeApplicationService.Web.Core"
        };
    }
}