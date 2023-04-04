using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IClientWorkoutService
    {
        Task<IEnumerable<ClientWorkoutDTO>> GetClientWorkouts();
        Task<ClientWorkoutDTO> GetById(int? id);
        Task Add(ClientWorkoutDTO clientworkoutDto);
        Task Update(ClientWorkoutDTO clientworkoutDto);
        Task Remove(int? id);
    }
}
