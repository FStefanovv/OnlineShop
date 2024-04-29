namespace EFCoreVezba.ApiKeyAuth;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class CompanyApiKey {
    
    public CompanyApiKey(){}

    [Key]
    public string ApiKey { get; set; }
    public string CompanyId {get; set;}
    public DateTime ValidUntil {get; set;}
}


public class CompanyApiKeyAttribute : ServiceFilterAttribute
{
    public CompanyApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter))
    {
    }
}

public class ApiKeyAuthorizationFilter : IAuthorizationFilter
{
    private const string ApiKeyHeaderName = "Company-Api-Key";

    private readonly IApiKeyValidator _apiKeyValidator;

    public ApiKeyAuthorizationFilter(IApiKeyValidator apiKeyValidator)
    {
        _apiKeyValidator = apiKeyValidator;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string apiKey = context.HttpContext.Request.Headers[ApiKeyHeaderName];

        if (!_apiKeyValidator.IsValid(apiKey))
        {
            context.Result = new UnauthorizedResult();
        }
    }
}

public class ApiKeyValidator : IApiKeyValidator
{
    private readonly IApiKeyRepository _apiKeyRepository;
    public ApiKeyValidator(IApiKeyRepository apiKeyRepository){
        _apiKeyRepository = apiKeyRepository;
    }

    public bool IsValid(string apiKey)
    {
        CompanyApiKey key = _apiKeyRepository.Get(apiKey);

        if(key==null || key.ValidUntil < DateTime.UtcNow)
            return false;
        return true;
    }
}

public interface IApiKeyValidator
{
    bool IsValid(string apiKey);
}