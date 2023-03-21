using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> GetPlans();
        Task<Plan> GetById(int? id);
        Task<Plan> Create(Plan plan);
        Task<Plan> Update(Plan plan);
        Task<Plan> Remove(Plan plan);
    }
}
