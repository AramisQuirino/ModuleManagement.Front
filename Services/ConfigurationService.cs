using ModuleManagement.Web.Client.Models;
using System.Net.Http.Json;

namespace ModuleManagement.Web.Client.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly HttpClient _http;
        public ConfigurationService(HttpClient http)
        {
            _http = http;
        }

        #region Métodos para Company
        public async Task<Company> CreateCompanyAsync(Company company)
        {
            var response = await _http.PostAsJsonAsync("api/Configuration/company", company);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Company>();
        }

        public async Task<Company> GetCompanyAsync(int companyId)
        {
            return await _http.GetFromJsonAsync<Company>($"api/Configuration/company/{companyId}");
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            var response = await _http.PutAsJsonAsync($"api/Configuration/company/{company.IdCompany}", company);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCompanyAsync(int companyId)
        {
            var response = await _http.DeleteAsync($"api/Configuration/company/{companyId}");
            response.EnsureSuccessStatusCode();
        }

        #endregion

        #region Métodos para ColorScheme
        public async Task<ColorScheme> CreateColorSchemeAsync(ColorScheme colorScheme)
        {
            var response = await _http.PostAsJsonAsync("api/Configuration/colorscheme", colorScheme);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ColorScheme>();
        }

        public async Task<ColorScheme> GetColorSchemeAsync(int companyId)
        {
            return await _http.GetFromJsonAsync<ColorScheme>($"api/Configuration/colorscheme/{companyId}");
        }

        public async Task UpdateColorSchemeAsync(ColorScheme colorScheme)
        {
            var response = await _http.PutAsJsonAsync($"api/Configuration/colorscheme/{colorScheme.IdColorScheme}", colorScheme);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        #region Métodos para LinkPro
        public async Task<LinkPro> CreateLinkProAsync(LinkPro linkPro)
        {
            var response = await _http.PostAsJsonAsync("api/Configuration/linkpro", linkPro);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<LinkPro>();
        }

        public async Task<LinkPro> GetLinkProAsync(int companyId)
        {
            return await _http.GetFromJsonAsync<LinkPro>($"api/Configuration/linkpro/{companyId}");
        }

        public async Task UpdateLinkProAsync(LinkPro linkPro)
        {
            var response = await _http.PutAsJsonAsync($"api/Configuration/linkpro/{linkPro.IdLinkPro}", linkPro);
            response.EnsureSuccessStatusCode();
        }

        #endregion
    }
}
