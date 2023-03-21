using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientRemoveCommandHandler : IRequestHandler<ClientRemoveCommand, Client>
    {
        private readonly IClientRepository _productRepository;
        public ClientRemoveCommandHandler(IClientRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<Client> Handle(ClientRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }

        }
    }
}
