using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<ManagerDTO>> GetManagers();
        Task<ManagerDTO> GetById(int? id);
        Task Add(ManagerDTO managerDto);
        Task Update(ManagerDTO managerDto);
        Task Remove(int? id);
    }
}
