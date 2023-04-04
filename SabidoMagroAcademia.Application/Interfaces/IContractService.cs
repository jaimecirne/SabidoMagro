using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IContractService
    {
        Task<IEnumerable<ContractDTO>> GetContracts();
        Task<ContractDTO> GetById(int? id);
        Task Add(ContractDTO contractDto);
        Task Update(ContractDTO contractDto);
        Task Remove(int? id);
    }
}
