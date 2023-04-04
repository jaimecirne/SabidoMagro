using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ClientWorkoutRemoveCommand : IRequest<ClientWorkout>
    {
        public int Id { get; set; }

        public ClientWorkoutRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
