using BeHealthBackend.Configurations.Middleware;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddErrorHandlerExtension
{
    public static WebApplicationBuilder AddErrorHandler(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ErrorHandlingMiddleware>();
        return builder;
    }
}
