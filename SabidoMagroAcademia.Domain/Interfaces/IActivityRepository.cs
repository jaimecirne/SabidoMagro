using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetActivitysAsync();
        Task<Activity> GetByIdAsync(int? id);
        Task<Activity> CreateAsync(Activity activity);
        Task<Activity> UpdateAsync(Activity activity);
        Task<Activity> RemoveAsync(Activity activity);
    }
}
