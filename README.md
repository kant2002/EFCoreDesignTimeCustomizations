# EFCoreDesignTimeCustomizations

Customization for the EF Core Scaffolding process.

In rare cases where T4 does not enough for you, or you want generate slightly more, you can replace EF Core codegeneration process.
Be aware that this approach tied to EF Core version, but it does not change significantly couple releases, so it more or less safe.

First of all you have to do 2 things.
1. Create registration of service overrides.
2. Create custom scaffolder.

# Create registration of service overrides.

This is done by creation of public class in startup assembly, which derived from `Microsoft.EntityFrameworkCore.Design.IDesignTimeServices`

```
public class DesignTimeServices : IDesignTimeServices
{
    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    {
        // Add registration of custom design-time services here.
    }
}
```

# Create custom scaffolder

Now you should create custom implementation for `Microsoft.EntityFrameworkCore.Scaffolding.IModelCodeGenerator`.
Because I need only show proof-of-concept for a friend, then I simply copy existing implementation of [TextTemplatingModelGenerator](https://github.com/dotnet/efcore/blob/release/8.0/src/EFCore.Design/Scaffolding/Internal/TextTemplatingModelGenerator.cs)

After I add nescessary modifications, I add registration of the service inside `ConfigureDesignTimeServices`

```
serviceCollection.TryAddEnumerable(new ServiceDescriptor(typeof(IModelCodeGenerator), typeof(MyTextTemplatingModelGenerator), ServiceLifetime.Singleton));
```

# That's it folks!