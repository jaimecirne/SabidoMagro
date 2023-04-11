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
    public class GetWorkoutQueryHandler : IRequestHandler<GetWorkoutsQuery, IEnumerable<Workout>>
    {

        private readonly IWorkoutRepository _productRepository;

        public GetWorkoutQueryHandler(IWorkoutRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Workout>> Handle(GetWorkoutsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetWorkoutsAsync();
        }

    }
}
