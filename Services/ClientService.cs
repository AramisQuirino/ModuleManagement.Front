using ModuleManagement.Web.Client.Models;
using System.Net.Http.Json;

namespace ModuleManagement.Web.Client.Services
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;

        public ClientService(HttpClient http)
        {
            _http = http;
        }

        #region Métodos para Cliente

        public async Task<ClientList> CreateClientAsync(ClientList client)
        {
            var response = await _http.PostAsJsonAsync("api/Client/Client", client);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ClientList>();
        }

        public async Task<ClientList> GetClientAsync(int idClient)
        {
            return await _http.GetFromJsonAsync<ClientList>($"api/Client/Client/{idClient}");
        }

        public async Task<IEnumerable<ClientList>> GetAllClientsAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<ClientList>>("api/Client/Client");
        }

        public async Task UpdateClientAsync(ClientList client)
        {
            var response = await _http.PutAsJsonAsync($"api/Client/Client/{client.IdClient}", client);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteClientAsync(int idClient)
        {
            var response = await _http.DeleteAsync($"api/Client/Client/{idClient}");
            return response.IsSuccessStatusCode;
        }


        #endregion

        #region Métodos para Gender (Opcional)

        public async Task<Gender> CreateGenderAsync(Gender gender)
        {
            var response = await _http.PostAsJsonAsync("api/Client/gender", gender);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Gender>();
        }

        public async Task<Gender> GetGenderAsync(int idGender)
        {
            return await _http.GetFromJsonAsync<Gender>($"api/Client/gender/{idGender}");
        }

        public async Task<IEnumerable<Gender>> GetAllGendersAsync()
        {
            return await _http.GetFromJsonAsync<IEnumerable<Gender>>("api/Client/gender");
        }

        public async Task UpdateGenderAsync(Gender gender)
        {
            var response = await _http.PutAsJsonAsync($"api/Client/gender/{gender.IdGender}", gender);
            response.EnsureSuccessStatusCode();
        }

        public async Task<bool> DeleteGenderAsync(int idGender)
        {
            var response = await _http.DeleteAsync($"api/Client/gender/{idGender}");
            return response.IsSuccessStatusCode;
        }

        #endregion
    }
}
