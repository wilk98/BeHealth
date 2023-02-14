using BeHealthBackend.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddAuthorizationExtension
{
    public static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthorizationHandler, DoctorResourceOperationRequirementHandler>();

        return builder;
    }
}
