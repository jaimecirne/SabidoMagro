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
    public class GetDayOfTrainQueryHandler : IRequestHandler<GetDayOfTrainsQuery, IEnumerable<DayOfTrain>>
    {

        private readonly IDayOfTrainRepository _productRepository;

        public GetDayOfTrainQueryHandler(IDayOfTrainRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<DayOfTrain>> Handle(GetDayOfTrainsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetDayOfTrainsAsync();
        }

    }
}
