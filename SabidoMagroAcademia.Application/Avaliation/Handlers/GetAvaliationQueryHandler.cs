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
    public class GetAvaliationQueryHandler : IRequestHandler<GetAvaliationsQuery, IEnumerable<Avaliation>>
    {

        private readonly IAvaliationRepository _productRepository;

        public GetAvaliationQueryHandler(IAvaliationRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Avaliation>> Handle(GetAvaliationsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetAvaliationsAsync();
        }

    }
}
