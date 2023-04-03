using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IResourceService
    {
        Task<IEnumerable<ResourceDTO>> GetResources();
        Task<ResourceDTO> GetById(int? id);
        Task Add(ResourceDTO resourceDto);
        Task Update(ResourceDTO resourceDto);
        Task Remove(int? id);
    }
}
