using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ClientRemoveCommand : IRequest<Client>
    {
        public int Id { get; set; }

        public ClientRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
