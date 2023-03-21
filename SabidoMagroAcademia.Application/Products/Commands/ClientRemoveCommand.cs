using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    //classe não precisa herdar de ClientCommand, pois para esta operação só necessita do id.
    public class ClientRemoveCommand : IRequest<Client>
    {
        public int Id { get; set; }

        public ClientRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
