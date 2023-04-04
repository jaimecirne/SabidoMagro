using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> GetContractsAsync();
        Task<Contract> GetByIdAsync(int? id);
        Task<Contract> CreateAsync(Contract contract);
        Task<Contract> UpdateAsync(Contract contract);
        Task<Contract> RemoveAsync(Contract contract);
    }
}
