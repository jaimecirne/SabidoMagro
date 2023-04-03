using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IAvaliationRepository
    {
        Task<IEnumerable<Avaliation>> GetAvaliationsAsync();
        Task<Avaliation> GetByIdAsync(int? id);
        Task<Avaliation> CreateAsync(Avaliation avaliation);
        Task<Avaliation> UpdateAsync(Avaliation avaliation);
        Task<Avaliation> RemoveAsync(Avaliation avaliation);
    }
}
