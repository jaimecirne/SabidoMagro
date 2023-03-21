using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IPlanService
    {
        Task<IEnumerable<PlanDTO>> GetCategories();
        Task<PlanDTO> GetById(int? id);
        Task Add(PlanDTO planDto);
        Task Update(PlanDTO planDto);
        Task Remove(int? id);
    }
}
