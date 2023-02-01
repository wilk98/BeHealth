using NLog.Web;

namespace BeHealthBackend.Configurations.Extensions
{
    public static class WebApplicationBuilderAddLoggingExtension
    {
        public static WebApplicationBuilder AddLogger(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Host.UseNLog();
            return builder;
        }
    }
}
