using System.Reflection;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddMapperExtension
{
    public static WebApplicationBuilder AddMapper(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return builder;
    }
}