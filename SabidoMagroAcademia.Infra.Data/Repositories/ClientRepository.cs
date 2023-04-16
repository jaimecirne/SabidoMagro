using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using SabidoMagroAcademia.Infra.Data.Context;

namespace SabidoMagroAcademia.Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext _clientContext;
        public ClientRepository(ApplicationDbContext context)
        {
            _clientContext = context;
        }

        public async Task<Client> CreateAsync(Client product)
        {
            _clientContext.Add(product);
            await _clientContext.SaveChangesAsync();
            return product;
        }

        public async Task<Client> GetByIdAsync(int? id)
        {
            //eager loading
            return await _clientContext.Clients
                .Include(c => c.User)
                .Include(c => c.ClientWorkouts)
                .Include(c => c.Avaliations)
                .Include(c => c.DayOfTrains)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _clientContext.Clients
                .Include(c => c.User)
                .Include(c => c.Avaliations)
                .Include(c => c.ClientWorkouts)
                .Include(c => c.DayOfTrains)
                .ToListAsync();
        }

        public async Task<Client> RemoveAsync(Client client)
        {
            _clientContext.Remove(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            _clientContext.Update(client);
            await _clientContext.SaveChangesAsync();
            return client;
        }
    }
}

