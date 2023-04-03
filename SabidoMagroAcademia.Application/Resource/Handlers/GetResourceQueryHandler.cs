using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetResourceQueryHandler : IRequestHandler<GetResourcesQuery, IEnumerable<Resource>>
    {

        private readonly IResourceRepository _productRepository;

        public GetResourceQueryHandler(IResourceRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Resource>> Handle(GetResourcesQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetResourcesAsync();
        }

    }
}
