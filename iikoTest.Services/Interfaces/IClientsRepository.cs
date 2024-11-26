using iikoTest.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
