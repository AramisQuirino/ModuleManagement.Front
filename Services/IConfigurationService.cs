using ModuleManagement.Web.Client.Models;

namespace ModuleManagement.Web.Client.Services
{
    public interface IConfigurationService
    {
        // Company
        Task<Company> CreateCompanyAsync(Company company);
        Task<Company> GetCompanyAsync(int companyId);
        Task UpdateCompanyAsync(Company company);
        Task DeleteCompanyAsync(int companyId);

        // ColorScheme
        Task<ColorScheme> CreateColorSchemeAsync(ColorScheme colorScheme);
        Task<ColorScheme> GetColorSchemeAsync(int companyId);
        Task UpdateColorSchemeAsync(ColorScheme colorScheme);

        // LinkPro
        Task<LinkPro> CreateLinkProAsync(LinkPro linkPro);
        Task<LinkPro> GetLinkProAsync(int companyId);
        Task UpdateLinkProAsync(LinkPro linkPro);
    }
}
