using MediatR;
using SabidoMagroAcademia.Application.Products.Queries;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class GetClientWorkoutByIdQueryHandler : IRequestHandler<GetClientWorkoutByIdQuery, ClientWorkout>
    {
        private readonly IClientWorkoutRepository _productRepository;

        public GetClientWorkoutByIdQueryHandler(IClientWorkoutRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<ClientWorkout> Handle(GetClientWorkoutByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetByIdAsync(request.Id);
        }
    }
}
