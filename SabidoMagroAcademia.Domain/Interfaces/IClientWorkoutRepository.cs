using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IClientWorkoutRepository
    {
        Task<IEnumerable<ClientWorkout>> GetClientWorkoutsAsync();
        Task<ClientWorkout> GetByIdAsync(int? id);
        Task<ClientWorkout> CreateAsync(ClientWorkout clientworkout);
        Task<ClientWorkout> UpdateAsync(ClientWorkout clientworkout);
        Task<ClientWorkout> RemoveAsync(ClientWorkout clientworkout);
    }
}
