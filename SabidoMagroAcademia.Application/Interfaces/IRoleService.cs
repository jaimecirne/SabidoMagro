using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetRoles();
        Task<RoleDTO> GetById(int? id);
        Task Add(RoleDTO roleDto);
        Task Update(RoleDTO roleDto);
        Task Remove(int? id);
    }
}
