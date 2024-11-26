using iikoTest.Services.Models;

namespace iikoTest.Services.Interfaces
{
    public interface IClientsRepository
    {
        Task<List<Client>> GetAsync();

        Task<Client?> GetByIdAsync(long id);

        Task UpdateAsync(Client updatedClient);

        Task RemoveAsync(Client deletingClient);

        //create default post create
        Task CreateUnique(Client client);
    }
}
