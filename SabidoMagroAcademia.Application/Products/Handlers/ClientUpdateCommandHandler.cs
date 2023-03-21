using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ClientUpdateCommandHandler : IRequestHandler<ClientUpdateCommand, Client>
    {
        private readonly IClientRepository _productRepository;
        public ClientUpdateCommandHandler(IClientRepository productRepository)
        {
            _productRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Client> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                product.Update(request.Name, request.Description, request.Weight,
                                request.Height, request.Image, request.PlanId);
                return await _productRepository.UpdateAsync(product);
            }

        }
    }
}
