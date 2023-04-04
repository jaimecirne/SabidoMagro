using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagersAsync();
        Task<Manager> GetByIdAsync(int? id);
        Task<Manager> CreateAsync(Manager manager);
        Task<Manager> UpdateAsync(Manager manager);
        Task<Manager> RemoveAsync(Manager manager);
    }
}
