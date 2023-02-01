using BeHealthBackend.Configurations.Middleware;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderUseErrorHandlerExtension
{
    public static WebApplication UseErrorHandler(this WebApplication app)
    {
        app.UseMiddleware<ErrorHandlingMiddleware>();
        return app;
    }
}
