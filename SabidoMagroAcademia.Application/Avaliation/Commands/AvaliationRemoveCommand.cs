using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class AvaliationRemoveCommand : IRequest<Avaliation>
    {
        public int Id { get; set; }

        public AvaliationRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
