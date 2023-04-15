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
    public class GetClientQueryHandler : IRequestHandler<GetClientsQuery, IEnumerable<Client>>
    {

        private readonly IClientRepository _clientRepository;

        public GetClientQueryHandler(IClientRepository productRepository)
        {
            _clientRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Client>> Handle(GetClientsQuery request,
            CancellationToken cancellationToken)
        {
            return await _clientRepository.GetClientsAsync();
        }

    }
}
