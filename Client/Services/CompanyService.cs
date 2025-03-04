using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModuleManagement.Web.Client.Models;
using System.Text.Json;

namespace ModuleManagement.Web.Client.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _http;

        public CompanyService(HttpClient http)
        {
            _http = http;
        }

        // Método para obtener la lista de empresas filtradas por IdCompany
        public async Task<List<Company>> GetCompaniesAsync(int idCompany)
        {
            try
            {
                var response = await _http.GetAsync($"api/Configuration/company/{idCompany}");

                if (!response.IsSuccessStatusCode)
                {
                    // Lee el contenido para ver el error (puede ser HTML)
                    string errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Error {response.StatusCode}: {errorContent}");
                    return new List<Company>(); // O lanza una excepción
                }

                string json = await response.Content.ReadAsStringAsync();
                json = json.Trim();

                if (json.StartsWith("["))
                {
                    return JsonSerializer.Deserialize<List<Company>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    var single = JsonSerializer.Deserialize<Company>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    return new List<Company> { single };
                }
            }
            catch (Exception ex)
            {
                // Registra o muestra el error para depuración
                Console.WriteLine($"Exception: {ex.Message}");
                return new List<Company>();
            }
        }

        public async Task<int> CreateCompanyAsync(Company company)
        {
            var response = await _http.PostAsJsonAsync("api/Configuration/company", company);
            response.EnsureSuccessStatusCode();
            var created = await response.Content.ReadFromJsonAsync<Company>();
            return created.IdCompany;
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            await _http.PutAsJsonAsync($"api/Configuration/company/{company.IdCompany}", company);
        }

        public async Task DeleteCompanyAsync(int idCompany)
        {
            await _http.DeleteAsync($"api/Configuration/company/{idCompany}");
        }
    }
}