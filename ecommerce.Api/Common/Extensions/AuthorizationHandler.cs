using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ecommerce.Common.Extensions;

public static class AuthorizationHandler
{
    public static IServiceCollection AddAuthorizationPolicy(this IServiceCollection services)
    {
       
        services.AddAuthorization();

        return services;
    }
}