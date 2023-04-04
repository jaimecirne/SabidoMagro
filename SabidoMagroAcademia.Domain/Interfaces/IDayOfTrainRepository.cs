using SabidoMagroAcademia.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Domain.Interfaces
{
    public interface IDayOfTrainRepository
    {
        Task<IEnumerable<DayOfTrain>> GetDayOfTrainsAsync();
        Task<DayOfTrain> GetByIdAsync(int? id);
        Task<DayOfTrain> CreateAsync(DayOfTrain dayoftrain);
        Task<DayOfTrain> UpdateAsync(DayOfTrain dayoftrain);
        Task<DayOfTrain> RemoveAsync(DayOfTrain dayoftrain);
    }
}
