using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ManagerRemoveCommand : IRequest<Manager>
    {
        public int Id { get; set; }

        public ManagerRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
