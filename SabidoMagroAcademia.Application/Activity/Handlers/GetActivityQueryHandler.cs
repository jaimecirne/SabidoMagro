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
    public class GetActivityQueryHandler : IRequestHandler<GetActivitiesQuery, IEnumerable<Activity>>
    {

        private readonly IActivityRepository _productRepository;

        public GetActivityQueryHandler(IActivityRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Activity>> Handle(GetActivitiesQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetActivitysAsync();
        }

    }
}
