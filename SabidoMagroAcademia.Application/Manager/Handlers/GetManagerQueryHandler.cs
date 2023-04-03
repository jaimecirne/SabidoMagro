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
    public class GetManagerQueryHandler : IRequestHandler<GetManagersQuery, IEnumerable<Manager>>
    {

        private readonly IManagerRepository _productRepository;

        public GetManagerQueryHandler(IManagerRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Manager>> Handle(GetManagersQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetManagersAsync();
        }

    }
}
