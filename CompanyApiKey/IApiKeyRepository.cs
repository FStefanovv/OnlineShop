namespace EFCoreVezba.ApiKeyAuth;

public interface IApiKeyRepository {
    CompanyApiKey Get(string apiKey);
    CompanyApiKey GetByCompany(string companyId);
    string Create(string companyId);
    string GetCompanyId(string apiKey);
    bool ValidKeyExists(string companyId);
}