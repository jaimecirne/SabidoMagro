using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IActivityService
    {
        Task<IEnumerable<ActivityDTO>> GetActivities();
        Task<ActivityDTO> GetById(int? id);
        Task Add(ActivityDTO activityDto);
        Task Update(ActivityDTO activityDto);
        Task Remove(int? id);
    }
}
