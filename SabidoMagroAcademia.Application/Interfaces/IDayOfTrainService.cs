using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IDayOfTrainService
    {
        Task<IEnumerable<DayOfTrainDTO>> GetDayOfTrains();
        Task<DayOfTrainDTO> GetById(int? id);
        Task Add(DayOfTrainDTO dayoftrainDto);
        Task Update(DayOfTrainDTO dayoftrainDto);
        Task Remove(int? id);
    }
}
