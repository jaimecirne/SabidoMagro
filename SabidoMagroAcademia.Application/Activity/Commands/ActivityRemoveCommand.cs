using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ActivityRemoveCommand : IRequest<Activity>
    {
        public int Id { get; set; }

        public ActivityRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
