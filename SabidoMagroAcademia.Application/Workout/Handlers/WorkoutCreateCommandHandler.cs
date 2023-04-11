using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class WorkoutCreateCommandHandler : IRequestHandler<WorkoutCreateCommand, Workout>
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutCreateCommandHandler(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository ?? throw new
                ArgumentNullException(nameof(workoutRepository));
        }
        public async Task<Workout> Handle(WorkoutCreateCommand request,
            CancellationToken cancellationToken)
        {
            var workout = new Workout(request.Label, request.WorkoutActivities);
            
            if (workout == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _workoutRepository.CreateAsync(workout);
            }
        }
    }
}
