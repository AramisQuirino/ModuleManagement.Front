using ModuleManagement.Web.Client.Models;

namespace ModuleManagement.Web.Client.Services
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync(int idCompany);
        Task<int> CreateCompanyAsync(Company company);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int idCompany);
    }
}