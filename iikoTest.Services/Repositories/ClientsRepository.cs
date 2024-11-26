using iikoTest.Services.Interfaces;
using iikoTest.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace iikoTest.Services.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Client> _dbSet;

        public ClientsRepository(iikoTest.Services.Contexts.AppContext appContext)
        {
            _dbContext = appContext;
            _dbSet = _dbContext.Set<Client>();
        }

        public async Task<List<Client>> GetAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(Client updatedClient)
        {
            _dbSet.Update(updatedClient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Client deletingClient)
        {
            _dbSet.Remove(deletingClient);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task CreateUnique(Client client)
        {
            _dbSet.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
