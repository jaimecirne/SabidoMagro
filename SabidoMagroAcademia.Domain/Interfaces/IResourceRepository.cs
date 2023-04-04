using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Resource>> GetResourcesAsync();
        Task<Resource> GetByIdAsync(int? id);
        Task<Resource> CreateAsync(Resource resource);
        Task<Resource> UpdateAsync(Resource resource);
        Task<Resource> RemoveAsync(Resource resource);
    }
}
