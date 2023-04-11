using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class WorkoutRemoveCommand : IRequest<ClientWorkout>
    {
        public int Id { get; set; }

        public WorkoutRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
