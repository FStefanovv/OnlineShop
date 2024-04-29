namespace EFCoreVezba.Middleware;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EFCoreVezba.ApiKeyAuth;
using System.Security.Claims;


public class UserClaimsMiddleware {
     private readonly RequestDelegate _next;

    public UserClaimsMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        var userEmailClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

        if (userIdClaim != null)
        {
            var userId = userIdClaim.Value;
            context.Items["UserId"] = userId;
        }

        if (userEmailClaim != null)
        {
            var userEmail = userEmailClaim.Value;
            context.Items["UserEmail"] = userEmail;
        }

        await _next(context);
    }

}