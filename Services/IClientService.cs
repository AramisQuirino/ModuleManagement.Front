using ModuleManagement.Web.Client.Models;

namespace ModuleManagement.Web.Client.Services
{
    public interface IClientService
    {
        // Métodos para Cliente
        Task<ClientList> CreateClientAsync(ClientList client);
        Task<ClientList> GetClientAsync(int idClient);
        Task<IEnumerable<ClientList>> GetAllClientsAsync();
        Task UpdateClientAsync(ClientList client);
        Task<bool> DeleteClientAsync(int idClient);

        // Métodos para Gender (Opcional, si los necesitas en el mismo servicio)
        Task<Gender> CreateGenderAsync(Gender gender);
        Task<Gender> GetGenderAsync(int idGender);
        Task<IEnumerable<Gender>> GetAllGendersAsync();
        Task UpdateGenderAsync(Gender gender);
        Task<bool> DeleteGenderAsync(int idGender);
    }
}
