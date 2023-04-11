using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IWorkoutService
    {
        Task<IEnumerable<WorkoutDTO>> GetWorkouts();
        Task<WorkoutDTO> GetById(int? id);
        Task Add(WorkoutDTO workoutDto);
        Task Update(WorkoutDTO workoutDto);
        Task Remove(int? id);
    }
}
