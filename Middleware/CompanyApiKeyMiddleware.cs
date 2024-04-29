namespace EFCoreVezba.Middleware;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EFCoreVezba.ApiKeyAuth;

public class CompanyApiKeyMiddleware {
     private readonly RequestDelegate _next;

    public CompanyApiKeyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IApiKeyRepository apiKeyRepository)
    {
        string apiKey = context.Request.Headers["Company-Api-Key"];
        if (!string.IsNullOrEmpty(apiKey))
        {
            var companyId = apiKeyRepository.GetCompanyId(apiKey);
            context.Items["CompanyId"] = companyId;
        }

        await _next(context);
    }
}