using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    //informa qual o command que vai porcessar e o tipo de retorno (Product)
    public class ClientCreateCommandHandler : IRequestHandler<ClientCreateCommand, Client>
    {
        private readonly IClientRepository _productRepository;
        public ClientCreateCommandHandler(IClientRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }
        public async Task<Client> Handle(ClientCreateCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Client(request.Name, request.Description, request.Weight,
                              request.Height, request.Image);
            
            //Como a entidade product realiza validação dos dados é necessário verificar se as mesmas passaram
            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.PlanId = request.PlanId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
