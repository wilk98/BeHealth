using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BeHealthBackend.Configurations.Extensions;
public static class WebApplicationBuilderAddAuthenticationExtension
{
    public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        var authenticationSettings = new AuthenticationSettings();

        builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);

        builder.Services.AddSingleton(authenticationSettings);
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = "Bearer";
            option.DefaultScheme = "Bearer";
            option.DefaultChallengeScheme = "Bearer";
        }).AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authenticationSettings.JwtIssuer,
                ValidAudience = authenticationSettings.JwtIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
            };
        });

        return builder;
    }
}