using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce.Common.Extensions;

public static class AuthorizationHandler
{

    public static IServiceCollection AddAuthorizationHandler(this IServiceCollection services)
    {
        // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //     .AddJwtBearer(options =>
        //     {
        //         options.TokenValidationParameters = new TokenValidationParameters
        //         {
        //             ValidateIssuerSigningKey = true,
        //             ValidIssuer = jwtOptions.Value.Issuer,
        //             ValidAudience = jwtOptions.Value.Audience,
        //             ValidateLifetime = false, // Disable lifetime validation
        //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key))
        //         };
        //     });

        return services;
    }
}