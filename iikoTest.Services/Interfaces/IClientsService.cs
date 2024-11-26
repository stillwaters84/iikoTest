using iikoTest.Services.Models;

namespace iikoTest.Services.Interfaces
{
    public interface IClientsService
    {
        Task<List<Client>> GetAsync();

        Task<Client?> GetByIdAsync(long id);

        Task UpdateAsync(Client updatedClient);

        Task RemoveAsync(Client deletingClient);

        Task<List<Client>> CreateUniqueMany(IEnumerable<Client> clients);
    }
}
