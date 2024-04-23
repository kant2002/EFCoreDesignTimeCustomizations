using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EFCoreDesignTimeCustomizations.Design;

// Being public is important
public class DesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddEnumerable(new ServiceDescriptor(typeof(IModelCodeGenerator), typeof(MyTextTemplatingModelGenerator), ServiceLifetime.Singleton));
    }
}
