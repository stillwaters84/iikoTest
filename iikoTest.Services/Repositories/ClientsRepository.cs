using iikoTest.Services.Interfaces;
using iikoTest.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /*
         * Дополнительно реализовать один post метод, который в теле запроса будет принимать массив объектов (не менее 10)
        Этот метод должен сравнить существующие в бд данные на предмет дубликатов (только по ключу), и добавить только уникальные объекты
        В теле ответа должны прийти все недобавленные объекты
        При этом добавление и сравнение каждого объекта в этом методе должно выполняться асинхронно
        */
        public async Task CreateUnique(Client client)
        {
            _dbSet.AddAsync(client);
            await _dbContext.SaveChangesAsync();
        }
    }
}
