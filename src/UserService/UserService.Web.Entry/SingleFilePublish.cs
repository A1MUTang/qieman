using Furion;
using System.Reflection;

namespace UserService.Web.Entry;

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
            "UserService.Application",
            "UserService.Core",
            "UserService.EntityFramework.Core",
            "UserService.Web.Core"
        };
    }
}