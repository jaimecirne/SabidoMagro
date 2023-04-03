using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ResourceRemoveCommand : IRequest<Resource>
    {
        public int Id { get; set; }

        public ResourceRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
