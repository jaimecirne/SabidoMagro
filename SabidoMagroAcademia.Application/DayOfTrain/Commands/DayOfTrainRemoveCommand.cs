using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class DayOfTrainRemoveCommand : IRequest<DayOfTrain>
    {
        public int Id { get; set; }

        public DayOfTrainRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
