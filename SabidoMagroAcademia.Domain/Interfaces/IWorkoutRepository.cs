using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<IEnumerable<Workout>> GetWorkoutsAsync();
        Task<Workout> GetByIdAsync(int? id);
        Task<Workout> CreateAsync(Workout workout);
        Task<Workout> UpdateAsync(Workout workout);
        Task<Workout> RemoveAsync(Workout workout);
    }
}
