using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class WorkoutUpdateCommandHandler : IRequestHandler<WorkoutUpdateCommand, Workout>
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutUpdateCommandHandler(IWorkoutRepository productRepository)
        {
            _workoutRepository = productRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Workout> Handle(WorkoutUpdateCommand request, CancellationToken cancellationToken)
        {
            var workout = await _workoutRepository.GetByIdAsync(request.Id);

            if (workout == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                workout.Update(request.Id, request.Label, request.WorkoutActivities);
                return await _workoutRepository.UpdateAsync(workout);
            }

        }
    }
}
