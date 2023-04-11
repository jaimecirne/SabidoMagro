using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class WorkoutRemoveCommandHandler : IRequestHandler<WorkoutRemoveCommand, ClientWorkout>
    {
        private readonly IClientWorkoutRepository _productRepository;
        public WorkoutRemoveCommandHandler(IClientWorkoutRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        public async Task<ClientWorkout> Handle(WorkoutRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }

        }
    }
}
