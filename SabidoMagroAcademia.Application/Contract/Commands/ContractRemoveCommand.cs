using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public class ContractRemoveCommand : IRequest<Contract>
    {
        public int Id { get; set; }

        public ContractRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
