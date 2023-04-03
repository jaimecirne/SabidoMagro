using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class RoleRemoveCommand : IRequest<Role>
    {
        public int Id { get; set; }

        public RoleRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
