using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce.Common.Extensions;

public static class AuthenticationHandler
{
    public static IServiceCollection AddAuthentication(this IServiceCollection services,
        IOptions<jwtOption> jwtOptions)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Value.Issuer,
                    ValidAudience = jwtOptions.Value.Audience,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
                };
            });


        return services;
    }
}