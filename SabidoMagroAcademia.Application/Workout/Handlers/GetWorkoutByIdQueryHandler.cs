using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetWorkoutByIdQueryHandler : IRequestHandler<GetWorkoutByIdQuery, Workout>
    {
        private readonly IWorkoutRepository _productRepository;

        public GetWorkoutByIdQueryHandler(IWorkoutRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<Workout> Handle(GetWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
