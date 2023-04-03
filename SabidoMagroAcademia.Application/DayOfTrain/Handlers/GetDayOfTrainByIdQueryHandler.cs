using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetDayOfTrainByIdQueryHandler : IRequestHandler<GetDayOfTrainByIdQuery, DayOfTrain>
    {
        private readonly IDayOfTrainRepository _productRepository;

        public GetDayOfTrainByIdQueryHandler(IDayOfTrainRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<DayOfTrain> Handle(GetDayOfTrainByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
