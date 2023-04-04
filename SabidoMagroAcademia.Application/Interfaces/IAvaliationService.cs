using SabidoMagroAcademia.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Interfaces
{
    public interface IAvaliationService
    {
        Task<IEnumerable<AvaliationDTO>> GetAvaliations();
        Task<AvaliationDTO> GetById(int? id);
        Task Add(AvaliationDTO avaliationDto);
        Task Update(AvaliationDTO avaliationDto);
        Task Remove(int? id);
    }
}
