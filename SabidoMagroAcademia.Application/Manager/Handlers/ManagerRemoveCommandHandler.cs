using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ManagerRemoveCommandHandler : IRequestHandler<ManagerRemoveCommand, Manager>
    {
        private readonly IManagerRepository _productRepository;
        public ManagerRemoveCommandHandler(IManagerRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<Manager> Handle(ManagerRemoveCommand request,
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
