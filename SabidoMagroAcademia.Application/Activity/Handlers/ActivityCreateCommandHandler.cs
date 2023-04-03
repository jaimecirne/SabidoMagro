using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ActivityCreateCommandHandler : IRequestHandler<ActivityCreateCommand, Activity>
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityCreateCommandHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository ?? throw new
                ArgumentNullException(nameof(activityRepository));
        }
        public async Task<Activity> Handle(ActivityCreateCommand request,
            CancellationToken cancellationToken)
        {
            var activity = new Activity(request.User);
            
            if (activity == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                return await _activityRepository.CreateAsync(activity);
            }
        }
    }
}
