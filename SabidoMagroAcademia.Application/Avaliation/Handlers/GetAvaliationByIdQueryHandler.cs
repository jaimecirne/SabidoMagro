using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetAvaliationByIdQueryHandler : IRequestHandler<GetAvaliationByIdQuery, Avaliation>
    {
        private readonly IAvaliationRepository _productRepository;

        public GetAvaliationByIdQueryHandler(IAvaliationRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<Avaliation> Handle(GetAvaliationByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
