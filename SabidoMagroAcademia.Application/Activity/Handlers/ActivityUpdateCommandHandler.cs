using MediatR;
using SabidoMagroAcademia.Application.Products.Commands;
using SabidoMagroAcademia.Domain.Entities;
using SabidoMagroAcademia.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SabidoMagroAcademia.Application.Products.Handlers
{
    public class ActivityUpdateCommandHandler : IRequestHandler<ActivityUpdateCommand, Activity>
    {
        private readonly IActivityRepository _activityRepository;
        public ActivityUpdateCommandHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository ??//caso seja null, retorna uma exceção
            throw new ArgumentNullException(nameof(activityRepository));
        }

        public async Task<Activity> Handle(ActivityUpdateCommand request, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(request.Id);

            if (activity == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }

            else
            {
                activity.Update(request.Id, request.Label);
                return await _activityRepository.UpdateAsync(activity);
            }

        }
    }
}
