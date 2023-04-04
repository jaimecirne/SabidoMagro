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
    public class GetClientWorkoutQueryHandler : IRequestHandler<GetClientWorkoutsQuery, IEnumerable<ClientWorkout>>
    {

        private readonly IClientWorkoutRepository _productRepository;

        public GetClientWorkoutQueryHandler(IClientWorkoutRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<ClientWorkout>> Handle(GetClientWorkoutsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetClientWorkoutsAsync();
        }

    }
}
