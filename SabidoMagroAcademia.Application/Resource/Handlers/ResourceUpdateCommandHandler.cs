using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ResourceUpdateCommandHandler : IRequestHandler<ResourceUpdateCommand, Resource>
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceUpdateCommandHandler(IResourceRepository productRepository)
        {
            _resourceRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Resource> Handle(ResourceUpdateCommand request, CancellationToken cancellationToken)
        {
            var resource = await _resourceRepository.GetByIdAsync(request.Id);

            if (resource == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                resource.Update(request.Id, request.Label, request.Key);
                return await _resourceRepository.UpdateAsync(resource);
            }

        }
    }
}
