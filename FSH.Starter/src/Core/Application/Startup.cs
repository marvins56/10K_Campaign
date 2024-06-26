using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FSH.Starter.Application;

public static class Startup
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services
            .AddValidatorsFromAssembly(assembly)
            .AddMediatR(assembly)
            .AddAutoMapper(assembly);


    }
}