using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ResourceCreateCommandHandler : IRequestHandler<ResourceCreateCommand, Resource>
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceCreateCommandHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository ?? throw new
                ArgumentNullException(nameof(resourceRepository));
        }
        public async Task<Resource> Handle(ResourceCreateCommand request,
            CancellationToken cancellationToken)
        {
            var resource = new Resource(request.Label, request.Key);
            
            if (resource == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _resourceRepository.CreateAsync(resource);
            }
        }
    }
}
