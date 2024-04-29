namespace EFCoreVezba.ApiKeyAuth;

using System.Security.Cryptography;

public class ApiKeyRepository : IApiKeyRepository  {
    private readonly PostgresDbContext _context;

    public ApiKeyRepository(PostgresDbContext context) {
        _context = context;
    }

    public string CompanyId {get; set;}
    public string ApiKey { get; set; }
    public DateTime ValidUntil {get; set;}

    public string Create(string companyId){
        var companyApiKey = new CompanyApiKey 
            {
                    CompanyId = companyId, 
                    ValidUntil = DateTime.UtcNow.AddMonths(3),
                    ApiKey = GenerateKey()
            };

        _context.ApiKeys.Add(companyApiKey);

        _context.SaveChanges();

        return companyApiKey.ApiKey;
    }

    public CompanyApiKey? Get(string apiKey) {
        return _context.ApiKeys.Where(x => x.ApiKey == apiKey).FirstOrDefault();
    }

    public CompanyApiKey? GetByCompany(string companyId) {
        return _context.ApiKeys.Where(x => x.CompanyId == companyId).FirstOrDefault();
    }

    public string GetCompanyId(string apiKey) {
        var apiKeyEntity = _context.ApiKeys.FirstOrDefault(x => x.ApiKey == apiKey);

        if (apiKeyEntity != null)
        {
            return apiKeyEntity.CompanyId;
        }
        else throw new Exception("Api key not found!");
    }

    public bool ValidKeyExists(string companyId){
        return _context.ApiKeys.Any(k => k.CompanyId == companyId && k.ValidUntil > DateTime.UtcNow);
    }

    private string GenerateKey(){
        var provider = new RNGCryptoServiceProvider();
        var bytes = new byte[32];
        provider.GetBytes(bytes);
        return Convert.ToBase64String(bytes);
    }
}