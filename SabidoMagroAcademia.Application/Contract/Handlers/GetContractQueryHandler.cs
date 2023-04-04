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
    public class GetContractQueryHandler : IRequestHandler<GetContractsQuery, IEnumerable<Contract>>
    {

        private readonly IContractRepository _productRepository;

        public GetContractQueryHandler(IContractRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Contract>> Handle(GetContractsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetContractsAsync();
        }

    }
}
