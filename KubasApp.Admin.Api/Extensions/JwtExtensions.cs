using KubasApp.Admin.Api.Configuration;
using KubasApp.Core.Extensions;
using KubasApp.Host.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace KubasApp.Admin.Api.Extensions;

public static class JwtExtensions
{
    public static void AddJwtAuth(this IServiceCollection builder)
    {
        builder
            .AddAuthorization()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var configuration = CustomHostBuilder.ConfigurationRoot.Get<AdminApiConfiguration>();
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = configuration.Jwt.ValidateIssuer,
                    ValidateAudience = configuration.Jwt.ValidateAudience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.Jwt.Issuer,
                    ValidAudience = configuration.Jwt.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(configuration.Jwt.Secret.ToByteArray())
                };
            });
    }
}