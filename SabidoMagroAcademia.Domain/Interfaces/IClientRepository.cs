using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> GetByIdAsync(int? id);
        Task<Client> CreateAsync(Client client);
        Task<Client> UpdateAsync(Client client);
        Task<Client> RemoveAsync(Client client);
    }
}
