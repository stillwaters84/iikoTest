using iikoTest.Services.Interfaces;
using iikoTest.Services.Models;

namespace iikoTest.Services.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientRepository;

        public ClientsService(IClientsRepository clientsRepository)
        {
            _clientRepository = clientsRepository;
        }

        public async Task<List<Client>> GetAsync()
        {
            return await _clientRepository.GetAsync();
        }

        public async Task<Client?> GetByIdAsync(long id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Client updatedClient)
        {
            //if SystemId is not in request then it will become default value
            await _clientRepository.UpdateAsync(updatedClient);
        }

        public async Task RemoveAsync(Client deletingClient)
        {
            await _clientRepository.RemoveAsync(deletingClient);
        }

        public async Task<List<Client>> CreateUniqueMany(IEnumerable<Client> clients)
        {
            if(clients.Count() < 10)
            {
                return null;
            }

            var existingClients = await _clientRepository.GetAsync();
            var nonUniqueClients = new List<Client>();
            foreach (var client in clients)
            {
                if(existingClients.Exists(x => x.ClientId == client.ClientId))
                {
                    nonUniqueClients.Add(client);
                    continue;
                }

                //PK can't be 0
                if(client.ClientId == 0)
                {
                    nonUniqueClients.Add(client);
                    continue;
                }
                client.SystemId = Guid.NewGuid();
                await _clientRepository.CreateUnique(client);
            }

            return nonUniqueClients;
        }
    }
}
