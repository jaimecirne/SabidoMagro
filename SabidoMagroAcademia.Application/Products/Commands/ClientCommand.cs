using MediatR;
using SabidoMagroAcademia.Domain.Entities;

namespace SabidoMagroAcademia.Application.Products.Commands
{
    public abstract class ClientCommand : IRequest<Client>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
        public int Height { get; set; }
        public string Image { get; set; }
        public int PlanId { get; set; }
    }
}
